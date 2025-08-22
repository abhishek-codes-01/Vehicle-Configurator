package com.example.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import com.example.entity.Invoice_header;

@Repository
public interface Invoice_headerRepository extends JpaRepository<Invoice_header, Integer>{
	@Query(value="select * from invoice_header where model_id=:mdId",nativeQuery = true)
	Invoice_header findInvoice_headerByModelId(@Param("mdId") Integer mdId);
	
	@Query(value="select * from invoice_header where inv_id=:invhId",nativeQuery = true)
	Invoice_header findInvoice_headerById(@Param("invhId") Integer invhId);
}
