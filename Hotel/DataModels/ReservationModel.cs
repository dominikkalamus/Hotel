using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DataModels
{
    public class ReservationModel
    {
        public int ReservationId { get; set; }
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public string PhoneNumber { get; set; }
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public double RoomPrice { get; set; }
        public DateTime ReservationDate { get; set; }
        public int ReservationDays { get; set; }
        public int BoardingId { get; set; }
        public string BoardingName { get; set; }
        public double BoardingPrice {get;set;}
        public int AddId { get; set; }
        public string AddName { get; set; }
        public double AddPrice { get; set; }
        public double Price { get; set; }
        
		public override string ToString()
		{
			return string.Format("[ReservationModel ReservationId={0}, ClientId={1}, FirstName={2}, LastName={3}, IdNumber={4}, PhoneNumber={5}, RoomId={6}, RoomNumber={7}, RoomPrice={8}, ReservationDate={9}, ReservationDays={10}, BoardingId={11}, BoardingName={12}, BoardingPrice={13}, AddId={14}, AddName={15}, AddPrice={16}, Price={17}]", ReservationId, ClientId, FirstName, LastName, IdNumber, PhoneNumber, RoomId, RoomNumber, RoomPrice, ReservationDate, ReservationDays, BoardingId, BoardingName, BoardingPrice, AddId, AddName, AddPrice, Price);
		}



    }
}
