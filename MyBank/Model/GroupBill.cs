using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Model
{
    public class GroupBill
    {
        public GroupBill(string name, string currency)
        {
            Guid = Guid.NewGuid();
            GroupName = name;
            Currency = currency;
            Bills = new List<Bill>();
        }

        public Guid Guid { get; }

        public string GroupName { get; set; }

        public string Currency { get; set; }

        public List<Bill> Bills { get; set; }

        public double MainSumm { get { return Bills.Sum(x => x.Summ); } }

        public override string ToString()
        {
            return $"{MainSumm} {Currency} => {GroupName} *** Всего счетов: {Bills.Count()}";
        }
    }
}
