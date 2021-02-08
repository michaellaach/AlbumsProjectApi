using Microsoft.EntityFrameworkCore;
using MusicLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MusicLibrary.DAL.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Delete(Guid id);
        Task DeleteAndSaveAsync(Guid id);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null);
        T GetById(Guid id);
        void Insert(T entity);
        Task InsertAndSaveAsync(T entity);
        Task SaveChangesAsync();
        void Update(T entity);
        Task UpdateAndSaveAsync(T entity);
    }
}