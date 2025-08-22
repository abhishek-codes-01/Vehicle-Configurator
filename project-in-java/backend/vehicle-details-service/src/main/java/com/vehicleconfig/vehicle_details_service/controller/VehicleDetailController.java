package com.vehicleconfig.vehicle_details_service.controller;

import com.vehicleconfig.vehicle_details_service.dtos.VehicleDetailDTO;
import com.vehicleconfig.vehicle_details_service.entity.Vehicle_detail;
import com.vehicleconfig.vehicle_details_service.service.Vehicle_detailService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/vehicle-details")
public class VehicleDetailController {

    @Autowired
    private Vehicle_detailService vehicleDetailService;
    
    @GetMapping("/")
    public String home() {
        return "App is running!";
    }
    
    @GetMapping("/component/{id}")
    public ResponseEntity<List<Vehicle_detail>> getVehicleDetailsByComponentId(@PathVariable int id) {
        List<Vehicle_detail> details = vehicleDetailService.findVehicle_detailByComponentId(id);

        if (details.isEmpty()) {
            return ResponseEntity.noContent().build();
        }

        return ResponseEntity.ok(details);
    }

    @GetMapping("/model/{id}")
    public ResponseEntity<List<VehicleDetailDTO>> getVehicleDetailsByModelId(@PathVariable int id) {
        List<VehicleDetailDTO> details = vehicleDetailService.getVehicleDetailsByModelId(id);

        if (details.isEmpty()) {
            return ResponseEntity.noContent().build();
        }

        return ResponseEntity.ok(details);
    }

    @GetMapping("/all")
    public List<Vehicle_detail> getAllVehicleDetails() {
        return vehicleDetailService.getAllVehicleDetails();
    }

    @GetMapping("/{id}")
    public Vehicle_detail getVehicleDetailById(@PathVariable int id) {
        return vehicleDetailService.getVehicleDetailById(id);
    }
    
    @GetMapping("/health")
    public String healthCheck() {
        return "Vehicle Details Microservice is running! 🚗";
    }
}
