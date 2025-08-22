package com.example.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.example.entity.Model;
import com.example.service.ModelService;

@RestController
//@CrossOrigin("http://localhost:8080")
@RequestMapping("/models")
public class ModelController {
	private final ModelService service;
	
	
	public ModelController(ModelService serv) {
		service = serv;
	}
	
	
	
	@GetMapping("/manufacturer/{mfg_id}")
	public ResponseEntity<List<Model>> getModelByMfgId(@PathVariable("mfg_id") int id){
		List<Model> model = service.findModelByManufacturerId(id);
		return ResponseEntity.ok(model);
	}
	
	@GetMapping("/segments/{seg_id}")
	public ResponseEntity<List<Model>> getModelBySegmentId(@PathVariable("seg_id") int id){
		List<Model> model = service.findModelBySegmentId(id);
		return ResponseEntity.ok(model);
	}
	
	 @GetMapping("/all")
	 public List<Model> getAllModels() {
	        return service.getAllModels();
	    }
	 @PostMapping("/save")
	    public Model saveModel(@RequestBody Model model) {
	        return service.saveModel(model);
	    }
	 
	
	 @GetMapping("/segment/{segId}/manufacturer/{mfgId}")
	    public ResponseEntity<List<Model>> getModelsBySegmentAndManufacturer(
	            @PathVariable int segId,
	            @PathVariable int mfgId) {
	        
	        List<Model> models = service.findModelBySfMfgId(segId, mfgId);
	        return ResponseEntity.ok(models);
	    }
	 @GetMapping("/details/{id}")
	 public ResponseEntity<Model> getModelById(@PathVariable("id") int id) {
	     Model model = service.getModelById(id);
	     return ResponseEntity.ok(model);
	 }

	    

	 
	    
}
