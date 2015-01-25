using System;
using System.Reflection;
using System.IO;

namespace MyTest
{
    class MainClass
    {
        public static void Main ()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (object sender, ResolveEventArgs args) => 
            {
                var an = new AssemblyName(args.Name);
                Console.WriteLine ("AssemblyResolve=" + an.Name + " from assembly " + args.RequestingAssembly);

                var target = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "both", an.Name + ".dll");

                Console.WriteLine ("Trying to load assembly from PATH=" + target);

                if (File.Exists(target)) 
                {
                    return Assembly.LoadFile(target);
                }

                return null;
            };

            Console.WriteLine("AppDomain base path is {0}", AppDomain.CurrentDomain.BaseDirectory);

            try
            {
                var a1 = Assembly.Load ("TestLib1");

                var m1 = a1.GetType("TestLib1.MyClass2");
                var foo = m1.GetMethod("Foo", BindingFlags.Public | BindingFlags.Static);


                foo.Invoke(null, new object[0]);
            }
            catch(Exception ex)
            {
                Console.WriteLine ("Something failed: " + ex);
            }
        }
    }
}
