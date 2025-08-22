package com.example.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import com.example.entity.Manufacturer;

@Repository
public interface ManufacturerRepository extends JpaRepository<Manufacturer, Integer>{
	@Query(value="select * from manufacturer where seg_id=:segId",nativeQuery = true)
	List<Manufacturer> findManufacturersBySegmentId(@Param("segId") Integer segId);
}