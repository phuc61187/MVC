using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Linq;

namespace ConsoleApplication {
    public class Program {
        public static void Main(string[] args) {
            runtest1();
            Console.ReadLine();
        }

        public static void runtest1() {
            List<string> array = new List<string>() { "1", "2", "1", "3" };
            var listResult = array.Where(item => item == "1").AsEnumerable().ToList();
            var listResult2 = (from item in array where item == "1" select item);
            foreach (var item in listResult) {
                Console.WriteLine(item.ToString());
            }
            
        }
    }
}
