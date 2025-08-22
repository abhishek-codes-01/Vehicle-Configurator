package com.example.dtos;

public class ComponentDTO {
    private int compId;
    private String compName;
    
    public ComponentDTO(int compId, String compName) {
        this.compId = compId;
        this.compName = compName;
    }

    public ComponentDTO() {}

    public int getCompId() {
        return compId;
    }

    public void setCompId(int compId) {
        this.compId = compId;
    }

    public String getCompName() {
        return compName;
    }

    public void setCompName(String compName) {
        this.compName = compName;
    }
}