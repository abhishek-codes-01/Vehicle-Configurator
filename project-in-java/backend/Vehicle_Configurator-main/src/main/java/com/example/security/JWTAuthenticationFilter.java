package com.example.security;

import java.io.IOException;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.web.authentication.WebAuthenticationDetailsSource;
import org.springframework.stereotype.Component;
import org.springframework.web.filter.OncePerRequestFilter;

import jakarta.servlet.FilterChain;
import jakarta.servlet.ServletException;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

@Component
public class JWTAuthenticationFilter extends OncePerRequestFilter {

    @Autowired 
    private CustomUserDetailsService customuserdetailsservice;

    @Autowired
    private JwtUtil jwtutil;

    @Override
    protected void doFilterInternal(HttpServletRequest request, HttpServletResponse response, 
                                  FilterChain filterChain) throws ServletException, IOException {
        
        String requestPath = request.getRequestURI();
        String method = request.getMethod();
        System.out.println("🔍 JWT Filter: " + method + " " + requestPath);
        
        String requestTokenHeader = request.getHeader("Authorization");
        String username = null;
        String jwttoken = null;

        // Extract JWT token from Authorization header
        if (requestTokenHeader != null && requestTokenHeader.startsWith("Bearer ")) {
            jwttoken = requestTokenHeader.substring(7);
            System.out.println("🎫 JWT Token found: " + jwttoken.substring(0, Math.min(jwttoken.length(), 20)) + "...");
            
            try {
                username = jwtutil.getUsernameFromToken(jwttoken);
                System.out.println("👤 Username extracted: " + username);
            } catch (Exception e) {
                System.out.println("❌ JWT Token parsing failed: " + e.getMessage());
                e.printStackTrace();
            }
        } else {
            System.out.println("⚠️ No Bearer token found in Authorization header");
        }

        // Validate token and set authentication
        if (username != null && SecurityContextHolder.getContext().getAuthentication() == null) {
            try {
                UserDetails userDetails = customuserdetailsservice.loadUserByUsername(username);
                System.out.println("📋 UserDetails loaded for: " + userDetails.getUsername());
                
                if (jwtutil.validateToken(jwttoken, userDetails)) {
                    UsernamePasswordAuthenticationToken authToken = 
                        new UsernamePasswordAuthenticationToken(
                            userDetails, null, userDetails.getAuthorities());
                    authToken.setDetails(new WebAuthenticationDetailsSource().buildDetails(request));
                    SecurityContextHolder.getContext().setAuthentication(authToken);
                    System.out.println("✅ Authentication SUCCESS for: " + username);
                } else {
                    System.out.println("❌ Token validation FAILED for: " + username);
                }
            } catch (Exception e) {
                System.out.println("❌ Authentication error: " + e.getMessage());
                e.printStackTrace();
            }
        } else if (username == null) {
            System.out.println("⏭️ Skipping authentication - no username extracted");
        } else {
            System.out.println("⏭️ Skipping authentication - already authenticated");
        }

        System.out.println("➡️ Continuing filter chain\n");
        filterChain.doFilter(request, response);
    }
}
