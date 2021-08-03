using System;

namespace Exceptions
{
    class Program
   {
        static void Main(string[] args)
        {
            try
            {
                ProcessFileWithRethrow();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                if (ex.InnerException is not null)
                {
                    Console.WriteLine("Inner exception:");
                    Console.WriteLine(ex.InnerException.Message);
                    Console.WriteLine(ex.InnerException.StackTrace);
                }
            }
        }

        private static void ProcessFile()
        {
            try
            {
                // TODO: Run in VS because DotNetFiddle doesn't handle console reads
                Console.Write("Enter directory path=");
                var directory = Console.ReadLine();

                Console.Write("Enter file name=");
                var fileName = Console.ReadLine();

                Console.Write("Lookup text=");
                var lookupText = Console.ReadLine();

                Console.Write("Replace with text=");
                var replaceWithText = Console.ReadLine();

                FileProcessor.ReplaceText(directory, fileName, lookupText, replaceWithText);
            }
            catch (Exception exLog) when (ExceptionFilters.LogException(exLog))
            {
                Console.WriteLine("This should never be caught!");
            }
            catch (ArgumentNullException argEx) when (ExceptionFilters.IsDirectoryOrFileException(argEx))
            {
                Console.WriteLine("Directory or file exception!");
            }
            catch (ArgumentNullException argEx) when (ExceptionFilters.IsFileContentReplaceException(argEx))
            {
                Console.WriteLine("Content replace exception!");
            }
            catch (Exception)
            {
                Console.WriteLine("Other exception occured!");
            }
        }

        private static void ProcessFileWithRethrow()
        {
            try
            {
                // TODO: Run in VS because DotNetFiddle doesn't handle console reads
                Console.Write("Enter directory path=");
                var directory = Console.ReadLine();

                Console.Write("Enter file name=");
                var fileName = Console.ReadLine();

                Console.Write("Lookup text=");
                var lookupText = Console.ReadLine();

                Console.Write("Replace with text=");
                var replaceWithText = Console.ReadLine();

                FileProcessor.ReplaceText(directory, fileName, lookupText, replaceWithText);
            }
            catch (Exception ex)
            {
                /* cod care face ceva cu exceptia */
                throw;
            }
        }
    }
}
