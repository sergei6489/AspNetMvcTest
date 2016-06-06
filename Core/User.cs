using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Core
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Логин")]
        public string UserName { get; set; }
        [Required]
        [DisplayName( "ФИО" )]
        public string Name { get; set; }
        [Required]
        [DisplayName("Пароль")]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
