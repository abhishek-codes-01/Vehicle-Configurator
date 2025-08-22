	package com.example.controller;

import com.example.dtos.AlternateComponentMasterDTO;
import com.example.entity.Alternate_Component_Master;
import com.example.service.Alternate_Component_MasterService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
//@CrossOrigin("http://localhost:8080")
@RequestMapping("/api/alternate-components")
public class AlternateComponentMasterController {

    @Autowired
    private Alternate_Component_MasterService service;
    
    

//    @GetMapping("/all")
//    public List<Alternate_Component_Master> getAllAlternateComponents() {
//        return service.getAllAlternateComponents();
//    }

//    @PostMapping("/save")
//    public Alternate_Component_Master saveAlternateComponent(@RequestBody Alternate_Component_Master altComponent) {
//        return service.saveAlternateComponent(altComponent);
//    }
//    
//    @GetMapping("/get/{id}")
//    public Alternate_Component_Master getAlternateComponentById(@PathVariable int id) {
//        return service.getAlternateComponentById(id);
//    }
    
//    @GetMapping("/model/{id}")
//    public ResponseEntity<List<Alternate_Component_Master>> getAlternateComponentsByModelId(@PathVariable int id) {
//        List<Alternate_Component_Master> components = service.findAltCompByModelId(id);
//
//        if (components.isEmpty()) {
//            return ResponseEntity.noContent().build();
//        }
//
//        return ResponseEntity.ok(components);
//    }
    
    
    @GetMapping("/all")
    public List<AlternateComponentMasterDTO> getAllAlternateComponents() { // Returns DTOs
        return service.getAllAlternateComponentsDTO();
    }

    @PostMapping("/save")
    public Alternate_Component_Master saveAlternateComponent(@RequestBody Alternate_Component_Master altComponent) {
        // This endpoint still accepts the full entity for saving.
        return service.saveAlternateComponent(altComponent);
    }

    @GetMapping("/get/{id}")
    public AlternateComponentMasterDTO getAlternateComponentById(@PathVariable int id) { // Returns DTO
        return service.getAlternateComponentByIdDTO(id);
    }

    @GetMapping("/model/{id}")
    public ResponseEntity<List<AlternateComponentMasterDTO>> getAlternateComponentsByModelId(@PathVariable int id) { // Returns DTOs
        List<AlternateComponentMasterDTO> components = service.findAltCompByModelIdDTO(id);

        if (components.isEmpty()) {
            return ResponseEntity.noContent().build();
        }

        return ResponseEntity.ok(components);
    }
    
    @GetMapping("/model/{model_id}/comp/{comp_id}")
    public ResponseEntity<List<Alternate_Component_Master>> getaltByModelComp(@PathVariable("model_id") int model_id, @PathVariable("comp_id") int comp_id ){
    	List<Alternate_Component_Master> alt = service.findAltCompByModelIdAndComponentId(model_id,comp_id);
    	return ResponseEntity.ok(alt);
    }

}
