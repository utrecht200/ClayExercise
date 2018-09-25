using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clay3.Models
{
    public class OpenRecord
    {
        [Key]
        public Guid RecordId { get; set; }

        public Guid DoorId { get; set; }

        public string UserName { get; set; }

        public bool HasOpened { get; set; }

        public DateTimeOffset? Excuted { get; set; }
    }
}