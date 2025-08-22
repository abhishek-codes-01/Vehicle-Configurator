package com.example.service;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.entity.Manufacturer;
import com.example.repository.ManufacturerRepository;

@Service
public class ManufacturerService {
	@Autowired
	private ManufacturerRepository repo;
	
	public Optional<Manufacturer> findById(int id) {
	    return repo.findById(id);
	}
	
	public List<Manufacturer> findManufacturersBySegmentId(int id){
		return repo.findManufacturersBySegmentId(id);
	}
	
	
    public List<Manufacturer> getAllManufacturers() {
        return repo.findAll();
    }

    
    public Manufacturer saveManufacturer(Manufacturer manufacturer) {
        return repo.save(manufacturer);
    }
    
	
}
