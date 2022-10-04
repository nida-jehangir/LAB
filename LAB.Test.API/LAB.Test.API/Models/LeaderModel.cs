using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LAB.Test.API.Models
{
    public class LeaderModel
    {
        [Required]
        public IFormFile File { get; set; }
    }
}
