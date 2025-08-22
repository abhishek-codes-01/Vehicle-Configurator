package com.example.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import com.example.entity.Model;

@Repository
public interface ModelRepository extends JpaRepository<Model, Integer>{
	@Query(value="select * from model where mfg_id=:mfgId",nativeQuery = true)
	List<Model> findModelByManufacturerId(@Param("mfgId") Integer mfgId);
	
	@Query(value="select * from model where seg_id=:segId",nativeQuery = true)
	List<Model> findModelBySegmentId(@Param("segId") Integer segId);
	
	@Query(value="select * from model where seg_id=:segId and mfg_id =:mfgId", nativeQuery = true)
	List<Model> findBySfMfgId(@Param("segId") int segId, @Param("mfgId") int mfgId);
}
