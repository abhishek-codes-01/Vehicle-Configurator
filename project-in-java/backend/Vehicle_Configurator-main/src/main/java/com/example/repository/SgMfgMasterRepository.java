package com.example.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import com.example.entity.Manufacturer;
import com.example.entity.SgMfgMaster;

public interface SgMfgMasterRepository extends JpaRepository<SgMfgMaster, Integer>{
	
	@Query(value = """
		    SELECT m.* FROM sg_mfg_master s
		    JOIN manufacturer m ON s.mfg_id = m.mfg_id
		    WHERE s.seg_id = :segId
		    """, nativeQuery = true)
		List<Manufacturer> findManufacturersBySegmentId(@Param("segId") int segId);

	
}
