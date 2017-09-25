using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Model
{
    [DataContract]
    public class Bill
    {
        public Bill(string line)
        {
            var array = line.Split(';');
            Date = DateTime.ParseExact(array[0], "dd.mm.yyyy", null);//"31.08.2017"
            Desc = array[1];
            Summ = double.Parse(array[2].Replace(" ", "")) * -1;//"-2,20"
            Currency = array[3];
            if (Currency == "BYN") {
                Summ /= 100;
            }

            if (Currency == "RUB") {
                Summ /= 100;
                Summ = Summ / 100 * 3.3;
                Currency = "BYN";
            }
        }

        public string Desc { get; set; }

        public DateTime Date { get; set; }

        public string Currency { get; set; }

        public double Summ { get; set; }
    }
}
