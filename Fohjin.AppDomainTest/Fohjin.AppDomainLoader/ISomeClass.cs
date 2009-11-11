using System;
using Fohjin.AppDomainLoader;

namespace Fohjin.AppDomainLoader
{
    public delegate void EventAction(string message);

    public interface ISomeClass
    {
        void DoSomething(string name);
        event EventAction SomethingWasDone;
    }
}

//namespace Fohjin.AppDomainTest.GeneratedAssembly
//{
//    [Serializable]
//    public class SomeClass : ISomeClass
//    {
//        public void DoSomething(string name)
//                    {
//                        if (SomethingWasDone != null)
//                            SomethingWasDone(string.Format(""Hey {0} this is a message"", name));
//                    }

//        public event EventAction SomethingWasDone;
//    }
//}
