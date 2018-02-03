using System;

namespace TddBook
{
    public class TheClass
    {
        protected virtual string Property1 { get; set; }

        public string GetProperty1()
        {
            return Property1;
        }

        internal string Property2 { get; set; }

        public string GetProperty2()
        {
            return Property2;
        }

        protected virtual string Method1(int arg1)
        {
            throw new NotImplementedException();
        }

        public string GetValueFromMethod1(int arg1)
        {
            return Method1(arg1);
        }
    }
}
