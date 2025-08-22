package com.example.dtos;

public class AlternateComponentMasterDTO {
    private int altId;
    private double deltaPrice;
    private int compId; 
    private int altCompId; 
    private String altCompName;

    public AlternateComponentMasterDTO(int altId, double deltaPrice, int compId, int altCompId, String altCompName) {
        this.altId = altId;
        this.deltaPrice = deltaPrice;
        this.compId = compId;
        this.altCompId = altCompId;
        this.altCompName = altCompName;
    }

    public AlternateComponentMasterDTO() {}

    public int getAltId() {
        return altId;
    }

    public void setAltId(int altId) {
        this.altId = altId;
    }

    public double getDeltaPrice() {
        return deltaPrice;
    }

    public void setDeltaPrice(double deltaPrice) {
        this.deltaPrice = deltaPrice;
    }

    public int getCompId() {
        return compId;
    }

    public void setCompId(int compId) {
        this.compId = compId;
    }

    public int getAltCompId() {
        return altCompId;
    }

    public void setAltCompId(int altCompId) {
        this.altCompId = altCompId;
    }

    public String getAltCompName() {
        return altCompName;
    }

    public void setAltCompName(String altCompName) {
        this.altCompName = altCompName;
    }
}