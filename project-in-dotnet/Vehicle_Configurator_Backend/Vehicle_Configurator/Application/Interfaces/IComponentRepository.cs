using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vehicle_Configurator.Domain.Entities;

namespace Vehicle_Configurator.Application.Interfaces
{
    public interface IComponentRepository
    {
        Task<ActionResult<IEnumerable<Component>>> GetByModelId(int modelId);
        Task<IEnumerable<Component>> GetAllComps();

    }
}
