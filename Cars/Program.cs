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

      IEnumerable<Car> query = cars.OrderByDescending(car => car.Combined);
      foreach (Car car in query.Take(10))
      {
        Console.WriteLine($"{car.Name} : {car.Combined}");
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
