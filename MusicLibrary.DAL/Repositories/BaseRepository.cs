﻿using Microsoft.EntityFrameworkCore;
using MusicLibrary.DAL.Entities;
using MusicLibrary.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected MusicLibraryContext Context { get; set; }
        protected DbSet<T> DbSet { get; set; }

        public BaseRepository(MusicLibraryContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
            {
                return DbSet.Where(filter);
            }
            return DbSet;
        }

        public T GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public void Insert(T entity)
        {
            DbSet.Add(entity);
        }

        public async Task InsertAndSaveAsync(T entity)
        {
            DbSet.Add(entity);
            await SaveChangesAsync();
        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);

            if (entity == null)
                throw new ArgumentException();

            DbSet.Remove(entity);
        }

        public async Task DeleteAndSaveAsync(Guid id)
        {
            Delete(id);

            await SaveChangesAsync();
        }


        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentException();

            var itemFromDB = GetById(entity.Id);

            Context.Entry(itemFromDB).State = EntityState.Detached;
            Context.Entry(entity).State = EntityState.Modified;
        }

        public async Task UpdateAndSaveAsync(T entity)
        {
            Update(entity);

            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }

        
    }
}
