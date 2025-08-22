package com.vehicleconfig.vehicle_details_service.entity;

import jakarta.persistence.*;

@Entity
@Table(name = "vehicle_detail")
public class Vehicle_detail {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int config_id;

    @Column(name = "comp_id")
    private int comp_id;

    @Column(name = "comp_type")  
    private String comp_type;

    @Column(name = "is_config")
    private String isConfig;

    @Column(name = "model_id")
    private int model_id;

    // Default constructor
    public Vehicle_detail() {}

    // Constructor
    public Vehicle_detail(int comp_id, String comp_type, String isConfig, int model_id) {
        this.comp_id = comp_id;
        this.comp_type = comp_type;
        this.isConfig = isConfig;
        this.model_id = model_id;
    }

    // Getters and Setters - matching your exact naming style
    public int getConfig_id() {
        return config_id;
    }

    public void setConfig_id(int config_id) {
        this.config_id = config_id;
    }

    public int getComp_id() {
        return comp_id;
    }

    public void setComp_id(int comp_id) {
        this.comp_id = comp_id;
    }

    public String getComp_type() {
        return comp_type;
    }

    public void setComp_type(String comp_type) {
        this.comp_type = comp_type;
    }

    public String getIsConfig() {
        return isConfig;
    }

    public void setIsConfig(String isConfig) {
        this.isConfig = isConfig;
    }

    public int getModel_id() {
        return model_id;
    }

    public void setModel_id(int model_id) {
        this.model_id = model_id;
    }
}
