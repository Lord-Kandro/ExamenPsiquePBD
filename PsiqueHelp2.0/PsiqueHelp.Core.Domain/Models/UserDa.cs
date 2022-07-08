using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PsiqueHelp.Core.Domain.Models
{
    public class UserDa
    {
        public Guid Id_UserDa { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nick { get; set; }
        public string City { get; set; }

        public string Department { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Cell { get; set; }
        public string IdPerson { get; set; }
        public Guid Id_Login { get; set; }
        public int age { get; set; }
        [ForeignKey("Id_Login")]
        public LoginUsers login_userId_Login { get; set; }
        
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public List<comments> Comments { get; set; }//llave que va hacia ecomments- un usuario
        public List<Forum> forum { get; set; }//lave hacia eforum- un usuario
        public List<Notes> notes { get; set; }//llave hacia enotes- un usuario
    } 

}
