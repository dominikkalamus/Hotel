using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hotel.DataModels
{
    [Table("ROOM_QUALITY")]
    public class RoomQuality
    {
        [Column("ROOM_QUALITY_ID")]
        public int RoomQualityId { get; set; }
        [Column("QUALITY")]
        public string Quality { get; set; }

        public override string ToString()
        {
            return "Id: " + RoomQualityId + ", Jakość: " + Quality;
        }
    }
}
