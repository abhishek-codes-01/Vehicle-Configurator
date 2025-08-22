package com.vehicleconfig.vehicle_details_service.dtos;

public class VehicleDetailDTO {
    private int config_id;
    private int comp_id;
    private String comp_name;
    private String comp_type;
    private String isConfig;
    private int model_id;

    public VehicleDetailDTO() {
    }

    public VehicleDetailDTO(int config_id, int comp_id, String comp_name, String comp_type, String isConfig, int model_id) {
        this.config_id = config_id;
        this.comp_id = comp_id;
        this.comp_name = comp_name;
        this.comp_type = comp_type;
        this.isConfig = isConfig;
        this.model_id = model_id;
    }

    // Getters and setters - exactly same as your current DTO
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

    public String getComp_name() {
        return comp_name;
    }

    public void setComp_name(String comp_name) {
        this.comp_name = comp_name;
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
