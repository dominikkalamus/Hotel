using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hotel.DataModels
{

    public class Client
    {
        [Column("CLIENT_ID")]
        public int ClientId { get; set; }
        [Column("FIRST_NAME")]
        public String FirstName { get; set; }
        [Column("LAST_NAME")]
        public String LastName { get; set; }
        [Column("ID_NUMBER")]
        public String IdNumber { get; set; }
        [Column("PHONE")]
        public String PhoneNumber { get; set; }


        public override string ToString()
        {
            return FirstName + 
                " " + LastName +
                ", Numer dowodu: " + IdNumber + 
                ", Numer telefonu: " + PhoneNumber;
        }
    }
}
