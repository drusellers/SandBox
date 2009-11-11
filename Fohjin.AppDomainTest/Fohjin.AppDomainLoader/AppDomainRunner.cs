using System;

namespace Fohjin.AppDomainLoader
{
    public class AppDomainRunner
    {
        public void RunInDifferentAppDomain(Action action)
        {
            AppDomain testerDomain = null;
            try
            {
                var testerSetup = new AppDomainSetup
                {
                    ApplicationBase = AppDomain.CurrentDomain.BaseDirectory, 
                    PrivateBinPath = Environment.CurrentDirectory, 
                    ApplicationName = "Your.Application.Name"
                };
                testerDomain = AppDomain.CreateDomain("GeneratedDomain", null, testerSetup);

                testerDomain.DoCallBack(new CrossAppDomainDelegate(action));
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                Console.ReadKey();
            }
            finally
            {
                if (testerDomain != null)
                {
                    AppDomain.Unload(testerDomain);
                }
                GC.Collect();
            }
        }
    }
}