using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class object1
    {
        public int id;
        public int nameId;
        public List<object2> items;
    }

    class object2
    {
    public int id;
    public string name;
    public decimal price;
    }

    class object3
    {
        public int id;
        public int nameId;
        public int itemid;
        public string name;
        public decimal price;
    }
class Program
    {
        
        static void Main(string[] args)
        {
            var object2List1 = new List<object2>
            {
                new object2 {id = 1, name = "1", price = 10},
                new object2 {id = 2, name = "2", price = 20},
                new object2 {id = 3, name = "3", price = 30},
            };

            var object2List2 = new List<object2>
            {
                new object2 {id = 11, name = "11", price = 11},
                new object2 {id = 21, name = "21", price = 21},
                new object2 {id = 31, name = "31", price = 31},
            };

            var object1List = new List<object1>
            {
                new object1 {id = 100, nameId = 100, items = object2List1},
                new object1 {id = 110, nameId = 110, items = object2List2},
            };


            var object3List = object1List.SelectMany(o1 => o1.items.Select(o2 => new object3()
            {
                id=o1.id,
                nameId = o1.nameId,
                itemid = o2.id,
                name = o2.name,
                price = o2.price

            })).ToList();

            foreach (var ol in object3List)
            {
                Console.WriteLine(ol.id + "\t" + ol.nameId + "\t" + ol.itemid + "\t" + ol.name + "\t" + ol.price);


            }

        
        
       
           
        }
    }
}
