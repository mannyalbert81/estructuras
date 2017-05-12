using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionXML.clases
{
    public class Item
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public Item(string name, string value)
        {
            Name = name;
            Value = value;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
