using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Model
{
    public class TradePoint
    {
        public TradePoint() { }

        public TradePoint(string name, string currency)
        {
            Guid = Guid.NewGuid();
            GroupDesc = name;
            Currency = currency;
            Bills = new List<Bill>();
        }

        public Guid Guid { get; }

        public string GroupDesc { get; set; }

        public string Currency { get; set; }

        public List<Bill> Bills { get; set; }

        public double MainSumm { get { return Bills.Sum(x => x.Summ); } }

        public override string ToString()
        {
            return $"{MainSumm} {Currency} => {GroupDesc} *** Всего счетов: {Bills.Count()}";
        }
    }
}
