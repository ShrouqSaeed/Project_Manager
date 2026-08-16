namespace Event_Project
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Ensure DB and tables exist
            DatabaseHelper.EnsureDatabaseCreated();

            if (args.Length > 0 && args[0] == "--test")
            {
                try
                {
                    DatabaseTester.RunTests();
                    Environment.Exit(0);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("Database test failure: " + ex.Message);
                    Environment.Exit(1);
                }
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
