using Branch.Data.Core.Domain;
using Branch.Data.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branch.Data.Managers
{
    public class PostRepository : Repository<Post>,IPostRepository
    {
        public PostRepository(BranchContext context) : base(context)
        {
        }

        public BranchContext BranchContext
        {
            get { return Context as BranchContext; }
        }

        public IList<Post> Posts()
        {
            return Context.Posts.Include(p => p.Comments).ToList();
        }

        public IQueryable<Post> FindAllPosts(long id)
        {
            return from post in Context.Posts
                   join category in Context.Category on post.CategoryId equals category.Id
                   where category.Id == id

                   orderby post.Id descending
                   select new Post()
                   {
                       CategoryId = category.Id,
                       Id  = post.Id,
                       Video = post.Video,
                       Image = post.Image,
                       Body = post.Body,
                       Document = post.Document
                   };
        }

        
    }
}
