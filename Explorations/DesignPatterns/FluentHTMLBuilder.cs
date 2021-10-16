using System;
using System.Collections.Generic;
using System.Text;


public class FluentHtmlBuilder
{
    private readonly string rootName;
    private List<HtmlElement> childElements;

    public FluentHtmlBuilder(string rootName)
    {
        this.rootName = rootName;
        this.childElements = new List<HtmlElement>();
    }

    public FluentHtmlBuilder AddChild(string childName, string childText)
    {
        var element = new HtmlElement(childName, childText);
        childElements.Add(element);

        return this;
    }

    public string Build()
    {
        var stringBuilder = new StringBuilder();
        AppendStartingTag(rootName, stringBuilder);
        foreach (var element in childElements)
        {
            AppendStartingTag(element.name, stringBuilder);
            stringBuilder.Append(element.text);
            AppendEndingTag(element.name, stringBuilder);
        }
        AppendEndingTag(rootName, stringBuilder);
        return stringBuilder.ToString();
    }

    private void AppendStartingTag(string tag, StringBuilder stringBuilder)
    {
        stringBuilder.Append('<');
        stringBuilder.Append(tag);
        stringBuilder.Append('>');

    }

    private void AppendEndingTag(string tag, StringBuilder stringBuilder)
    {
        stringBuilder.Append("</");
        stringBuilder.Append(tag);
        stringBuilder.Append('>');
    }
}

public class HtmlElement
{
    public string name;
    public string text;

    public HtmlElement(string name, string text)
    {
        this.name = name;
        this.text = text;
    }
}