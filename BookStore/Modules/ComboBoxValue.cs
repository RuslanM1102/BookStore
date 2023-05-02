using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Modules
{
    public class ComboBoxValue
    {
        public int ID { get; private set; }
        public string Name { get; private set; }

        public dynamic Value { get; private set; }

        public ComboBoxValue(int id, string name, dynamic value)
        {
            ID = id;
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return $"{ID}. {Name}";
        }
    }
}
