using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public Guid Id_UserDa { get; set; }
        [ForeignKey("Id_UserDa")]
        public UserDa loguser { get; set; }
        public Guid Id_User_Psy { get; set; }
        [ForeignKey("Id_User_Psy")]
        public Psy_Da logpsy { get; set; }
        

    }

}
