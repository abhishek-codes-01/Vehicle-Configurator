package com.example.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.entity.Model;
import com.example.repository.ModelRepository;

@Service
public class ModelService {
	@Autowired
	private ModelRepository repo;
	
	public List<Model> findModelByManufacturerId(int id){
		return repo.findModelByManufacturerId(id);
	}
	
	public List<Model> findModelBySegmentId(int id){
		return repo.findModelBySegmentId(id);
	}
	
	
    public List<Model> getAllModels() {
        return repo.findAll();
    }

  
    public Model saveModel(Model model) {
        return repo.save(model);
    }
    
    public List<Model>findModelBySfMfgId(int segId,int mfgId){
		return repo.findBySfMfgId(segId, mfgId);
	}
    
    public Model getModelById(int id) {
        return repo.findById(id)
            .orElseThrow(() -> new RuntimeException("Model not found with id: " + id));
    }

	
}
