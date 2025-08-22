package com.example.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import com.example.entity.Component;

@Repository
public interface ComponentRepository extends JpaRepository<Component, Integer>{
	
	@Query(value="select c.* from component join vehicle_detail v on c.comp_id=v.comp_id where v.model_id=mdId",nativeQuery = true)
	List<Component> findComponentByModelId(@Param("mdID") Integer mdId);
}
