using Branch.Data.Core.Domain;
using Branch.Data.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Branch.Data.Managers
{
    public class CommentRepository : Repository<Comments>, ICommentRepository
    {
        public CommentRepository(BranchContext context) : base(context)
        {
        }
        public BranchContext BranchContext
        {
            get { return Context as BranchContext; }
        }
        public IList<Comments> Comments()
        {
            throw new NotImplementedException();
        }
    }
}
