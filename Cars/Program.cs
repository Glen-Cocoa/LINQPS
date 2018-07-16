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

      var query =
        from car in cars
        where car.Manufacturer == "BMW" && car.Year == 2016
        orderby car.Combined descending, car.Name ascending
        select new
        {
          car.Manufacturer,
          car.Name,
          car.Combined
        };


      //Car top =
      //  cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
      //  .OrderByDescending(c => c.Combined)
      //  .ThenBy(c => c.Name)
      //  .Select(c => c)
      //  .FirstOrDefault(c => c.Manufacturer == "BMW" && c.Year == 2016);

      IEnumerable<char> result = cars.SelectMany(c => c.Name)
        .OrderBy(c => c);

        foreach (var character in result)
        {
          Console.WriteLine(character);
        }

      //Console.WriteLine(result);

      //foreach (Car car in query.Take(10))
      //{
      //  Console.WriteLine($"{car.Name} : {car.Combined}");
      //}
    }

    private static List<Car> ProcessFile(string path)
    {
      //IEnumerable<Car> query =
      //  from line in File.ReadAllLines(path).Skip(1)
      //  where line.Length > 1
      //  select Car.ParseFromCSV(line);
      IEnumerable<Car> query =

        File.ReadAllLines(path)
        .Skip(1)
        .Where(l => l.Length > 1)
        .ToCar();

      return query.ToList();

      //File.ReadAllLines(path)
      //  .Skip(1)
      //  .Where(line => line.Length > 1)
      //  .Select(Car.ParseFromCSV)
      //  .ToList();
    }
  }

  public static class CarExtensions
  {
    public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
    {
      foreach (var line in source)
      {
        var columns = line.Split(',');

        yield return new Car
        {
          Year = int.Parse(columns[0]),
          Manufacturer = columns[1],
          Name = columns[2],
          Displacement = double.Parse(columns[3]),
          Cylinders = int.Parse(columns[4]),
          City = int.Parse(columns[5]),
          Highway = int.Parse(columns[6]),
          Combined = int.Parse(columns[7])
        };
      }
    }
  }
}
