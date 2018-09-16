using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace HW8
{
    class Program
    {
        static void Main(string[] args)
        {
            #region HW 8 A)
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            //Create list of Shape and fill it with 6 different shapes (Circle and Square)
            List<Shape> shapesList = new List<Shape>(6);
            shapesList.Add(new Square("Square #1", 1));
            shapesList.Add(new Circle("Circle #1", 0.794));
            shapesList.Add(new Square("Square #2", 2));
            shapesList.Add(new Circle("Circle #2", 5));
            shapesList.Add(new Square("Square #3", 5.3));
            shapesList.Add(new Circle("Circle #3", 6));
            foreach (var k in shapesList)
            {
                Console.WriteLine(k);
            }
            Console.WriteLine("\nPress any key to:" +
                "\n- create file Range_Sapes.txt, which contains a list of shapes with an area from the range [10,100];" +
                "\n- create file Shapes_contain_A.txt, which contains a list of shapes which name contains letter 'a';" +
                "\n- remove from the list all shapes with perimeter less than 5 and output resulted list into Console.");
            Console.ReadKey();
            //Find and write into the file shapes with area from range [10,100]
            StreamWriter writeRangeShapes = new StreamWriter("Range_Sapes.txt");
            try
            {
                var shapesInRange = from sh in shapesList where sh.Area() >= 10 where sh.Area() <= 100 select sh;
                foreach (var shape in shapesInRange)
                {
                    writeRangeShapes.WriteLine(shape);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
            finally { writeRangeShapes.Close(); }
            //Find and write into the file shapes which name contains letter 'a'
            StreamWriter writeAShapes = new StreamWriter("Shapes_contain_A.txt");
            try
            {
                var shapesInRange = from sh in shapesList where sh.Name.Contains("a") select sh;
                foreach (var shape in shapesInRange)
                {
                    writeAShapes.WriteLine(shape);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
            finally { writeAShapes.Close(); }
            //Find and remove from the list all shapes with perimeter less then 5
            Console.Clear();
            Console.WriteLine("Shapes with perimeter less then 5:");
            #region Other way
            //foreach (var shape in shapesList.Where(sh => sh.Perimeter() < 5))
            //{
            //    Console.WriteLine(shape);
            //}
            #endregion
            shapesList.RemoveAll((sh => sh.Perimeter() < 5));
            foreach (var shape in shapesList)
            {
                Console.WriteLine(shape);
            }
            Console.WriteLine("\nPress any key to exit ...");
            Console.ReadKey();
            #endregion

            #region HW 8 B)
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            //Read all lines of text from file into array of strings
            string[] linesFromFile = File.ReadAllLines("Text.txt");
            //Count and write the number of symbols in every line
            Console.WriteLine("Number of symbols in every line from file(Text.txt):\n");
            int lineNumb = 1;
            foreach(var line in linesFromFile)
            {
                Console.WriteLine($"Line №{lineNumb} contains {line.Count()} symbols.");
                lineNumb++;
            }
            Console.WriteLine("\nPress any key to see the longest and shortest line ...");
            Console.ReadKey();
            Console.Clear();
            //Find the longest and the shortest line
            var longestLine = linesFromFile.OrderByDescending(l => l.Length).First();
            Console.WriteLine($"Longest line in Text.txt file: \n'{longestLine}'\n\n");
            var shortestLine = linesFromFile.OrderBy(l => l.Length).First();
            Console.WriteLine($"Shortest line in Text.txt file: \n'{shortestLine}'");
            Console.WriteLine("\nPress any key to see lines, which consist of word 'var' ...");
            Console.ReadKey();
            Console.Clear();
            //Find and write only lines, which consist of word "var"
            Console.WriteLine("lines, which consist of word 'var':\n");
            #region Other Way
            //foreach(var line in linesFromFile)
            //{
            //    if(line.Contains("var"))
            //    Console.WriteLine(line);
            //}
            #endregion
            var lineVar = linesFromFile.Where(l => l/*.Contains*/ == "var");
            foreach (var line in lineVar)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("\nPress any key to exit ...");
            Console.ReadKey();
            #endregion
        }
    }
}
