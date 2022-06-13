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
        public string email { get; set; }
        public string password { get; set; }
        public int cell { get; set; }
        public string idPerson { get; set; }
        public int age { get; set; }
        [ForeignKey("Id_Login")]
        public LoginUsers userlog { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<comments> Comments { get; set; }//llave que va hacia Euser- un usuario
        public List<Forum> forum { get; set; }//lave hacia Euser- un usuario
        public List<Notes> notes { get; set; }//llave hacia Euser- un usuario
    }

}
