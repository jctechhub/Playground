using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using static System.Console;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // if you want to build a simple HTML paragraph using StringBuilder
            var hello = "hello";
            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");
            Console.WriteLine(sb);

            // now I want an HTML list with 2 words in it
            var words = new[] { "hello", "world" };
            sb.Clear();
            sb.Append("<ul>");
            foreach (var word in words)
            {
                sb.AppendFormat("<li>{0}</li>", word);
            }
            sb.Append("</ul>");
            WriteLine(sb);


            // ordinary non-fluent builder
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "hello");
            builder.AddChild("li", "world");
            WriteLine(builder.ToString());


            // fluent builder
            sb.Clear();
            builder.Clear(); // disengage builder from the object it's building, then...
            builder.AddChildFluent("li", "hello")
                    .AddChildFluent("li", "world");
            WriteLine(builder);

            //build a list
            var builder1 = new HtmlBuilder("div");
            builder1.AddChild("p", "this is a long long text followed by List");
            builder1.AddList(ListStyle.OrderListWithNumber, new List<string>()
            {
                "this is the 1st",
                "this is the 2nd",
                "this is the 3rd"
            });
            builder1.AddList(ListStyle.UnorderList, new List<string>()
            {
                "this is the 4",
                "this is the 5",
                "this is the 6"
            });
            builder1.AddList(ListStyle.OrderListWithAlphaUpper, new List<string>()
            {
                "this is the 4",
                "this is the 5",
                "this is the 6"
            });
            builder1.AddList(ListStyle.OrderListWithRomanLower, new List<string>()
            {
                "this is the 4",
                "this is the 5",
                "this is the 6"
            });
            Console.WriteLine(builder1.ToString());
            Console.Read();
        }
    }

    public enum ListStyle
    {
        UnorderList,
        OrderListWithNumber,
        OrderListWithAlphaLower,
        OrderListWithAlphaUpper,
        OrderListWithRomanLower,
        OrderListWithRomanUpper
    }

    class HtmlBuilder
    {
        HtmlElement root = new HtmlElement();
        private readonly string rootName;

        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }

        // not fluent
        public void AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
        }

        public HtmlBuilder AddList(ListStyle style, List<string> textList)
        {
            var listRoot = new HtmlElement();
            var listTop = "ul";
            var listStyle = "1";

            switch (style)
            {
                case ListStyle.UnorderList:
                    listTop = "ul";
                    listStyle = "";
                    break;
                case ListStyle.OrderListWithAlphaLower:
                    listTop = "ul";
                    listStyle = "a";
                    break;
                case ListStyle.OrderListWithAlphaUpper:
                    listTop = "ul";
                    listStyle = "A";
                    break;
                case ListStyle.OrderListWithRomanLower:
                    listTop = "ul";
                    listStyle = "i";
                    break;
                case ListStyle.OrderListWithRomanUpper:
                    listTop = "ul";
                    listStyle = "I";
                    break;
                case ListStyle.OrderListWithNumber:
                    listTop = "ul";
                    listStyle = "1";
                    break;
            }

            listRoot.Name = listTop;
            listRoot.styling = string.IsNullOrEmpty(listStyle) ? "" : $"type='{listStyle}'";
            textList.ForEach(x => { listRoot.Elements.Add(new HtmlElement("li", x)); });
            root.Elements.Add(listRoot);
            return this;
        }

        public HtmlBuilder AddChildFluent(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HtmlElement {Name = rootName};
        }


    }



    class HtmlElement
    {
        public string Name, Text, styling;
        public List<HtmlElement> Elements = new List<HtmlElement>();
        private const int indentSize = 2;

        public HtmlElement()
        {
        }

        public HtmlElement(string name, string text)
        {
            Name = name;
            Text = text;
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);
            if (string.IsNullOrEmpty(styling))
            {
                sb.Append($"{i}<{Name}>\n");
            }
            else sb.Append($"{i}<{Name} {styling}>\n");

            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.Append(Text);
                sb.Append("\n");
            }

            foreach (var e in Elements)
                sb.Append(e.ToStringImpl(indent + 1));

            sb.Append($"{i}</{Name}>\n");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }



}


