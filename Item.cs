using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemPlecakowy
{
    class Item
    {
        string name="";
        float value=0, weight=0;
        public string getName()
        {
            return name;
        }
        public float getValue()
        {
            return value;
        }
        public float getWeight()
        {
            return weight;
        }
        public Item(string _name, float _value, float _weight)
        {
            name = _name;
            value = _value;
            weight = _weight;
        }
        public Item() {}
    }
}
