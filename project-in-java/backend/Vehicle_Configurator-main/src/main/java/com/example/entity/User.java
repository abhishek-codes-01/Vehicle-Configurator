package com.example.entity;

import java.math.BigDecimal;

import jakarta.persistence.*;
import lombok.Data;

@Entity
@Data
public class User {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    private String username;
    private String password;
    private String role;

    private String holding;
    private int st_no;
    private BigDecimal tel;
    private String addr;
    private String auth_name;
    private BigDecimal cell;
    private String city;
    private String company_name;
    private String desig;
    private String email;
    private int pin;
    private BigDecimal reg_no;
    private String state;
}
