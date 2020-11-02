using Branch.Data.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Branch.Data.Core.IRepositories
{
    public interface ICategoryRepository: IRepository<Category>
    {
        IList<Category> Categories();
    }
}
