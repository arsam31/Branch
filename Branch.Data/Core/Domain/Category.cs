using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Branch.Data.Core.Domain
{
	public class Category
	{
		[Key]
		public long Id { get; set; }
		public bool IsActive { get; set; }
		public int Status { get; set; }
		public DateTime ModifiedDate { get; set; }
		public Nullable<long> ModifiedBy { get; set; }
     	public DateTime CreatedDate { get; set; }
		public Nullable<long> CreatedBy { get; set; }
		public string Remarks { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		public Nullable<long> ParentId { get; set; }
		public int Level { get; set; }
        
		public virtual ICollection<Post> Posts { get; set; }
        [NotMapped]
        public List<Category> WithSubCatagories { get; set; }


    }
}
