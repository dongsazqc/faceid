using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Complate.Models
{

    public class Person
    {
        [Key]
        public int PersonId{ get; set; }
        public int DeviceID { get; set; }
        public int ?PersonType { get; set; }
        public int ?Gender { get; set; }
        public int? Nation { get; set; }
        public int ?CardType { get; set; }
        public string? IdCard { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Telnum { get; set; }
        public string ?Native { get; set; }
        public string? Address { get; set; }
        public string ?Notes { get; set; }
        public int ?MjCardFrom { get; set; }
        public int ?WiegandType { get; set; }
        public string ?Name { get; set; }
        public string ? Capture { get; set; }
        public string? CustomizeID { get; set; }
        public string? PersonUUID { get; set; }
        public string? PhotoUrl { get; set; }   
        public string ?PhotoData { get; set; }  

    }

}
