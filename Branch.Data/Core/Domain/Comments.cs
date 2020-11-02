using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Branch.Data.Core.Domain
{
	public class Comments
	{
		[Key]
		public long Id { get; set; }
		public bool IsActive { get; set; }
		public int Status { get; set; }
		public DateTime ModifiedDate { get; set; }
		public DateTime CreatedDate { get; set; }
		public Nullable<long> ModifiedBy { get; set; }
		public long CreatedBy { get; set; }
		public string Remarks { get; set; }
		public string Body { get; set; }
		public string Image { get; set; }
		public string Video { get; set; }
		public string Audio { get; set; }
		public string Document { get; set; }
		public virtual Post Post { get; set; }
	}
}
