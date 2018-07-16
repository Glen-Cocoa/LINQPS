using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
  class Program
  {
    static void Main(string[] args)
    {
      List<Car> cars = ProcessFile("fuel.csv");
    }

    private static List<Car> ProcessFile(string path)
    {
      File.ReadAllLines(path)
        .Skip(1)
        .Where(line => line.Length > 1)
        .Select(Car.ParseFromCSV);
    }
  }
}
