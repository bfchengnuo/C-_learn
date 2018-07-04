using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello github");
            Person2 p2 = new Person2();
            p2.Age = 7;
            Console.WriteLine(p2.Age.ToString());

            Console.ReadKey();
        }
    }
    class Person2

      

    {
        /// <summary>
        /// 字段的首字母小写，属性的首字母大写
        /// </summary>
        private int age;
        public int Age
        {
            set
            {
                this.age = value;
            }
            get
            {
                return this.age;
            }
        }

    }

    class Person4
    {
        public int Age
        {
            set { }
            //属性中不会进行储存数据，他只能更改数据。
            get
            {
                return 3;
            }
        }

    }

    class robot
    {
        

    }
}
