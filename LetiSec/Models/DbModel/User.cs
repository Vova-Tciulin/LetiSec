﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LetiSec.Models.DbModel
{
    public class User
    {
        public int Id { get; set; }


        public string Name { get; set; }


        public string Email { get; set; }


        public string Password { get; set; }

        public int RoleId { get; set; }



    }
}
