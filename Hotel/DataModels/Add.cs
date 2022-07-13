using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hotel.DataModels
{
    [Table("ADDS")]
    public class Add
    {
        [Column("ADD_ID")]
        public int AddId { get; set; }

        [Column("ADD_NAME")]
        public string AddName { get; set; }

        [Column("ADD_PRICE")]
        public double AddPrice { get; set; }

        public override string ToString()
        {
            return AddName +" - Cena: " + AddPrice;
                
        }
    }
}
