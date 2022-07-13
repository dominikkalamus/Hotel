using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hotel.DataModels
{
    [Table("ROOM")]
    public class Room
    {
        [Column("ROOM_ID")]
        public int RoomId { get; set; }
        [Column("ROOM_NUMBER")]
        public int RoomNumber { get; set; }
        [Column("PRICE")]
        public double RoomPrice { get; set; }
        [Column("ROOM_QUALITY_ID")]
        [ForeignKey("ROOM_QUALITY")]
        public int RoomQualityId { get; set; }
        [Column("ROOM_STATUS_ID")]
        [ForeignKey("ROOM_STATUS")]
        public int RoomStatusId { get; set; }


        public override string ToString()
        {
            return "Numer: " + RoomNumber +" - Cena: " + RoomPrice;

        }
    }
}
