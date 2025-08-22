using System.Collections.Generic;
using Vehicle_Configurator.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace Vehicle_Configurator.Application.Interfaces
{
    public interface ISgMfgMasterRepository
    {
        Task<ActionResult<IEnumerable<Manufacturer>>> GetManufacturersBySegmentId(int segmentId);
    }
}
