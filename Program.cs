namespace CatWorx.BadgeMaker
{
  class Program
  {
    async static Task Main(string[] args)
    // creates employee badges
    {
      List<Employee> employees = new List<Employee>();
      Console.WriteLine("Welcome to the CatWorx BadgeMaker Program!");
      Console.WriteLine("Do you want to enter employee information manually? (Enter Y or y to proceed):");
      string response1 = Console.ReadLine() ?? "";
      if (response1 == "Y" || response1 == "y")
      {
        employees = PeopleFetcher.GetEmployees();
      }
      else
      {
        Console.WriteLine("Creating five badges using an API that provides random data.");
        employees = await PeopleFetcher.GetFromApi();
      }
      Util.PrintEmployees(employees);
      Util.MakeCSV(employees);
      await Util.MakeBadges(employees);
      Console.WriteLine("Badges and CSV file are complete. They are in the folder named \"data\".");

    }

  }
}