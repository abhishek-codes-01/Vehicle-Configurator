using System.Collections.Generic;
using Vehicle_Configurator.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace Vehicle_Configurator.Application.Interfaces
{
    public interface IModelRepository
    {
        Task<ActionResult<IEnumerable<Model>>> GetAll();
        Task<ActionResult<Model>> GetById(int id);
        Task<ActionResult<IEnumerable<Model>>> GetByManufacturerId(int manufacturerId);
        Task<ActionResult<IEnumerable<Model>>> GetBySegmentId(int segmentId);
        Task<ActionResult<IEnumerable<Model>>> GetBySegmentAndManufacturerId(int segmentId, int manufacturerId);
        Task Add(Model model);
        Task Update(Model model);
        Task Delete(int id);

    }
}
