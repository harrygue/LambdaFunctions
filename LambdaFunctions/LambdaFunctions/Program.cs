using System;

namespace LambdaFunctions
{
    delegate string ConvertMethod1(string inStr);
    delegate object DynamicFunc(params object[] parameters);

    class DelegateExample
    {
        public static string UppercaseString(string inputString)
        {
            return inputString.ToUpper();
        }
    }

    public class GenericFunc
    {
        
        public static string LowercaseString(string inStr)
        {
            return inStr.ToLower();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string surname = "Güntner";
            string prename = "Harald";
            string fullName = "Harald Güntner";

            // delegate
            ConvertMethod1 cm1 = DelegateExample.UppercaseString;

            // genericFunctions
            Func<string, string> cm2 = GenericFunc.LowercaseString;

            // anonymous
            Func<string, string> cm3 = delegate (string s)
            {
                return s.GetType().ToString();
            };

            // LambdaFunctions
            Func<string, int> cm4 = c => c.Length;
            Func<string, string, bool> cm5 = (a, b) => fullName.Equals(a + " " + b);

            Console.WriteLine(cm2(prename));
            Console.WriteLine(cm1(surname));
            
            Console.WriteLine(cm3(surname));
            Console.WriteLine(cm4(fullName));
            
            Console.WriteLine(cm5(prename, surname));
            Console.ReadKey();

            DynamicFunc f = par =>
            {
                foreach(var p in par)
                {
                    Console.Write(p+"/ ");
                    
                }
                Console.ReadKey();
                return null;
            };
            f(cm1(prename), cm2(surname), cm3(fullName), cm4(prename), cm5(prename, fullName));
        }
    }
}
