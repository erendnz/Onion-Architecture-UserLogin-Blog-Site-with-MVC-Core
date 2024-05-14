using Blog.Domain.Entities;
using Blog.Domain.Repositories.Abstract;
using Blog.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Repositories.Concrete
{
    public class MakaleRepository : BaseRepository<Makale>, IMakaleRepository
    {
        public MakaleRepository(BlogContext context) : base(context)
        {
        }
    }
}
