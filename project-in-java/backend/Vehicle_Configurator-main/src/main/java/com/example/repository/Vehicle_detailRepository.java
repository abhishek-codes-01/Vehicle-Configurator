package com.example.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import com.example.entity.Vehicle_detail;

@Repository
public interface Vehicle_detailRepository extends JpaRepository<Vehicle_detail, Integer> {

    @Query(value = "select * from vehicle_detail where comp_id=:compId", nativeQuery = true)
    List<Vehicle_detail> findVehicle_detailByComponentId(@Param("compId") Integer compId);

    @Query(value = "select * from vehicle_detail where model_id=:modelId", nativeQuery = true)
    List<Vehicle_detail> findVehicle_detailByModelId(@Param("modelId") Integer modelId);

}
