using System.Collections.Generic;
using Vehicle_Configurator.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace Vehicle_Configurator.Application.Interfaces
{
    public interface IManufacturerRepository
    {
        Task<ActionResult<IEnumerable<Manufacturer>>> GetAll();
        Task<ActionResult<Manufacturer>> GetById(int id);
        Task Add(Manufacturer manufacturer);
        Task Update(Manufacturer manufacturer);
        Task Delete(int id);

        
    }
}
