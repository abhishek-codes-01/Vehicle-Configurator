package com.example.aop;

import org.aspectj.lang.ProceedingJoinPoint;
import org.aspectj.lang.annotation.Around;
import org.aspectj.lang.annotation.Aspect;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Component;

@Component
@Aspect
public class PerformanceMonitorAspect {
	
	private static final Logger LOGGER = LoggerFactory.getLogger(PerformanceMonitorAspect.class);
	
	
	//return type fully classified class-name.method name(args) 
	@Around("execution(* com.example.service.ModelService.findModelByManufacturerId(..))")
	public Object monitorTime(ProceedingJoinPoint Jp) throws Throwable
	{
		
		long start = System.currentTimeMillis();  //This we want to execute before method call
		
		Object obj = Jp.proceed();
		
		long end = System.currentTimeMillis();  //This we want to execute after method executed
		
		LOGGER.info("Time Taken : "+ (end-start)+" ms");
		
		return obj;
		
	}

}
