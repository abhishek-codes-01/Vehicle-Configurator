package com.example.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.example.dtos.ComponentDTO;
import com.example.entity.Component;
import com.example.service.ComponentService;

@RestController
//@CrossOrigin("http://localhost:8080")
@RequestMapping("/components")
public class ComponentController {
	@Autowired
    private ComponentService componentService;

//    @GetMapping("/alldata")
//    public List<Component> getAllComponents() {
//        return componentService.getAllComponents();
//    }
//
//    @PostMapping("/save")
//    public Component saveComponent(@RequestBody Component component) {
//        return componentService.saveComponent(component);
//    }
    
    @GetMapping("/get/{id}")
    public Component getComponentById(@PathVariable int id) {
        return componentService.getComponentById(id);
    }
    
    @GetMapping("/all")
    public List<ComponentDTO> getAllComponents() { // Now returns a List of DTOs
        return componentService.getAllComponentsDTO();
    }

   
    
    

}
