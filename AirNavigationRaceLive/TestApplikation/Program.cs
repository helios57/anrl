using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;

namespace TestApplikation
{
    class Program
    {
        static void Main(string[] args)
        {
            Parcour p = new Parcour();
            Line newLine = new Line();
            newLine.Point.Add(new Point());
            p.EndPoint.Add(newLine);
            System.Console.Out.WriteLine(p.Serialize());
            System.Console.Read();
        }
    }
}
