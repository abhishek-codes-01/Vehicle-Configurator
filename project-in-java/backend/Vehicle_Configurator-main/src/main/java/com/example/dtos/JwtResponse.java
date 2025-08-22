package com.example.dtos;

public class JwtResponse {
    private String token; // Changed from accesstoken to token
    private String refreshtoken;
    private String tokentype = "Bearer";

    public JwtResponse(String token, String refreshtoken) {
        this.setToken(token);
        this.setRefreshtoken(refreshtoken);
    }

    public String getToken() { // Changed from getAccesstoken
        return token;
    }

    public void setToken(String token) { // Changed from setAccesstoken
        this.token = token;
    }

    public String getRefreshtoken() {
        return refreshtoken;
    }

    public void setRefreshtoken(String refreshtoken) {
        this.refreshtoken = refreshtoken;
    }

    public String getTokentype() {
        return tokentype;
    }

    public void setTokentype(String tokentype) {
        this.tokentype = tokentype;
    }
}