package com.example.controller;

import com.example.entity.Invoice_header;
import com.example.service.Invoice_headerService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
//@CrossOrigin("http://localhost:8080")
@RequestMapping("/api/invoice-headers")
public class InvoiceHeaderController {

    @Autowired
    private Invoice_headerService invoiceHeaderService;
    
    @GetMapping("/model/{id}")
    public ResponseEntity<Invoice_header> getInvoiceHeaderByModelId(@PathVariable int id) {
        Invoice_header header = invoiceHeaderService.findInvoice_headerByModelId(id);

        if (header == null) {
            return ResponseEntity.notFound().build();
        }

        return ResponseEntity.ok(header);
    }

    @GetMapping("/all")
    public List<Invoice_header> getAllInvoiceHeaders() {
        return invoiceHeaderService.getAllInvoiceHeaders();
    }
    
    @PostMapping("/save")
    public Invoice_header saveInvoiceHeader(@RequestBody Invoice_header invoiceHeader) {
        return invoiceHeaderService.saveInvoiceHeader(invoiceHeader);
    }
    
    @GetMapping("/get/{id}")
    public Invoice_header getInvoiceHeaderById(@PathVariable int id) {
        return invoiceHeaderService.getInvoiceHeaderById(id);
    }

}
