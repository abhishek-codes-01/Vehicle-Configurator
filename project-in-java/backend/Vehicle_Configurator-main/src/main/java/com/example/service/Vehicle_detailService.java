package com.example.service;

import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.dtos.VehicleDetailDTO;
import com.example.entity.Alternate_Component_Master;
import com.example.entity.Vehicle_detail;
import com.example.repository.Alternate_Component_MasterRepository;
import com.example.repository.Vehicle_detailRepository;

@Service
public class Vehicle_detailService {

    @Autowired
    private Vehicle_detailRepository vehicleDetailRepo;

    @Autowired
    private Alternate_Component_MasterRepository altRepo;

    public List<Vehicle_detail> findVehicle_detailByComponentId(int compId) {
        return vehicleDetailRepo.findVehicle_detailByComponentId(compId);
    }

    public List<VehicleDetailDTO> getVehicleDetailsByModelId(int modelId) {
        List<Vehicle_detail> details = vehicleDetailRepo.findVehicle_detailByModelId(modelId);
        List<VehicleDetailDTO> dtos = new ArrayList<>();

        for (Vehicle_detail vd : details) {
            dtos.add(new VehicleDetailDTO(
                vd.getConfig_id(),
                vd.getComponent() != null ? vd.getComponent().getComp_id() : 0,
                vd.getComponent() != null ? vd.getComponent().getComp_name() : null,
                vd.getComp_type() != null ? vd.getComp_type().toString() : null,
                vd.getIsConfig(),
                vd.getModel() != null ? vd.getModel().getModel_id() : 0
            ));
        }
        return dtos;
    }

    
    public List<Vehicle_detail> getAllVehicleDetails() {
        return vehicleDetailRepo.findAll();
    }

    
    public Vehicle_detail getVehicleDetailById(int id) {
        return vehicleDetailRepo.findById(id).orElse(null);
    }

    public List<Alternate_Component_Master> getAlternateComponentsByModelId(int modelId) {
        return altRepo.findByModel_ModelId(modelId);
    }
}
