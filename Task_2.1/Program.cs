using System;
using Task_2._1.ProgramException;

namespace Task_2._1
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                ERP_ReportsBot.Start();
            }
            catch (FileReadException ex)
            {
                Console.WriteLine(ex.Exception.Message);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 1;
            }
            return 0;
        }
    }
}
