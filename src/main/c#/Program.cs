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
                        //Console.WriteLine(max);
                        if (max < e.current.workHrsSum)
                        {
                            max = e.current.workHrsSum;
                            //Console.WriteLine(e.current.w);
                            maxID = e.current.id;
                        }
                        //Console.WriteLine(max);
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
