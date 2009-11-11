using System;

namespace Fohjin.AppDomainLoader
{
    [Serializable]
    public class CreateNewAssembliesAndUseThem
    {
        private readonly Compiler _compiler;
        public const string cShaprCode = @"
            using System;
            using Fohjin.AppDomainLoader;

            namespace Fohjin.AppDomainTest.GeneratedAssembly
            {
	            [Serializable]
                public class SomeClass : ISomeClass
                {
                    public void DoSomething(string name)
                    {
                        if (SomethingWasDone != null)
                            SomethingWasDone(string.Format(""Hey {0} this is a message"", name));
                    }

                    public event EventAction SomethingWasDone;
                }
            }
        ";

        public event EventAction SomethingWasDone;

        public CreateNewAssembliesAndUseThem()
        {
            _compiler = new Compiler();
        }

        public void CreateAssemblyAndUseIt()
        {
            var someClass = _compiler.CompileCode<ISomeClass>(cShaprCode);
            someClass.SomethingWasDone += someClass_SomethingWasDone;
            someClass.DoSomething("Mark Nijhof");
            someClass.SomethingWasDone -= someClass_SomethingWasDone;
        }

        private void someClass_SomethingWasDone(string message)
        {
            if (SomethingWasDone != null)
                SomethingWasDone(message);
        }
    }
}