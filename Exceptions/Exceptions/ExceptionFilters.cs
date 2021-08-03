using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public static class ExceptionFilters
    {
        public static bool IsDirectoryOrFileException(Exception ex)
        {
            var isDirOrFileException =
                (
                  (ex is ArgumentNullException argNullEx)
                  && (
                        string.Equals(argNullEx.ParamName, "directory", StringComparison.OrdinalIgnoreCase)
                        || string.Equals(argNullEx.ParamName, "fileName", StringComparison.OrdinalIgnoreCase)
                     )
                )
                || (ex is DirectoryNotFoundException)
                || (ex is FileNotFoundException);

            return isDirOrFileException;
        }

        public static bool IsFileContentReplaceException(Exception ex)
        {
            var isFilContentReplaceException =
                (
                  (ex is ArgumentNullException argNullEx)
                  && (
                        string.Equals(argNullEx.ParamName, "searchText", StringComparison.OrdinalIgnoreCase)
                        || string.Equals(argNullEx.ParamName, "replaceWithText", StringComparison.OrdinalIgnoreCase)
                     )
                );

            return isFilContentReplaceException;
        }

        public static bool LogException(Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);

            return false;
        }
    }
}
