using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1.ProgramException
{
    class FileReadException : Exception
    {
        public Exception Exception { get; }

        public FileReadException(Exception ex)
        {
            Exception = ex;
        }
    }
}
