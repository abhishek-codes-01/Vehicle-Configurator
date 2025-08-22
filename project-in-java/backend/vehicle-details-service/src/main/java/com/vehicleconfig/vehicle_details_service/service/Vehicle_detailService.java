package com.vehicleconfig.vehicle_details_service.service;

import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.vehicleconfig.vehicle_details_service.dtos.VehicleDetailDTO;
import com.vehicleconfig.vehicle_details_service.entity.Vehicle_detail;
import com.vehicleconfig.vehicle_details_service.repository.Vehicle_detailRepository;

@Service
public class Vehicle_detailService {

    @Autowired
    private Vehicle_detailRepository vehicleDetailRepo;

    public List<Vehicle_detail> findVehicle_detailByComponentId(int compId) {
        return vehicleDetailRepo.findVehicle_detailByComponentId(compId);
    }

    public List<VehicleDetailDTO> getVehicleDetailsByModelId(int modelId) {
        List<Vehicle_detail> details = vehicleDetailRepo.findVehicle_detailByModelId(modelId);
        List<VehicleDetailDTO> dtos = new ArrayList<>();

        for (Vehicle_detail vd : details) {
            dtos.add(new VehicleDetailDTO(
                vd.getConfig_id(),
                vd.getComp_id(),
                null, // comp_name will be null for now (no Component entity relationship)
                vd.getComp_type(),
                vd.getIsConfig(),
                vd.getModel_id()
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
}
