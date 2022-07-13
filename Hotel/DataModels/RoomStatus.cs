using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hotel.DataModels
{
    [Table("ROOM_STATUS")]
    public class RoomStatus
    {
        [Column("STATUS_ID")]
        public int StatusId { get; set; }
        [Column("STATUS")]
        public string Status { get; set; }

        public override string ToString()
        {
            return "Id: " + StatusId + ", Status: " + Status;
        }
    }
}
