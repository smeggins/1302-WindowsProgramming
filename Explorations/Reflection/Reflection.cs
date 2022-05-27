using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Explorations
{
    /// <summary>
    /// Assebly C# compiles into has: compiled code, metadata, resources
    /// reflections allows us to inspect the emtadata and compiled code at run-time
    /// </summary>
    public class ReflectionExploration
    {
        Type t1 = DateTime.Now.GetType();   //obtained at run-time
        Type t2 = typeof(DateTime);         //obtained at compile time
        Type t3 = Assembly.GetExecutingAssembly().GetType("Explorations.ReflectionExploration");         //obtained at compile time


        public void PrintTypeInformation(Type t)
        {
            Type BaseType = t.BaseType;
            Assembly assembly = t.Assembly;
            bool isPublic = t.IsPublic;
            bool isClass = t.IsClass;

            Console.WriteLine(  $"\n\n{t.FullName}:" +
                                $"\n    BaseType: {BaseType}, " +
                                $"\n    assembly: {assembly}, " +
                                $"\n    isPublic: {isPublic}, " +
                                $"\n    isClass: {isClass}, ");
        }

        public void PrintInterface(Type t)
        {
            Console.WriteLine($"\n\n{t.FullName}:");
            foreach (var item in t.GetInterfaces())
            {
                Console.WriteLine($"    {item.Name}");
            }
        }

        public void InterfaceType()
        {
            var t = typeof(int);
            int i1 = (int)Activator.CreateInstance(t);
            i1 = 323;
            Console.WriteLine($"i1 = {i1}");

            DateTime dt = (DateTime)Activator.CreateInstance(typeof(DateTime), 2021, 11, 20);
            Console.WriteLine($"dt Year: {dt.Year}, dt Month: {dt.Month}, dt Day: {dt.Day}");
        }

        public void PrintTypeMembers(Type t)
        {
            Console.WriteLine("\n===public members===");

            MemberInfo[] members = t.GetMembers();
            foreach (var item in members)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n===methods===");

            var methods = t.GetMethods();
            foreach (var item in methods)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n===constructors===");

            MemberInfo[] constructors = t.GetConstructors();
            foreach (var item in constructors)
            {
                Console.WriteLine(item);
            }
        }

        public void InvokeMember()
        {
            var s1 = "Stamp collection";
            Console.WriteLine(s1.Substring(5));

            Type t = typeof(string);
            Type[] paramTypes = { typeof(int) };
            MethodInfo methodInfo = t.GetMethod("Substring", paramTypes);

            object[] arguments = { 5 };
            object returnValue = methodInfo.Invoke(s1, arguments);

            Console.WriteLine($"returned from calling the substring with reflection: {returnValue}");
        }

        public void GetMethodsParameters()
        {
            Type t = typeof(ReflectionExploration);

            MethodInfo methodInfo = t.GetMethod("PrintTypeInformation");
            ParameterInfo[] parameters = methodInfo.GetParameters();
            foreach (var item in parameters)
            {
                Console.WriteLine($"param name: {item} - param type: {item.ParameterType}");
            }
        }

        public static void Test()
        {
            ReflectionExploration reflection = new ReflectionExploration();
            reflection.PrintTypeInformation(reflection.t1);
            reflection.PrintTypeInformation(reflection.t2);
            reflection.PrintTypeInformation(reflection.t3);

            reflection.PrintInterface(reflection.t1);
            reflection.PrintInterface(reflection.t2);
            reflection.PrintInterface(reflection.t3);

            reflection.PrintInterface(typeof(Guid));
            object obj = Guid.NewGuid();
            bool isType = obj is IFormattable;

            Console.WriteLine("\n\n");
            Console.WriteLine($"Guid is Iformattable: {isType}");

            Type target = typeof(IFormattable);
            bool isAlsoType = target.IsInstanceOfType(obj);

            Console.WriteLine("\n\n");
            Console.WriteLine($"IFormattable is an obj type: {isAlsoType}");

            Type t = typeof(int);
            reflection.InterfaceType();
            //Console.WriteLine($"reflections.t1: {reflection.t1}");

            Console.WriteLine("\n\n");
            reflection.PrintTypeMembers(typeof(ReflectionExploration));

            Console.WriteLine("\n\n");
            reflection.InvokeMember();

            Console.WriteLine("\n\n");
            reflection.GetMethodsParameters();
        }

    }
}
