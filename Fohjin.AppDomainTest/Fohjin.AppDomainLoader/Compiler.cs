using System;
using System.CodeDom.Compiler;
using System.Reflection;
using Microsoft.CSharp;

namespace Fohjin.AppDomainLoader
{
    [Serializable]
    public class Compiler
    {
        public TExpectedType CompileCode<TExpectedType>(string CSharpCode)
        {
            CSharpCodeProvider cSharpCodeProvider = null;
            CompilerResults compileAssemblyFromSource;
            try
            {
                cSharpCodeProvider = new CSharpCodeProvider();
                var compilerParameters = new CompilerParameters
                    {
                        GenerateExecutable = false, 
                        GenerateInMemory = true, 
                        IncludeDebugInformation = true
                    };

                // Add dependencies
                compilerParameters.ReferencedAssemblies.Add("System.dll");
                compilerParameters.ReferencedAssemblies.Add("Fohjin.AppDomainLoader.dll");

                compileAssemblyFromSource = cSharpCodeProvider.CompileAssemblyFromSource(compilerParameters, CSharpCode);
                var compiledAssembly = (TExpectedType)compileAssemblyFromSource.CompiledAssembly.CreateInstance("Fohjin.AppDomainTest.GeneratedAssembly.SomeClass");

                if (compileAssemblyFromSource.Errors.Count > 0)
                {
                    foreach (CompilerError err in compileAssemblyFromSource.Errors)
                    {
                        Console.WriteLine(err.ToString());
                    }
                }
                return compiledAssembly;
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                throw Ex;
            }
            finally
            {
                if (cSharpCodeProvider != null)
                {
                    cSharpCodeProvider.Dispose();
                }
            }
        }
    }
}