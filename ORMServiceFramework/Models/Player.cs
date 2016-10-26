using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ORMServiceFramework.Models
{
    
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }
    }
}