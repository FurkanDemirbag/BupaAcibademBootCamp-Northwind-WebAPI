using Northwind.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Northwind.Entity.Models
{
    public class User : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage ="User Id cannot be null")]
        public int UserID { get; set; }

        [MaxLength(30)]
        public string UserName { get; set; }

        [MaxLength(30)]
        public string UserLastName { get; set; }

        [Required(ErrorMessage = "UserCode cannot be null")]
        [MaxLength(40)]
        public string UserCode { get; set; }

        [Required(ErrorMessage = "Passwordcannot be null")]
        [MaxLength(60)]
        public string Password { get; set; }

    }
}
