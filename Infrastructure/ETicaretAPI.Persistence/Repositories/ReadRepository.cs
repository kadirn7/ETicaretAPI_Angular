﻿using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity, IBaseEntity, new()
    {
        private readonly ETicaretDbContext _context;

        public ReadRepository(ETicaretDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracing = true) 
        {
            var query=Table.AsQueryable();
            if(!tracing)
                query=query.AsNoTracking();
            return query;
        }
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracing = true)
        {
            var query=Table.Where(method);
            if(!tracing) query=query.AsNoTracking();
            return query;
        }
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracing = true)
        {
            var query = Table.AsQueryable();
            if(!tracing) query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }


        public async Task<T> GetByIdAsync(string id, bool tracing = true)
        //=> await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        {
            var query = Table.AsQueryable();
            if(!tracing)
                query=Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(data=>data.Id == Guid.Parse(id));   
        }
        
    }
}
