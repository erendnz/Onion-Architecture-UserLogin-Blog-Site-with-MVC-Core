using Blog.Domain.Entities;
using Blog.Domain.Repositories.Abstract;
using Blog.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Repositories.Concrete
{
    public class KonuRepository : BaseRepository<Konu>, IKonuRepository
    {
        public KonuRepository(BlogContext context) : base(context)
        {
        }
    }
}
