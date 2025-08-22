package com.example.aop;

import org.aspectj.lang.ProceedingJoinPoint;
import org.aspectj.lang.annotation.Around;
import org.aspectj.lang.annotation.Aspect;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Component;

@Component
@Aspect
public class ValidationAspect {
	
	private static final Logger LOGGER = LoggerFactory.getLogger(ValidationAspect.class);
	
	@Around("execution(* com.example.service.ModelService.findModelByManufacturerId(..)) && args(mfgId)") 
	public Object validateAndUpdate(ProceedingJoinPoint Jp,int mfgId) throws Throwable
	{
		if(mfgId < 0)
		{
			LOGGER.info("MfgId is Negative , Updating it");
			mfgId = -mfgId;
			LOGGER.info("New Value : "+mfgId);
		}
		
		Object obj = Jp.proceed(new Object[] {mfgId});
		
		return obj;
	}

}
