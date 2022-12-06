namespace CatWorx.BadgeMaker

{
  class PeopleFetcher
  {
    public static List<Employee> GetEmployees()
    // uses command line to collect employee data
    // this demo program does not catch errors in data such as an invalid url for the photo
    {
      List<Employee> employees = new List<Employee>();
      while (true)
      {
        Console.WriteLine("Please enter a name: (leave empty to exit): ");
        string firstName = Console.ReadLine() ?? "";
        if (firstName == "")
        {
          break;
        }
        Console.Write("Enter last name: ");
        string lastName = Console.ReadLine() ?? "";
        Console.Write("Enter ID: ");
        int id = Int32.Parse(Console.ReadLine() ?? "");
        Console.Write("Enter Photo URL: (suggestion: http://placekitten.com/400/400)");
        string photoUrl = Console.ReadLine() ?? "";

        Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
        employees.Add(currentEmployee);
      }
      return employees;
    }
    async public static Task<List<Employee>> GetFromApi()
    // uses a method that uses an api to collect employee data
    {
      {
        List<Employee> employees = new List<Employee>();
        employees = await RandomUserHandler.GetFromRandomUserSite();
        return employees;
      }
    }
  }
}
