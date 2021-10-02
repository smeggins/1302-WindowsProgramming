using System;
using System.Text;
using System.Collections.Generic;
using System.Text;

// Builder pattern is used in the creation  of complicated objects

class stringBuilderClassExample
{
    private static string text = "this is a string";
    
    public static void example()
    {
        var builder = new StringBuilder();
        builder.Append(text);
        builder.Append(", ");
        builder.Append("0");
        string newText = builder.ToString();
    }
}

/*
 * builder used to create something like this without appending all these values to a string
 * The benefit is that when you append to a string it actually creates and entirely new string which is a expensive operation.
 <HTML>
    <child></child>
    <child></child>
</HTML>
 */
class HTMLBuilder
{
    private readonly string rootName;
    private List<HTMLElement> childElements;
    public HTMLBuilder(string rootName)
    {
        this.rootName = rootName;
        this.childElements = new List<HTMLElement>();
    }
    public void addChild(string childName, string childText)
    {
        var element = new HTMLElement(childName, childText);
        childElements.Add(element);
    }

    public string build()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.Append("<" + rootName + ">");
        foreach (var item in childElements)
        {
            stringBuilder.Append("<" + item.name + ">");
            stringBuilder.Append(item.text);
            stringBuilder.Append("</" + item.name + ">");
        }
        stringBuilder.Append("<" + rootName + ">");

        return stringBuilder.ToString();
    }

    public static void test()
    {
        var htmlBuilder = new HTMLBuilder("html");

        htmlBuilder.addChild("div", "name");
        htmlBuilder.addChild("li", "test1");
        htmlBuilder.addChild("li", "test2");

        Console.WriteLine(htmlBuilder.build());
    }
}

public class HTMLElement
{
    public string name;
    public string text;
    public HTMLElement(string name, string text)
    {
        this.name = name;
        this.text = text;
    }
}
