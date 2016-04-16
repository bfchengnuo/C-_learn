using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication3
{
    class Student
    {
        public Student()
        {
 
        }

        public Student(string clazz)
        {
            _stuClass = clazz;
        }

        private string _stuID;
        private string _stuName;
        private string _stuClass;

        public string stuID
        {
            get { return _stuID;}
            set { _stuID = value; }
        }

        public string stuName
        {
            get { return _stuName; }
            set { _stuName = value; }
        }

        public string stuClass
        {
            get { return _stuClass; }
            set { _stuClass = value; }
        }

    }
}
