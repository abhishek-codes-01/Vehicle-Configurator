package com.example.entity;

import com.fasterxml.jackson.annotation.JsonIgnore;

import jakarta.persistence.CascadeType;
import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.EnumType;
import jakarta.persistence.Enumerated;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.OneToOne;
import lombok.Data;

@Entity
@Data
public class Vehicle_detail {
	
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private int config_id;
	
	@ManyToOne
	@JsonIgnore
	@JoinColumn(name="comp_id",referencedColumnName = "comp_id")
	private Component component;
	
	@Enumerated(EnumType.STRING)
	@Column(name="comp_type")
	private ComponentType comp_type;


	@Column(name = "is_config")
	private String isConfig;;
	
	@ManyToOne
	@JoinColumn(name="model_id", referencedColumnName = "model_id")
	@JsonIgnore
	private Model model;
	
	
}
