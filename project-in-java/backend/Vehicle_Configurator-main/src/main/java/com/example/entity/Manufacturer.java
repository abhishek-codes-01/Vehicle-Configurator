package com.example.entity;

import java.util.Set;

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

public class Manufacturer {
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private int mfg_id;
	private String mfg_name;
	
	
}
