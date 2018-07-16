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

      //IEnumerable<Car> query = cars.OrderByDescending(c => c.Combined)
      //  .ThenBy(c => c.Name);

      IEnumerable<Car> query =
        from car in cars
        where car.Manufacturer == "BMW" && car.Year == 2016
        orderby car.Combined descending, car.Name ascending
        select car;

      Car top =
        cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
        .OrderByDescending(c => c.Combined)
        .ThenBy(c => c.Name)
        .Select(c => c)
        .First(c => c.Manufacturer == "BMW" && c.Year == 2016);

      Console.WriteLine(top.Name);

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
