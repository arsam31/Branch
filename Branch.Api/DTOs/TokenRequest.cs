using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Branch.Api.DTOs
{
    public class TokenRequest
    {

        public String Email { get; set; }

        public String Password { get; set; }
        
    }
}
