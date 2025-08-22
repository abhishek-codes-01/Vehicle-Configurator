package com.example.entity;

import jakarta.persistence.CascadeType;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import lombok.Data;

import java.time.LocalDate;

import com.fasterxml.jackson.annotation.JsonIgnore;


@Entity
@Data
public class Invoice_header {
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private int inv_id;
	private LocalDate inv_date;
	private double total_amt;
	private double tax;
	private double amt;
	private String customer_detail;
	@ManyToOne(cascade = CascadeType.ALL)
	@JoinColumn(name="model_id")
	@JsonIgnore
	private Model model;
	
}
