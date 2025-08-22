package com.example.entity;

import jakarta.persistence.*;
import lombok.Data;
import lombok.Getter;

import java.util.*;

@Data
@Entity
public class Segment {
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private int seg_id;
	private String seg_name;	

}
