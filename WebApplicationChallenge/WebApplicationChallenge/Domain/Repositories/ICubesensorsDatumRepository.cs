using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VincitWebApplication.Domain.Models;
using VincitWebApplication.DTOs;

namespace VincitWebApplication.Domain.Repositories
{
    public interface ICubesensorsDatumRepository : IBaseRepository<CubesensorsDatum>
    {
        Task<List<SummaryDTO>> SummaryAsync();
        Task<CubesensorsDatum> FindLatestByIdAsync(string id);
    }
}
