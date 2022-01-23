using Northwind.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Northwind.Entity.Models
{
    public class UserRefreshToken : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "User Id cannot be null")]
        public int Id { get; set; }

        [Required(ErrorMessage = "UserID cannot be null")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "RefreshToken cannot be null")]
        public string RefreshToken { get; set; }

        [Required(ErrorMessage = "RefreshTokenExpiration cannot be null")]
        public DateTime RefreshTokenExpiration { get; set; }

        public UserRefreshToken()
        {

        }
    }
}
