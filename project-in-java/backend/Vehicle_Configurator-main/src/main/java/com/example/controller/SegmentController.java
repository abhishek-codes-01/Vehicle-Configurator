package com.example.controller;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.example.entity.Segment;
import com.example.service.SegmentService;

@RestController
//@CrossOrigin("http://localhost:8080")
@RequestMapping("/segments")
public class SegmentController {
	private final SegmentService service;
	
	
	public SegmentController(SegmentService serv) {
		this.service = serv;
	}
	
	@GetMapping
	public ResponseEntity<List<Segment>> getAllSegments(){
		List<Segment> segments = service.findAll();
		return ResponseEntity.ok(segments);
	}
	
	@PostMapping("/save")
    public Segment saveSegment(@RequestBody Segment segment) {
        return service.saveSegment(segment);
    }

	
	@GetMapping("/{seg_id}")
	public ResponseEntity<Optional<Segment>> getSegmentById(@PathVariable("seg_id") int id){
		Optional<Segment> segment = service.findById(id);
		return ResponseEntity.ok(segment);
	}
}
