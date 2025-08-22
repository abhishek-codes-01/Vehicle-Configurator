package com.example.entity;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import lombok.Data;

@Entity
@Data
public class SgMfgMaster {
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int sgmf_id;
	
	@ManyToOne
	@JoinColumn(name="seg_id",nullable = false)
	private Segment seg_id;
	
	@ManyToOne
	@JoinColumn(name="mfg_id",nullable = false)
	private Manufacturer mfg_id;

	

	
	
}
