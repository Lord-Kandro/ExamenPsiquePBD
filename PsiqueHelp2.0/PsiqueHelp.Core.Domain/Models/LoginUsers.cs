using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PsiqueHelp.Core.Domain.Models
{
    public class LoginUsers
    {
        public Guid Id_Login { get; set; }
        public string email { get; set; }
        public string password { get; set; } 
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<Psy_Da> psyLog { get; set; } //muchos psicologos
        public List<UserDa> userLog { get; set; }//muchos usuarios
    }

}
