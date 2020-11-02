using Branch.Data.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Branch.Data.Core.IRepositories
{
    public interface ICommentRepository :IRepository<Comments>
    {
        IList<Comments> Comments();
    }
}
