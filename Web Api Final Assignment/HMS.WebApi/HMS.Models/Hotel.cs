using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Hotel
    {
        public Hotel()
        {
            this.Rooms = new HashSet<Room>();
        }

        public short Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public decimal PINCode { get; set; }
        public decimal ContactNumber { get; set; }
        public string ContactPersonName { get; set; }
        public string Website { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public short CreatedBy { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public short UpdatedBy { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
