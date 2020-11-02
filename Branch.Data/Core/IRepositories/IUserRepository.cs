using Branch.Data.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Branch.Data.Core.IRepositories
{
	public interface IUserRepository: IRepository<User>
	{
	   User AuthenticateUser(string UserName,string Password);
        bool IsEmailExist(string Email);

    }
}
