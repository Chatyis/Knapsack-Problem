using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemPlecakowy
{
    class Individual
    {
        List<Item> items = new List<Item>();
        public float getWeight()
        {
            float weight = 0f;
            foreach (Item i in items)
            {
                weight += i.getWeight();
            }
            return weight;
        }
        public float getValue()
        {
            float value = 0f;
            foreach (Item i in items)
            {
                value += i.getValue();
            }
            return value;
        }
        public (float v, float w) getValueWeight()
        {
            (float v, float w) valueWeight = (0f, 0f);
            foreach (Item i in items)
            {
                valueWeight.v += i.getValue();
                valueWeight.w += i.getWeight();
            }
            return valueWeight;
        }
        public List<Item> getItems(){return this.items;}
        public void addItem(Item item) {items.Add(item);}
        public void removeItem(int index) { items.Remove(items[index]); }
        public Individual(Individual a){this.items = a.items;}
        public Individual() {}
    }
}
