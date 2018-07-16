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
      foreach (var car in cars)
      {
        Console.WriteLine(car.Name);
      }
    }

    private static List<Car> ProcessFile(string path)
    {
      IEnumerable<Car> query =
        from line in File.ReadAllLines(path).Skip(1)
        where line.Length > 1
        select Car.ParseFromCSV(line);

        return query.ToList();
        
      //File.ReadAllLines(path)
      //  .Skip(1)
      //  .Where(line => line.Length > 1)
      //  .Select(Car.ParseFromCSV)
      //  .ToList();
    }
  }
}
