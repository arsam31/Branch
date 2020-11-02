using Branch.Data.Core.Domain;
using Branch.Data.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Branch.Data.Managers
{
	public class CategoryRepository : Repository<Category>,ICategoryRepository
	{
		public CategoryRepository(BranchContext context) : base(context)
		{
		}
		public BranchContext BranchContext
		{
			get { return Context as BranchContext; }
		}

        public IList<Category> Categories()
        {
            return Context.Category.Include(p => p.Posts).ToList();      
        }

    }
}
