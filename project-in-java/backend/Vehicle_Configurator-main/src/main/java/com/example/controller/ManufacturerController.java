package com.example.controller;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.example.entity.Manufacturer;
import com.example.service.ManufacturerService;

@RestController
//@CrossOrigin("http://localhost:8080")
@RequestMapping("/manufacturers")
public class ManufacturerController {
	@Autowired
	public ManufacturerService mfgservice;
	
	@GetMapping("/{mfg_id}")
	public ResponseEntity <Optional<Manufacturer>> getById(@PathVariable("mfg_id") int id){
		Optional<Manufacturer> mfg = mfgservice.findById(id);
		return ResponseEntity.ok(mfg);
		
	}
	
	@GetMapping("/all")
    public List<Manufacturer> getAllManufacturers() {
        return mfgservice.getAllManufacturers();
    }

    @PostMapping("/save")
    public Manufacturer saveManufacturer(@RequestBody Manufacturer manufacturer) {
        return mfgservice.saveManufacturer(manufacturer);
    }
    
	
//	@GetMapping("/segments/{seg_id}")
//	public ResponseEntity<List<Manufacturer>> getBySegId(@PathVariable("seg_id") int id){
//		List<Manufacturer> mfg = mfgservice.findManufacturersBySegmentId(id);
//		return ResponseEntity.ok(mfg);
//		}
}
