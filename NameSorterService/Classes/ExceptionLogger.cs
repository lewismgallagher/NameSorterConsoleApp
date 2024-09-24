
namespace NameSorterService.Classes
{
    public static class ExceptionLogger
    {
        public static void LogException(Exception ex)
        {
            // would have middleware to catch unhandled exceptions and log them (E.g. Application Insight, Exceptionless,etc)
            Console.WriteLine(ex.Message);
        }
    }
}
