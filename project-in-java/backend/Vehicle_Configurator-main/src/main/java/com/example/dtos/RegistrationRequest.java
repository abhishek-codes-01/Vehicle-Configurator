package com.example.dtos;

import java.math.BigDecimal;

import lombok.Data;

public class RegistrationRequest {
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
    public String getUsername() {
		return username;
	}
	public void setUsername(String username) {
		this.username = username;
	}
	public String getPassword() {
		return password;
	}
	public void setPassword(String password) {
		this.password = password;
	}
	public String getRole() {
		return role;
	}
	public void setRole(String role) {
		this.role = role;
	}
	public String getHolding() {
		return holding;
	}
	public void setHolding(String holding) {
		this.holding = holding;
	}
	public int getSt_no() {
		return st_no;
	}
	public void setSt_no(int st_no) {
		this.st_no = st_no;
	}
	public BigDecimal getTel() {
		return tel;
	}
	public void setTel(BigDecimal tel) {
		this.tel = tel;
	}
	public String getAddr() {
		return addr;
	}
	public void setAddr(String addr) {
		this.addr = addr;
	}
	public String getAuth_name() {
		return auth_name;
	}
	public void setAuth_name(String auth_name) {
		this.auth_name = auth_name;
	}
	public BigDecimal getCell() {
		return cell;
	}
	public void setCell(BigDecimal cell) {
		this.cell = cell;
	}
	public String getCity() {
		return city;
	}
	public void setCity(String city) {
		this.city = city;
	}
	public String getCompany_name() {
		return company_name;
	}
	public void setCompany_name(String company_name) {
		this.company_name = company_name;
	}
	public String getDesig() {
		return desig;
	}
	public void setDesig(String desig) {
		this.desig = desig;
	}
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	public int getPin() {
		return pin;
	}
	public void setPin(int pin) {
		this.pin = pin;
	}
	public BigDecimal getReg_no() {
		return reg_no;
	}
	public void setReg_no(BigDecimal reg_no) {
		this.reg_no = reg_no;
	}
	public String getState() {
		return state;
	}
	public void setState(String state) {
		this.state = state;
	}
	private int pin;
    private BigDecimal reg_no;
    private String state;
}
