package com.example.service;

import java.util.List;
import java.util.stream.Collectors;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.example.dtos.AlternateComponentMasterDTO;
import com.example.entity.Alternate_Component_Master;
import com.example.repository.Alternate_Component_MasterRepository;

@Service
public class Alternate_Component_MasterService {
	@Autowired
	private Alternate_Component_MasterRepository repo;
	
	 public List<Alternate_Component_Master> findAltCompByModelId(int id) {
	        return repo.findAltCompByModelId(id);
	    }
	 	
	 public List<Alternate_Component_Master> findAltCompByModelIdAndComponentId(int modl_id,int comp_id) {
	        return repo.findAltCompByModelIdAndComponentId(modl_id, comp_id);
	    }

	 
	    public List<Alternate_Component_Master> getAllAlternateComponents() {
	        return repo.findAll();
	    }

	    public Alternate_Component_Master saveAlternateComponent(Alternate_Component_Master altComponent) {
	        return repo.save(altComponent);
	    }

	    public Alternate_Component_Master getAlternateComponentById(int id) {
	        return repo.findById(id)
	            .orElseThrow(() -> new RuntimeException("Alternate Component not found with id: " + id));
	    }

	    @Transactional
	    public List<AlternateComponentMasterDTO> getAllAlternateComponentsDTO() {
	        List<Alternate_Component_Master> alternateComponents = repo.findAll();
	        return alternateComponents.stream()
	                .map(altComp -> new AlternateComponentMasterDTO(
	                    altComp.getAlt_id(),
	                    altComp.getDelta_price(),
	                    altComp.getComponent().getComp_id(), 
	                    altComp.getAltComponent().getComp_id(), 
	                    altComp.getAltComponent().getComp_name()
	                ))
	                .collect(Collectors.toList());
	    }

	    @Transactional
	    public AlternateComponentMasterDTO getAlternateComponentByIdDTO(int id) {
	        Alternate_Component_Master altComponent = repo.findById(id).orElse(null);
	        if (altComponent != null) {
	            return new AlternateComponentMasterDTO(
	                altComponent.getAlt_id(),
	                altComponent.getDelta_price(),
	                altComponent.getComponent().getComp_id(),
	                altComponent.getAltComponent().getComp_id(),
	                altComponent.getAltComponent().getComp_name()
	            );
	        }
	        return null;
	    }

	    
	    @Transactional 
	    public List<AlternateComponentMasterDTO> findAltCompByModelIdDTO(int modelId) {
	        List<Alternate_Component_Master> alternateComponents = repo.findAltCompByModelId(modelId);
	        return alternateComponents.stream()
	                .map(altComp -> new AlternateComponentMasterDTO(
	                    altComp.getAlt_id(),
	                    altComp.getDelta_price(),
	                    altComp.getComponent().getComp_id(),
	                    altComp.getAltComponent().getComp_id(),
	                    altComp.getAltComponent().getComp_name()
	                ))
	                .collect(Collectors.toList());
	    }
	    

}
