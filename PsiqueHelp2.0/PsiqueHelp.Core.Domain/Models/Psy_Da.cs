using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PsiqueHelp.Core.Domain.Models
{
    public class Psy_Da
    {
        public Guid Id_User_Psy { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nick { get; set; }
        public string City { get; set; }
        public string Department { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int cell { get; set; }
        public string idPerson { get; set; }
        public int Register_S { get; set; }
        public int folio { get; set; }
        public int volume { get; set; }
        [ForeignKey("ConTer_id")]
        public ConTer conterp { get; set; }//llave hacia EconTer -un Contenido
        [ForeignKey("Id_Login")]
        public LoginUsers login_users { get; set; }//llave hacia Elogin -un login
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<Forum> forum { get; set; }//llave hacia EpsyDa - muchos foros
    }

}
