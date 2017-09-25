using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Model
{
    public class SpendingGroup
    {
        public SpendingGroup() { }

        public SpendingGroup(string name, List<string> marks)
        {
            Name = name;
            Marks = marks;
        }


        public string Name { get; set; }
        public List<string> Marks { get; set; }
    }
}
