package com.example.controller;

import com.example.entity.Manufacturer;
import com.example.entity.SgMfgMaster;
import com.example.service.SgMfgMasterService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
//@CrossOrigin("http://localhost:8080")
@RequestMapping("/api/sgmfg")
public class SgMfgMasterController {

    @Autowired
    private SgMfgMasterService sgMfgMasterService;

    @GetMapping("/all")
    public List<SgMfgMaster> getAllSgMfgMasters() {
        return sgMfgMasterService.getAllSgMfgMasters();
    }

    @PostMapping("/save")
    public SgMfgMaster saveSgMfgMaster(@RequestBody SgMfgMaster sgMfgMaster) {
        return sgMfgMasterService.saveSgMfgMaster(sgMfgMaster);
    }
    
    @GetMapping("/get/{segId}")
    public List<Manufacturer> getSgMfgMastersBySegmentId(@PathVariable int segId) {
        return sgMfgMasterService.getSgMfgMastersBySegmentId(segId);
    }


}
