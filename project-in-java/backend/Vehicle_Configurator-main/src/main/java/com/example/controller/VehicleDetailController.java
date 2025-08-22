package com.example.controller;

import com.example.dtos.VehicleDetailDTO;
import com.example.entity.Vehicle_detail;
import com.example.service.VehicleDetailClientService;
import com.example.service.Vehicle_detailService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/vehicle_details")
public class VehicleDetailController {

    @Autowired
    private VehicleDetailClientService microserviceClient; // Microservice client

    @Autowired
    private Vehicle_detailService vehicleDetailService;     // Local service backup

    // Toggle between microservice and local service
    private boolean useMicroservice = true; // default: true

    @GetMapping("/component/{id}")
    public ResponseEntity<List<Vehicle_detail>> getVehicleDetailsByComponentId(@PathVariable int id) {
        List<Vehicle_detail> details = useMicroservice
            ? microserviceClient.fetchVehicleDetailsByComponentId(id)
            : vehicleDetailService.findVehicle_detailByComponentId(id);

        if (details == null || details.isEmpty()) {
            return ResponseEntity.noContent().build();
        }
        return ResponseEntity.ok(details);
    }

    @GetMapping("/model/{id}")
    public ResponseEntity<List<VehicleDetailDTO>> getVehicleDetailsByModelId(@PathVariable int id) {
        List<VehicleDetailDTO> details = useMicroservice
            ? microserviceClient.fetchVehicleDetailsByModelId(id)
            : vehicleDetailService.getVehicleDetailsByModelId(id);

        if (details == null || details.isEmpty()) {
            return ResponseEntity.noContent().build();
        }
        return ResponseEntity.ok(details);
    }

    @GetMapping("/all")
    public ResponseEntity<List<Vehicle_detail>> getAllVehicleDetails() {
        List<Vehicle_detail> details = useMicroservice
            ? microserviceClient.fetchAllVehicleDetails()
            : vehicleDetailService.getAllVehicleDetails();

        if (details == null || details.isEmpty()) {
            return ResponseEntity.noContent().build();
        }
        return ResponseEntity.ok(details);
    }



    // Endpoint to toggle between microservice and local service
    @PostMapping("/toggle-service")
    public ResponseEntity<String> toggleService() {
        useMicroservice = !useMicroservice;
        String active = useMicroservice ? "Microservice" : "Local Service";
        return ResponseEntity.ok("Now using: " + active);
    }
}
