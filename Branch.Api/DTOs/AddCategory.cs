using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Branch.Api.DTOs
{
    public class AddCategory
    {
        public long Id { get; set; }
        public string Remarks { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        [IgnoreDataMember]
        public bool IsActive { get; set; }
        public Nullable<long> ParentId { get; set; }
        public virtual ICollection<AddPost> AddPosts { get; set; }
        [NotMapped]
        public List<AddCategory> WithSubCatagory { get; set; }
    }
}
