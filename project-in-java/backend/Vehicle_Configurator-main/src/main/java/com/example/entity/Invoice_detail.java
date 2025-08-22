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
public class Invoice_detail {
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int invDtl_id;
	
	@ManyToOne(cascade = CascadeType.ALL)
    @JoinColumn(name = "inv_id", referencedColumnName = "inv_id")
    private Invoice_header invoice;
	
	@ManyToOne(cascade = CascadeType.ALL)
    @JoinColumn(name = "comp_id", referencedColumnName = "comp_id")
	@JsonIgnore
    private Component component;
}
