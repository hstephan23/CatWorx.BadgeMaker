using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CatWorx.BadgeMaker
{
    class PeopleFetcher
    {
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = [];
            while (true)
            {
                Console.WriteLine("Please enter a name (leave empty to exit): ");
                string firstName = Console.ReadLine() ?? "";
                if (firstName == "")
                {
                    break;
                }

                Console.WriteLine("Please enter a last name: ");
                string lastName = Console.ReadLine() ?? "";
                Console.WriteLine("Please enter an ID: ");
                int id = Int32.Parse(Console.ReadLine() ?? "");
                Console.WriteLine("Please enter a photo URL: ");
                string photoUrl = Console.ReadLine() ?? "";

                Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
                employees.Add(currentEmployee);
            }
            return employees;
        }

        public static async Task<List<Employee>> GetFromApi()
        {
            List<Employee> employees = [];
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(
                    "https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture"
                );
                JObject json = JObject.Parse(response);
                foreach (JToken token in json.SelectToken("results"))
                {
                    Employee emp = new Employee(
                        token.SelectToken("name.first").ToString(),
                        token.SelectToken("name.last").ToString(),
                        Int32.Parse(token.SelectToken("id.value").ToString().Replace("-", "")),
                        token.SelectToken("picture.large").ToString()
                    );
                    employees.Add(emp);
                }
            }
            return employees;
        }
    }
}
