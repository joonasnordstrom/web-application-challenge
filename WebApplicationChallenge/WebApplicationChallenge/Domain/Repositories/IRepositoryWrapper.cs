using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VincitWebApplication.Domain.Repositories
{
    public interface IRepositoryWrapper
    {
        ICubesensorsDatumRepository Sensor { get; }
        Task CompleteAsync();
    }
}
