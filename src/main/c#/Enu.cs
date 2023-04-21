using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace oop_midterm
{
    struct Database
    {
        public string id;
        public int extraWorkHrs;
        public int workHrsSum;
    }

    internal class Enu
    {
        private enum Status
        {
            abnorm,
            norm
        }

        private TextFileReader fileReader;
        public Database current;
        private string row;
        Status status;
        bool end;

        public Enu(string filename)
        {
            fileReader = new TextFileReader(filename);
        }

        private void Read()
        {
            status = fileReader.ReadLine(out row) ? Status.norm : Status.abnorm;
        }

        public void First()
        {
            Read();
            Next();
        }

        public bool End()
        {
            return end;
        }

        public void Next()
        {
            end = Status.abnorm == status;

            if (!end)
            {
                string[] data = row.Split(' ');
                current.id = data[0];
                current.extraWorkHrs = int.Parse(data[1]);

                current.workHrsSum = 0;
                while (status == Status.norm && row.Split(' ')[0].Equals(current.id))
                {
                    //Console.WriteLine($"{current.id} {current.extraWorkHrs}");
                    //Console.WriteLine(row);
                    //Console.WriteLine(current.extraWorkHrs);
                    //Console.WriteLine($"{current.id} {current.extraWorkHrs}");
                    current.workHrsSum += int.Parse(row.Split(' ')[1]);
                    Read();
                }
            }
        }
    }
}
