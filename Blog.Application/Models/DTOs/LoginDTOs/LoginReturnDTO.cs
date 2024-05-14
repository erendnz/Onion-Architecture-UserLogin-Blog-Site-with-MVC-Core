using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Models.DTOs.LoginDTOs
{
    public class LoginReturnDTO
    {
        public bool IsUser { get; set; }
        public bool IsAdmin { get; set; }

    }
}
