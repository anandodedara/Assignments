using System.Collections.Generic;

namespace HMS.Models
{
    public class Room
    {
        public Room()
        {
            this.Bookings = new HashSet<Booking>();
        }

        public short Id { get; set; }
        public short HotelId { get; set; }
        public string Name { get; set; }
        public byte Category { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public short CreatedBy { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public short UpdatedBy { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}