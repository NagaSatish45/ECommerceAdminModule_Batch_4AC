using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminCategoryService.Models
{
    public class UserModel
    {
        public int Userid { get; set; }
        public string Username { get; set; }
        public int? Nooforders { get; set; }
        public int? Failedorders { get; set; }
    }
}
