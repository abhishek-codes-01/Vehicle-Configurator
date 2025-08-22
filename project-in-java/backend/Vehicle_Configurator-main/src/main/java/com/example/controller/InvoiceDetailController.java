package com.example.controller;

import com.example.entity.Invoice_detail;
import com.example.service.Invoice_detailService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
//@CrossOrigin("http://localhost:8080")
@RequestMapping("/api/invoice-details")
public class InvoiceDetailController {

    @Autowired
    private Invoice_detailService invoiceDetailService;
    
    @GetMapping("/invoice/{id}")
    public ResponseEntity<List<Invoice_detail>> getInvoiceDetailsByInvoiceId(@PathVariable int id) {
        List<Invoice_detail> details = invoiceDetailService.findInvoice_detailById(id);

        if (details.isEmpty()) {
            return ResponseEntity.noContent().build();
        }

        return ResponseEntity.ok(details);
    }

    
    @GetMapping("/component/{id}")
    public ResponseEntity<List<Invoice_detail>> getInvoiceDetailsByComponentId(@PathVariable int id) {
        List<Invoice_detail> details = invoiceDetailService.findInvoice_detailsByCompId(id);

        if (details.isEmpty()) {
            return ResponseEntity.noContent().build();
        }

        return ResponseEntity.ok(details);
    }

    @GetMapping("/all")
    public List<Invoice_detail> getAllInvoiceDetails() {
        return invoiceDetailService.getAllInvoiceDetails();
    }

    @PostMapping("/save")
    public Invoice_detail saveInvoiceDetail(@RequestBody Invoice_detail invoiceDetail) {
        return invoiceDetailService.saveInvoiceDetail(invoiceDetail);
    }
    
//    @GetMapping("/get/{id}")
//    public Invoice_detail getInvoiceDetailById(@PathVariable int id) {
//        return invoiceDetailService.getInvoiceDetailById(id);
//    }

}
