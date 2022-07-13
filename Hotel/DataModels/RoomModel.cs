using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DataModels
{
    public class RoomModel
    {
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public double RoomPrice { get; set; }
        public int RoomQualityId { get; set; }
        public string RoomQuatityName { get; set; }
        public int RoomStatusId { get; set; }
        public string RoomStatusName { get; set; }
        
		public override string ToString()
		{
			return string.Format("[RoomModel RoomId={0}, RoomNumber={1}, RoomPrice={2}, RoomQualityId={3}, RoomQuatityName={4}, RoomStatusId={5}, RoomStatusName={6}]", RoomId, RoomNumber, RoomPrice, RoomQualityId, RoomQuatityName, RoomStatusId, RoomStatusName);
		}

    }
}
