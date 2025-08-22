package com.example.entity;



import com.fasterxml.jackson.annotation.JsonIgnore;

import jakarta.persistence.CascadeType;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.OneToOne;
import lombok.Data;

@Entity
@Data
public class Alternate_Component_Master {
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private int alt_id;
	private double delta_price;
	@ManyToOne
	@JoinColumn(name = "model_id")
	@JsonIgnore
	private Model model;
	
	@ManyToOne
	@JoinColumn(name = "comp_id")
	@JsonIgnore
	private Component component;
	
	@ManyToOne
	@JoinColumn(name="alt_comp_id")
	private Component altComponent;
}
