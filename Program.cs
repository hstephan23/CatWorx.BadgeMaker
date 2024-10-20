using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatWorx.BadgeMaker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<Employee> employees = [];
            Console.WriteLine("Generate some badges!");
            Console.WriteLine("Input your own? (type yes or no)");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "yes")
            {
                employees = PeopleFetcher.GetEmployees();
            }
            else
            {
                employees = await PeopleFetcher.GetFromApi();
            }
            Util.PrintEmployees(employees);
            Util.MakeCSV(employees);
            await Util.MakeBadges(employees);
        }
    }
}
