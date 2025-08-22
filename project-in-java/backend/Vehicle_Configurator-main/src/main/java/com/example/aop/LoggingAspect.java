package com.example.aop;

import org.aspectj.lang.JoinPoint;
import org.aspectj.lang.annotation.After;
import org.aspectj.lang.annotation.AfterReturning;
import org.aspectj.lang.annotation.AfterThrowing;
import org.aspectj.lang.annotation.Aspect;
import org.aspectj.lang.annotation.Before;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Component;

@Component
@Aspect
public class LoggingAspect {
	
	private static final Logger LOGGER = LoggerFactory.getLogger(LoggingAspect.class);
	
	/* -----For Finding Model ID By Manufacturer ID----- */
	
	//return type fully classified class-name.method name(args) 
	@Before("execution(* com.example.service.ModelService.findModelByManufacturerId(..))")  
	public void logMethodCallmfg(JoinPoint Jp) 
	{
		LOGGER.info("Method Called : "+ Jp.getSignature().getName());
	}
	
	@After("execution(* com.example.service.ModelService.findModelByManufacturerId(..))")  
	public void logMethodExecutedmfg(JoinPoint Jp) 
	{
		LOGGER.info("Method Executed : "+ Jp.getSignature().getName());
	}
	
	@AfterThrowing("execution(* com.example.service.ModelService.findModelByManufacturerId(..))")  
	public void logMethodCrashedmfg(JoinPoint Jp) 
	{
		LOGGER.info("Method has some issues : "+ Jp.getSignature().getName());
	}
	
	@AfterReturning("execution(* com.example.service.ModelService.findModelByManufacturerId(..))")  
	public void logMethodExecutedSuccessmfg(JoinPoint Jp) 
	{
		LOGGER.info("Method Executed Successfully : "+ Jp.getSignature().getName());
	}
	
	
	/* -----For Finding Model ID By Segment ID----- */
	
	//return type fully classified class-name.method name(args) 
		@Before("execution(* com.example.service.ModelService.findModelBySegmentId(..))")  
		public void logMethodCallsg(JoinPoint Jp) 
		{
			LOGGER.info("Method Called : "+ Jp.getSignature().getName());
		}
		
		@After("execution(* com.example.service.ModelService.findModelBySegmentId(..))")  
		public void logMethodExecutedsg(JoinPoint Jp) 
		{
			LOGGER.info("Method Executed : "+ Jp.getSignature().getName());
		}
		
		@AfterThrowing("execution(* com.example.service.ModelService.findModelBySegmentId(..))")  
		public void logMethodCrashedsg(JoinPoint Jp) 
		{
			LOGGER.info("Method has some issues : "+ Jp.getSignature().getName());
		}
		
		@AfterReturning("execution(* com.example.service.ModelService.findModelBySegmentId(..))")  
		public void logMethodExecutedSuccesssg(JoinPoint Jp) 
		{
			LOGGER.info("Method Executed Successfully : "+ Jp.getSignature().getName());
		}

}
