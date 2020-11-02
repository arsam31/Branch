using Branch.Data.Core.Domain;
using Branch.Data.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Branch.Data.Managers
{
	public class UserRepository: Repository<User>,IUserRepository
	{
		public UserRepository(BranchContext context) : base(context)
		{
		}
		public BranchContext BranchContext
		{
			get { return Context as BranchContext; }
		}

		public User AuthenticateUser(string Email, string Password)
		{
			return Context.Users.Where(m=>m.Email==Email && m.Password==Password).FirstOrDefault();
		}
        public bool IsEmailExist(string Email)
		{
            var oUSER=Context.Users.Where(m => m.Email == Email).FirstOrDefault();

            if (oUSER != null)
            {
                return true;
            }
            else {
                return false;
            }

        }

       
    }
}
