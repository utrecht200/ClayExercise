using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clay3.Models
{
    public class KeyViewModel
    {
        public KeyItem[] Keys { get; set; }
    }


    public class OpenRecordViewModel
    {
        public OpenRecord[] OpenRecords { get; set; }
    }

    public class DoorItemViewModel
    {
        public KeyViewModel KeyViewModel { get; set; }

        public OpenRecordViewModel OpenRecordViewModel { get; set; }

    }


}