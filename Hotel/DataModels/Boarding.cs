using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hotel.DataModels
{
    [Table("BOARDING")]
    public class Boarding
    {
        [Column("BOARDING_ID")]
        public int BoardingId { get; set; }

        [Column("BOARDING_NAME")]
        public string BoardingName { get; set; }

        [Column("BOARDING_PRICE")]
        public double BoardingPrice { get; set; }

        public override string ToString()
        {
            return BoardingName +" - Cena: " + BoardingPrice;
        }

    }
}
