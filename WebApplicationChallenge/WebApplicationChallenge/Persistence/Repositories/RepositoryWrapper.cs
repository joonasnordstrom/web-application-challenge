using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VincitWebApplication.Domain.Repositories;
using VincitWebApplication.Persistence.Contexts;

namespace VincitWebApplication.Persistence.Repositories
{
    /// <summary>
    /// All common repositories can be found here.
    /// Also works as an unit of work, handling database updates.
    /// </summary>
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly iot_dbContext _context;
        public ICubesensorsDatumRepository _sensor;

        public ICubesensorsDatumRepository Sensor
        {
            get
            {
                if (_sensor == null)
                {
                    _sensor = new CubesensorsDatumRepository(_context);
                }
                return _sensor;
            }
        }

        public RepositoryWrapper(iot_dbContext repositoryContext)
        {
            _context = repositoryContext;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
