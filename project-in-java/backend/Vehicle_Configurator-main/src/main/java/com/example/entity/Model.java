package com.example.entity;

import java.util.Set;

import com.fasterxml.jackson.annotation.JsonIgnore;

import jakarta.persistence.CascadeType;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.OneToMany;
import jakarta.persistence.OneToOne;
import lombok.Data;

@Entity
@Data
public class Model {
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private int model_id;
	
	private String model_name;
	private int min_qty;
	private String img_path;
	private double price;
	
	@OneToMany(mappedBy = "model", cascade = CascadeType.ALL)
	@JsonIgnore
	private Set<Vehicle_detail> vehicleDetails;
	
	@OneToOne(mappedBy = "model", cascade = CascadeType.ALL)
	@JsonIgnore
	private Invoice_header invoices;
	
	@OneToMany(mappedBy = "model", cascade = CascadeType.ALL)
	@JsonIgnore
	private Set<Alternate_Component_Master> altComps;
	
	@ManyToOne
	@JoinColumn(name = "seg_id", nullable = false)
	private Segment segment;
	
	@ManyToOne
	@JoinColumn(name = "mfg_id", nullable = false)
	private Manufacturer manufacturer;
	
}
