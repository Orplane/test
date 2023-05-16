using System;
using System.Collections.Specialized;
using System.Configuration;

namespace MyNamespace
{
    class MyClass
    {
        public void MyMethod()
        {
            string environment = GetEnvironment();
            string key = "Key1";
            string value = GetConfigValue(key, environment);

            Console.WriteLine($"{key} Value: {value}");
        }

        private string GetEnvironment()
        {
#if DEBUG
            return "Debug";
#else
                return "Release";
#endif
        }

        private string GetConfigValue(string key, string environment)
        {
            NameValueCollection settings;

            if (environment == "Debug")
            {
                settings = ConfigurationManager.GetSection("AppDebugSettings") as NameValueCollection;
            }
            else
            {
                settings = ConfigurationManager.GetSection("AppReleaseSettings") as NameValueCollection;
            }

            return settings?[key];
        }
    }

    class Program
    {
        static void Main()
        {
            MyClass myObject = new MyClass();
            myObject.MyMethod();
        }
    }
}
