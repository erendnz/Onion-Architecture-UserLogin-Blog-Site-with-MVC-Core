using Blog.Domain.Entities.Abstract;
using Blog.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Blog.Infrastructure.Data;

namespace Blog.Infrastructure.Repositories.Concrete
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IBaseEntity
    {
        private readonly BlogContext _context;
        protected DbSet<TEntity> _dbSet;

        public BaseRepository(BlogContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        //İd verilen nesneyi döndürür
        public async Task<TEntity> BulAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        //Koşulu sağlayan nesne veya nesneleri döndürür
        public async Task<IEnumerable<TEntity>> BulAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        //İstenen sınıfa nesne ekler
        public async Task EkleAsync(TEntity entity)
        {
            entity.EklemeTarih = DateTime.Now;
            entity.KayitDurumu = Domain.Enums.KayitDurumu.Aktif;

            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        //İstenen nesneyi günceller
        public async Task<bool> GuncelleAsync(TEntity entity)
        {
            entity.GuncellemeTarihi = DateTime.Now;
            entity.KayitDurumu = Domain.Enums.KayitDurumu.Guncellendi;

            _context.Update(entity);
            int kayitSayisi = await _context.SaveChangesAsync();
            return kayitSayisi > 0 ? true : false;
        }

        //Nesneyi siler
        public async Task SilAsync(int id)
        {
            var entity = await BulAsync(id);
            entity.SilmeTarihi = DateTime.Now;
            entity.KayitDurumu = Domain.Enums.KayitDurumu.Pasif;

            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> TumKayitlarAsync()
        {
            return await _dbSet.ToListAsync();
        }

        //İlk parametre nesne dönüş tipini belirler. İkinci parametre filtreleme yapar, Üçüncü parametre sıralama yapar sonuncusu ise nav.prop uygular
        public async Task<IEnumerable<TResult>> TumunuFiltreleAsync<TResult>(Expression<Func<TEntity, TResult>> select,
           Expression<Func<TEntity, bool>> where,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _dbSet.AsQueryable();

            if (where != null)
                query = query.Where(where);
            if (include != null)
                query = include(query);

            if (orderBy != null)
                return await orderBy(query).Select(select).ToListAsync();
            else
                return await query.Select(select).ToListAsync();
        }

        public IQueryable<TEntity> TumunuGetir()
        {
            return _dbSet.Select(x => x);
        }
    }
}
