using System;
using System.Collections.Generic;
using System.Text;


/*
 Design Patterns:
 Singleton:
 Used when you have data that you want to instantiate once and you want it to be protected from being instantiated again.
Typically use with large data pools that you want loaded in memory for quick access that you want to ensure isn't being duplicated (thus wasting memory)
Also used if you have very specific data that needs to be unique with only 1 instance ever existing.

 */

/// <summary>
/// this is whats called a singleton class. Note the class it'self would not normally be called singleton
/// </summary>


/// This first class is not thread safe. it could create 2 instances of singleton if thread 2 arrives on the if statement before or at the same time thread 1 reaches the instance instantiation.
public class Singleton
{
    private static Singleton instance = null;
    public static Singleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Singleton();
            }

            return instance;
        }
    }
}


// the below solves the issue by creating a lock that with initialize when one isntance of the if statement has been ran 
public class Singleton2
{
    private static Singleton2 instance = null;
    private static readonly object padlock = new object();

    public static Singleton2 Instance
    {
        get
        {
            lock (padlock)
                if (instance == null)
                {
                    instance = new Singleton2();
                }

            return instance;
        }
    }
}

// this also fixes the threading issue
// sealed means the class cannot be inherited
// when you pair static with readonly it makes the instance only able to be set once (the first time it is activated)
public sealed class Singleton3
{
    private Singleton3() { }
    private static readonly Singleton3 instance = new Singleton3();

    public static Singleton3 Instance
    {
        get
        {
            return instance;
        }
    }
}

// BEST SOLUTION
// Lazy is only ran once, when first accessed. after instantiated values are accessed by... well, the keyword    .Value
public sealed class Singleton4
{
    private static readonly Lazy<Singleton4> instance = new Lazy<Singleton4>( () => new Singleton4());

    public static Singleton4 Instance
    {
        get
        {
            return instance.Value;
        }
    }
}

// this is a working version on the above singleton

public sealed class Singleton5
{
    private List<string> configs;
    // this lazy means that until this class is accessed it won't instantiate it'self
    private static readonly Lazy<Singleton5> instance = 
        new Lazy<Singleton5>();

    // the private constructor
    public Singleton5()
    {
        configs = new List<string>()
            {
                "123",
                "456"
            };
    }

    // this is the method by which you will access this class 
    // ie Singleton5.Instance
    // once called the lazy var above will execute.
    public static Singleton5 Instance
    {
        get
        {

            return instance.Value;
        }
    }

    // Now you can access the values using Singleton5.Instance.GetConfigs();
    public List<string> getConfigs()
    {
        return configs;
    }
}