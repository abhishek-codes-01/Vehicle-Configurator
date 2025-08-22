package com.example.service;

import com.example.dtos.VehicleDetailDTO;
import com.example.entity.Vehicle_detail;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.core.ParameterizedTypeReference;
import org.springframework.http.*;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;

import java.util.List;

@Service
public class VehicleDetailClientService {

	private static final String BASE_URL = "http://localhost:8082/api/vehicle-details";



    @Autowired
    private RestTemplate restTemplate;

    // 1. Get all vehicle details
    public List<Vehicle_detail> fetchAllVehicleDetails() {
        ResponseEntity<List<Vehicle_detail>> response = restTemplate.exchange(
            BASE_URL + "/all",
            HttpMethod.GET,
            null,
            new ParameterizedTypeReference<List<Vehicle_detail>>() {}
        );
        return response.getBody();
    }

    // 2. Get details by model ID
    public List<VehicleDetailDTO> fetchVehicleDetailsByModelId(int modelId) {
        ResponseEntity<List<VehicleDetailDTO>> response = restTemplate.exchange(
            BASE_URL + "/model/" + modelId,
            HttpMethod.GET,
            null,
            new ParameterizedTypeReference<List<VehicleDetailDTO>>() {}
        );
        return response.getBody();
    }

    // 3. Get details by component ID
    public List<Vehicle_detail> fetchVehicleDetailsByComponentId(int compId) {
        ResponseEntity<List<Vehicle_detail>> response = restTemplate.exchange(
            BASE_URL + "/component/" + compId,
            HttpMethod.GET,
            null,
            new ParameterizedTypeReference<List<Vehicle_detail>>() {}
        );
        return response.getBody();
    }
}
