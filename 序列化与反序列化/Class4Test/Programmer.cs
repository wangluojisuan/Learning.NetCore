using System;
using System.Collections.Generic;
using System.Text;

namespace Class4Test
{
    [Serializable]
    public class Programmer : Person
    {
        public String Language
        {
            get;
            set;
        }
        public Programmer() { }
        public Programmer(String name, Boolean isMan, String language) : base(name, isMan)
        {
            this.Language = language;
        }

        public override string ToString()
        {
            return base.ToString() + "\t语言：" + this.Language;
        }
    }
}
