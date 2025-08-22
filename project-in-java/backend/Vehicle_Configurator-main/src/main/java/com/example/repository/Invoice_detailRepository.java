package com.example.repository;


import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;

import com.example.entity.Invoice_detail;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

@Repository
public interface Invoice_detailRepository extends JpaRepository<Invoice_detail, Integer>{
		@Query(value="select * from invoice_detail where invDtl_id=:invdId",nativeQuery = true)
		List<Invoice_detail> findInvoice_detailById(@Param("invdId") Integer invdId);
		
		@Query(value="select * from invoice_detail where comp_id=:compId",nativeQuery = true)
		List<Invoice_detail> findInvoice_detailsByCompId(@Param("compId") Integer compId);
}
