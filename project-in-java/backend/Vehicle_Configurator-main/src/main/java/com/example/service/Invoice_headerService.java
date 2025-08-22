package com.example.service;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.entity.Invoice_header;
import com.example.repository.Invoice_headerRepository;

@Service
public class Invoice_headerService {
	@Autowired
	private Invoice_headerRepository repo;
	
	public Invoice_header findInvoice_headerByModelId(int id) {
		return repo.findInvoice_headerByModelId(id);
	}
	
	public Optional<Invoice_header> findById(int id) {
		return repo.findById(id);
	}
	
	public List<Invoice_header> getAllInvoiceHeaders() {
        return repo.findAll();
    }

    public Invoice_header saveInvoiceHeader(Invoice_header invoiceHeader) {
        return repo.save(invoiceHeader);
    }
    
    public Invoice_header getInvoiceHeaderById(int id) {
        return repo.findById(id)
            .orElseThrow(() -> new RuntimeException("Invoice Header not found with id: " + id));
    }
}
