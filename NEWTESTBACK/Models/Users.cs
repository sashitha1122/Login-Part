﻿using System.ComponentModel.DataAnnotations;

namespace NEWTESTBACK.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
