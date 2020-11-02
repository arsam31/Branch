
using Branch.Data.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Branch.Data.Core.IRepositories
{
    public interface IPostRepository : IRepository<Post>
    {
        IQueryable<Post> FindAllPosts(long id);
    }
}
