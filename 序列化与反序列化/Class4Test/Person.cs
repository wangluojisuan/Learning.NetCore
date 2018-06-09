using System;
using System.Collections.Generic;
using System.Text;

namespace Class4Test
{
    [Serializable]
    public class Person
    {
        public String Name
        {
            get;
            set;
        }

        protected Boolean IsMan
        {
            get;
            set;
        }
        public Person() { }
        public Person(String name, Boolean isMan)
        {
            this.Name = name;
            this.IsMan = isMan;
        }

        public override string ToString()
        {
            return "姓名：" + this.Name + "\t性别：" + (this.IsMan ? "男" : "女");
        }
    }
}
