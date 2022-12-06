using System.Text.Json;

namespace CatWorx.BadgeMaker

{
  class RandomUserHandler
  {
    // classes below are for use by the JSON deserializer
    // the api call is to randomuser.me
    // the full format of the json api response is below; unused variable types are commented out
    public class RandomUsers
    {
      public List<EmployeeData>? results { get; set; }
      // public Info? info { get; set; }
    }
    public class EmployeeData
    {
      public Name? name { get; set; }
      // public ID? id { get; set; }
      public Picture? picture { get; set; }
    }

    // public class Info
    // {
    //   public string? seed { get; set; }
    //   public int? results { get; set; }
    //   public int? page { get; set; }
    //   public string? version { get; set; }
    // }
    public class Picture
    {
      public string? large { get; set; }
      // public string? medium { get; set; }
      // public string? thumbnail { get; set; }
    }
    // public class ID
    // {
    //   public string? name { get; set; }
    //   public string? value { get; set; }
    // }
    public class Name
    {
      // public string? title { get; set; }
      public string? first { get; set; }
      public string? last { get; set; }
    }
    async public static Task<List<Employee>> GetFromRandomUserSite()
    {
      using (HttpClient client = new HttpClient())
      {
        List<Employee> employees = new List<Employee>();

        // create a random employee ID
        Random random = new Random();
        int randomEmployeeID = random.Next(100000);

        // request data for 5 random employees
        string response = await client.GetStringAsync("https://randomuser.me/api/?results=5&nat=us&inc=name,id,picture");
        RandomUsers? randomUsers = JsonSerializer.Deserialize<RandomUsers>(response);

        if (randomUsers?.results is not null) // this if statement should always be true; it is here to prevent a compiler warning
        {
          for (int i = 0; i < randomUsers?.results.Count; i++)
          {
            Employee currentEmployee = new Employee($"{randomUsers?.results[i]?.name?.first}", $"{randomUsers?.results[i]?.name?.last}", randomEmployeeID, $"{randomUsers?.results[i]?.picture?.large}");
            employees.Add(currentEmployee);
            randomEmployeeID++;
          }
        }

        return employees;
      }
    }
  }
}