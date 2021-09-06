using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new oracle();
            database.add();
            database.Delete();


            Database database2 = new oracle();
            database.add();
            database.Delete();

            Console.ReadLine();

        }
    }

    abstract class Database
    {
        public void add()
        {
            Console.WriteLine("Added by default");
        }

        public abstract void Delete();

    }

    class SqlServer : Database
    {
        public override void Delete()
        {
            Console.WriteLine("Deleted by Sql");
        }
    }

    class oracle : Database
    {
        public override void Delete()
        {
            Console.WriteLine("Deleted by  Oracle");
        }
    }
}
