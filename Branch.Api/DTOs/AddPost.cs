using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Branch.Api.DTOs
{
    public class AddPost
    {
        
        public long Id { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public string Audio { get; set; }
        public string Video { get; set; }
        public string Document { get; set; }
        public Nullable<long> CategoryId { get; set; }
        [IgnoreDataMember]
        public bool IsActive { get; set; }
        [NotMapped]
        public List<AddPost> WithAllPosts { get; set; }
    }
}
