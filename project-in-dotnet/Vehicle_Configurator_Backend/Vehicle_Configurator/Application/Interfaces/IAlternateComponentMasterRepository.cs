using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vehicle_Configurator.Domain.Entities;

namespace Vehicle_Configurator.Application.Interfaces
{
    public interface IAlternateComponentMasterRepository
    {
        Task<ActionResult<IEnumerable<AlternateComponentMaster>>> GetByModelId(int modelId);
        Task<ActionResult<IEnumerable<AlternateComponentMaster>>> GetByComponentId(int componentId);
        Task<ActionResult<IEnumerable<AlternateComponentMaster>>> GetByModelIdAndComponentId(int modelId, int componentId);
    }
}
