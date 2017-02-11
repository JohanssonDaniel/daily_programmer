using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daily_programmer
{
    class Histogram
    {
        public static void Draw(string[] file)
        {
            //The first of the line contains for number
            //The first two numbers decides the scope of the x axel
            // The third and fourth number decides the scope of the y axel 
            string[] histoInfo = file[0].Split(' ');
            const int NUMOFDATA = 2;
            //Parse the data
            int x0 = Int32.Parse(histoInfo[0]);     //start of x-axis
            int x1 = Int32.Parse(histoInfo[1]);     //end of x-axis
            int y0 = Int32.Parse(histoInfo[2]);     //start of y-axis
            int y1 = Int32.Parse(histoInfo[3]);     //end of y-axis

            //The second line of the file indicates the number of datapoints
            int numOfDataPoints = Int32.Parse(file[1]);

            int xRange = (x1 - x0) / numOfDataPoints;

            string[][] data = new string[numOfDataPoints][];

            for (int i = 0; i < numOfDataPoints; i++)
            {
                data[i] = new string[NUMOFDATA];
            }
            
            //Retrieve the datapoints 
            for (int i = 0; i < numOfDataPoints; i++)
            {
                data[i] = file[i + 2].Split(' ');  //Already selected the first two lines
            }
            
            string[][] histogram = new string[y1 + 1][];

            for (int i = 0; i < histogram.Length; i++)
            {
                histogram[i] = new string[numOfDataPoints + 1];
            }
            
            //Adding y-axel
            //For the y-axel the largest number should be on top (i.e histogram[0]) and lowest on the bottom (histogram[y1])
            //The i(index) will count up and j(value) will go down every iteration
            for (int i = 0, j = y1; i < y1; i++, j--)
            {
                int temp = j;
                histogram[i][0] = temp.ToString();
            }

            /*Adding x-axel
            * Inserting a blank space between all numbers shifts them to the right without needing to double the 
            * Array and insert blank space to its own index
            */
            for (int x = 0; x < numOfDataPoints + 1; x++)
            {
                int temp = x * xRange + x0;
                histogram[y1][x] = "  " + temp.ToString();
            }

            /*
                Printing data
            */
            for (int i = 1; i < y1; i++)
            {
                for (int j = 1; j < numOfDataPoints + 1; j++)
                {
                    string temp = Int32.Parse(data[j - 1][2]) >= i ? "   *" : "    ";
                    histogram[y1 - i][j] = temp; 
                }
            }
            foreach (string[] line in histogram)
            {
                foreach (string dataPoint in line)
                {
                    Console.Write(dataPoint);
                }
                Console.Write("\n");
            }
        }
    }
}
