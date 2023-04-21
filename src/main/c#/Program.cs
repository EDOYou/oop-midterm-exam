namespace oop_midterm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool fileError = true;
            do
            {
                try
                {
                    Console.WriteLine("Enter the file name: ");
                    string filename = Console.ReadLine();
                    Enu e = new Enu(filename);

                    e.First();
                    int max = 0;
                    string maxID = "";
                    while (!e.End())
                    {
                        if (max < e.current.workHrsSum)
                        {
                            max = e.current.workHrsSum;
                            maxID = e.current.id;
                        }
                        e.Next();
                    }
                    Console.WriteLine($"{maxID} -> {max} hours");
                    fileError = false;
                }
                catch (System.IO.FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("\nFile not found.\n");
                }
            } while (fileError);
        }
    }
}
