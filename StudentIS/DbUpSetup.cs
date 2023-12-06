using DbUp;
using System.Reflection;

namespace StudentIS
{
    public static class DbUpSetup
    {
        public static void DbSetup() {
            EnsureDatabase.For.PostgresqlDatabase("User ID=postgres;Password=115711;Host=localhost;Port=5432;Database=students_is;");

            var upgrader =
                DeployChanges.To
                    .PostgresqlDatabase("User ID=postgres;Password=115711;Host=localhost;Port=5432;Database=students_is;")
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
            }
        }

    }
}
