using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarMatrixData;
using CarMatrixData.Models;

namespace CarMatrixDataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var container = new ModelsContainer())
            {
                Person p = new Person();
                p.Name = "jack";

                container.Set<Person>().Add(p);
                container.SaveChanges();
            }

            Console.ReadKey();
        }
    }
}
