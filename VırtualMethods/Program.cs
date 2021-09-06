using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VırtualMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlServer sqlServer = new SqlServer();
            sqlServer.Add();
            MySQL mySql = new MySQL();
            mySql.Add();

            Console.ReadLine();
        }

        class Database
        {
            public virtual void Add()
            {
                Console.WriteLine("Added by default");
            }

            public virtual void Delete()
            {
                Console.WriteLine("Deleted by default");
            }
        }

        class  SqlServer:Database
        {
            public override void Add()
            {
                Console.WriteLine("Added by sql code");
                base.Add();
            }
        }
        class MySQL:Database
            {
                
            }
    }
}
