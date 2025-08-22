using System.Collections.Generic;
using Vehicle_Configurator.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace Vehicle_Configurator.Application.Interfaces
{
    public interface ISegmentRepository
    {
        Task<ActionResult<IEnumerable<Segment>>> GetAll();
        Task<ActionResult<Segment>> GetById(int id);
        Task Add(Segment segment);
        Task Update(Segment segment);
        Task Delete(int id);
    }
}
