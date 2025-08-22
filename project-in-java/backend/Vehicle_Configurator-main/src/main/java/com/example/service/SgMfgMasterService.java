package com.example.service;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.entity.Manufacturer;
import com.example.entity.Segment;
import com.example.entity.SgMfgMaster;
import com.example.repository.ManufacturerRepository;
import com.example.repository.SegmentRepository;
import com.example.repository.SgMfgMasterRepository;

@Service
public class SgMfgMasterService {
	@Autowired
	private SgMfgMasterRepository repo;
	
	public List<SgMfgMaster> findAll() {
		return repo.findAll();
	}
	
	public Optional<SgMfgMaster> findById(int id) {
	return repo.findById(id);	
	}
	
	 @Autowired
	    private ManufacturerRepository manufacturerRepository;

	    @Autowired
	    private SegmentRepository segmentRepository;

	    @Autowired
	    private SgMfgMasterRepository sgMfgMasterRepository;

	    public void mapManufacturerToSegment(Integer mfgId, Integer segId) {
	       Manufacturer manufacturer = manufacturerRepository.findById(mfgId).orElseThrow();
	       Segment segment = segmentRepository.findById(segId).orElseThrow();

	        SgMfgMaster mapping = new SgMfgMaster();
	        mapping.setMfg_id(manufacturer);
	        mapping.setSeg_id(segment);

	        sgMfgMasterRepository.save(mapping);
	    }
	    
	    public List<SgMfgMaster> getAllSgMfgMasters() {
	        return sgMfgMasterRepository.findAll();
	    }

	    public SgMfgMaster saveSgMfgMaster(SgMfgMaster sgMfgMaster) {
	        return sgMfgMasterRepository.save(sgMfgMaster);
	    }
	    
	    public List<Manufacturer> getSgMfgMastersBySegmentId(int segId) {
	        return sgMfgMasterRepository.findManufacturersBySegmentId(segId);
	    }

	
}
