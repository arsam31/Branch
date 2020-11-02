using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Branch.Data.Core.Domain
{
	public class User
	{
		[Key]
		public long Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Mobile { get; set; }
		public bool IsActive { get; set; }
		public DateTime DOB { get; set; }
		public int Status { get; set; }
		public DateTime ModifiedDate { get; set; }
		public Nullable<long> Modifiedby { get; set; }
		public string Remarks { get; set; }
		public string Password { get; set; }
        public string UserName { get; set; }
        public bool IsApproved { get; set; }
        public DateTime ApproveDate { get; set; }
        public string Role { get; set; }
	}
}
