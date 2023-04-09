using System.Reflection;

class Program
{
   static void Main(string[] args)
   {
      var className = ClasseHelper<PrintOnScreen>.GetClassName();
      var method = ClasseHelper<PrintOnScreen>.GetMethod("writeanytext");

      PrintOnScreen printName = new PrintOnScreen();

      System.Console.WriteLine($"class name : {className}");
      System.Console.WriteLine($"method name: {method.Name}");

      method.Invoke(printName, new object[] { "running method by reflection!" });

   }
}

public static class ClasseHelper<T> where T : class
{
   public static string GetClassName() => typeof(T).Name;

   public static MethodInfo GetMethod(string methodName)
   {
      var allMethods = typeof(T).GetMethods();

      return allMethods.FirstOrDefault(m => m.Name.Equals(methodName, System.StringComparison.InvariantCulture));
   }
}

public class PrintOnScreen
{
   public static void writeanytext(string message) => System.Console.WriteLine(message);
}