using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Branch.Api.DTOs
{
    public class AddComment
    {
        public long Id { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public string Audio { get; set; }
        public string Video { get; set; }
        public string Document { get; set; }

        [IgnoreDataMember]
        public bool IsActive { get; set; }
    }
}
