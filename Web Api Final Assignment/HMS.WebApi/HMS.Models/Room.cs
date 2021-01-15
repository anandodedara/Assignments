using System.Collections.Generic;

namespace HMS.Models
{
    public class Room
    {

        public enum RoomCategory
        {
            Cat0 = 0,
            /// <summary>
            /// Size < 35 m2
            /// </summary>
            Category1 = 1,

            /// <summary>
            /// Size 36-50 m2
            /// </summary>
            Category2 = 2,

            /// <summary>
            /// Size 51-100 m2
            /// </summary>
            Category3 = 3
        }

        public Room()
        {
            this.Bookings = new HashSet<Booking>();
        }

        public short Id { get; set; }
        public short HotelId { get; set; }
        public string Name { get; set; }
        public RoomCategory Category { get; set; }
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