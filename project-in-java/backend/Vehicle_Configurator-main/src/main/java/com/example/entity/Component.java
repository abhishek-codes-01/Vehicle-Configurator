package com.example.entity;

import java.util.Set;

import com.fasterxml.jackson.annotation.JsonIgnore;

import jakarta.persistence.CascadeType;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.OneToMany;
import lombok.Data;


@Entity
@Data
public class Component {
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private int comp_id;
	
	private String comp_name;
	
	@OneToMany(mappedBy = "component")
	@JsonIgnore
	private Set<Vehicle_detail> vehicleDetails;
	
	@OneToMany(mappedBy = "component")
	@JsonIgnore
	private Set<Invoice_detail> invoiceDetails;
	
	@OneToMany(cascade=CascadeType.ALL)
	@JoinColumn(name="comp_id", referencedColumnName="comp_id")
	private Set<Alternate_Component_Master> defaultComp;
	
	@OneToMany(cascade=CascadeType.ALL)
	@JoinColumn(name="alt_comp_id", referencedColumnName="comp_id")
	private Set<Alternate_Component_Master> altComp;
}
