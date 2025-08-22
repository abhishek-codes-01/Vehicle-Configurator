package com.example.security;

import java.util.Date;
import java.util.HashMap;
import java.util.Map;
import java.util.function.Function;

import javax.crypto.SecretKey;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.stereotype.Service;

import io.jsonwebtoken.Claims;
import io.jsonwebtoken.Jwts;
import io.jsonwebtoken.SignatureAlgorithm;
import io.jsonwebtoken.security.Keys;

@Service
public class JwtUtil {
    @Value("${jwt.secret}")
    private String secret;

    public String getUsernameFromToken(String token) {
        return getClaimFromToken(token, Claims::getSubject);
    }

    public <T> T getClaimFromToken(String token, Function<Claims, T> claimsResolver) {
        final Claims claims = getAllClaimsFromToken(token);
        return claimsResolver.apply(claims);
    }

    public Claims getAllClaimsFromToken(String token) {
        SecretKey key = Keys.hmacShaKeyFor(secret.getBytes());
        return Jwts.parserBuilder().setSigningKey(key).build().parseClaimsJws(token).getBody();
    }

    private Boolean isTokenExpired(String token) {
        return getClaimFromToken(token, Claims::getExpiration).before(new Date());
    }

    public Boolean validateToken(String token, UserDetails userdetails) {
        final String username = getUsernameFromToken(token);
        return (username.equals(userdetails.getUsername()) && !isTokenExpired(token));
    }

    public String generateAccessToken(UserDetails userdetails) {
        return createToken(new HashMap<>(), userdetails.getUsername(), 4 * 60 * 60 * 1000); // 4 hours
    }

    public String generateRefreshToken(UserDetails userdetails) {
        return createToken(new HashMap<>(), userdetails.getUsername(), 7 * 24 * 60 * 60 * 1000); // 7 days
    }

    public String createToken(Map<String, Object> claims, String subject, long expTimeinMillis) {
        SecretKey key = Keys.hmacShaKeyFor(secret.getBytes());
        return Jwts.builder()
                .setClaims(claims)
                .setSubject(subject)
                .setIssuedAt(new Date())
                .setExpiration(new Date(System.currentTimeMillis() + expTimeinMillis))
                .signWith(key, SignatureAlgorithm.HS256)
                .compact();
    }
}