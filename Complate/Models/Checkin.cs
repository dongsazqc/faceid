using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complate.Models
{
    // Entity Checkin
    public class Checkin
    {
        public int Id { get; set; }
        public string IdCard { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public int LibID { get; set; }
        public int VerifyStatus { get; set; }
        public byte[] PhotoData { get; set; } // Lưu Base64
    }

}
