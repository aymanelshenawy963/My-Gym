using GymManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagement.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        
        IGenericRepository<T> Repository<T>() where T : BaseEntity;

        Task<int> CompleteAsync();
    }
}
