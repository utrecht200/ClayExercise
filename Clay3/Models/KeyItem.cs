using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clay3.Models
{
    public class KeyItem
    {
        [Key]
        public Guid KeyId { get; set; }

        public Guid DoorId { get; set; }

        public string KeyOwner { get; set; }

        
    }
}