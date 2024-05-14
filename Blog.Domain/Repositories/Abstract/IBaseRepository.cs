using Blog.Domain.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Repositories.Abstract
{
    public interface IBaseRepository<TEntity> where TEntity : class, IBaseEntity
    {
        Task EkleAsync(TEntity entity);

        //Guncelleme basariliysa true döndürür
        Task<bool> GuncelleAsync(TEntity entity);
        Task SilAsync(int id);
        Task<IEnumerable<TEntity>> TumKayitlarAsync();

        Task<TEntity> BulAsync(int id);

        Task<IEnumerable<TEntity>> BulAsync(Expression<Func<TEntity, bool>> predicate);


        
        Task<IEnumerable<TResult>> TumunuFiltreleAsync<TResult>(
            Expression<Func<TEntity, TResult>> select,       //TEntity türünden input alarak TResult tpinde sonuç döndürür
            Expression<Func<TEntity, bool>> where,           //Where koşulu sağlar filtreler
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, // Sıralama işlemi yapar default null
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null // Nav. Prop yapar default null

            );

        IQueryable<TEntity> TumunuGetir(); 

    }
}
