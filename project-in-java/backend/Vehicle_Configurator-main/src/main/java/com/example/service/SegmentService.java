package com.example.service;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.entity.Segment;
import com.example.repository.SegmentRepository;

@Service
public class SegmentService{
	
	@Autowired
	private SegmentRepository repo;
	
	
	public List<Segment> findAll() {
		return repo.findAll();
	}

	public Optional<Segment> findById(Integer sg_id) {
		return repo.findById(sg_id);
	}
	
	public Segment saveSegment(Segment segment) {
        return repo.save(segment);
    }
}
