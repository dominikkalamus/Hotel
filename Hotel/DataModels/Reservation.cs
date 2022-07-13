using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hotel.DataModels
{
    [Table("RESERVATION")]
    public class Reservation
    {
        [Column("RESERVATION_ID")]
        public int ReservationId { get; set; }
        [Column("CLIENT_ID")]
        [ForeignKey("CLIENT")]
        public int ClientId { get; set; }
        [Column("ROOM_ID")]
        [ForeignKey("ROOM")]
        public int RoomId { get; set; }
        [Column("BOARDING_ID")]
        [ForeignKey("BOARDING")]
        public int BoardingId { get; set; }
        [Column("ADD_ID")]
        [ForeignKey("ADDS")]
        public int AddId { get; set; }
        [Column("DATE")]
        public DateTime Date { get; set; }
        [Column("DAYS")]
        public int Days { get; set; }

        public override string ToString()
        {
            return "ReservationId: " + ReservationId +
                ", ClientId: " + ClientId +
                ", RoomId: " + RoomId +
                ", BoardingId: " + BoardingId +
                ", AddId: " + AddId +
                ", Date: " + Date +
                ", Days: " + Days;

        }
    }
}
