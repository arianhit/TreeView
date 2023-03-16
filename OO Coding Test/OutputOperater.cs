using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_Coding_Test
{
    public class OutputOperater
    {
        public void makeItColor(ConsoleColor color, string text)
        {
            //save the defualt color
            ConsoleColor beforeColor = Console.ForegroundColor;
            //set the color
            Console.ForegroundColor = color;
            //out put the text
            Console.WriteLine(text);
            //make console color as a defualt
            Console.ForegroundColor = beforeColor;
        }

        public void outPutError(string message)
        {
            //save the defualt color 
            ConsoleColor beforeRed = Console.ForegroundColor;
            //make console color red
            Console.ForegroundColor = ConsoleColor.Red;
            //add the default value in the first part of the text
            Console.Write("[ERROR]: ");
            //make console color as a defualt
            Console.ForegroundColor = beforeRed;
            //out put the text
            Console.WriteLine(message);

        }
    }
}
