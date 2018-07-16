using System;
using System.Collections.Generic;
using System.Text;
//using Features.Linq;
using System.Threading.Tasks;
using System.Linq;

namespace Features
{
  class Program
  {
    static void Main(string[] args)
    {

      Func<int, int> square = x => x * x;
      Func<int, int, int> add = (x, y) => {
        int temp = x + y;
        return temp;
        };

      Action<int> write = x => Console.WriteLine(x);

      write(square(add(3, 5)));

      IEnumerable<Employee> developers = new Employee[]
        {
          new Employee { Id = 1, Name = "SFoo5" },
          new Employee { Id = 2, Name = "Bar45" }
        };

      IEnumerable<Employee> sales = new List<Employee>()
      {
        new Employee { Id = 3, Name = "Ricky Bobby"}
      };

      //foreach (var person in developers)
      //{ 
      //  Console.WriteLine(person.Name);
      //}

      //Console.WriteLine(developers.OrderBy(x => x.Id));

      //IEnumerator<Employee> enumerator = developers.GetEnumerator();
      //while (enumerator.MoveNext())
      //{
      //  Console.WriteLine(enumerator.Current.Name);
      //}
      var query = developers.Where(e => e.Name.Length == 5)
        .OrderByDescending(e => e.Name)
        .Select(e => e);

      var query2 = from developer in developers
                   where developer.Name.Length == 5
                   orderby developer.Name descending
                   select developer;

      foreach (Employee employee in query2)
      {
        Console.WriteLine(employee.Name);
      }
    }
  }
}
