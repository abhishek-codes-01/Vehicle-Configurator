using System.Collections.Generic;
using Vehicle_Configurator.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace Vehicle_Configurator.Application.Interfaces
{
    public interface IVehicleDetailRepository
    {
        Task<ActionResult<IEnumerable<VehicleDetail>>> GetByComponentId(int componentId);
        Task<ActionResult<IEnumerable<VehicleDetail>>> GetByModelId(int modelId);
    }
}
