using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FormulaBitOne
{
    static void Main()
    {
        int[,] matrix = new int[8, 8];

        //matrix input
        for (int rows = 0; rows < 8; rows++)
        {
            int temp = int.Parse(Console.ReadLine());

            for (int cols = 0; cols < 8; cols++)
            {
                matrix[rows, cols] = (temp >> cols) & 1;
            }
        }

        //solution
        int counter = 0;
        int turnsCounter = -1;
        int currCellRow = 0;
        int currCellCol = 0;
            
            
        //start cell
        if (matrix[currCellRow, currCellCol] == 0)
        {
            counter++;
        }
        else 
        {
            Console.WriteLine("No 0");
            return;
        }

        bool movedLeft = true;
        bool down = movedLeft && currCellRow + 1 < 8 && matrix[currCellRow + 1, currCellCol] == 0;
        bool left = currCellCol + 1 < 8 && matrix[currCellRow, currCellCol + 1] == 0;
        bool up = movedLeft && currCellRow - 1 >= 0 && matrix[currCellRow - 1, currCellCol] == 0;

        while (down || left || up)
        {
            //down
            if (!(currCellRow == 7 && currCellCol == 7) && movedLeft && currCellRow + 1 < 8 && matrix[currCellRow + 1, currCellCol] == 0)
            {
                turnsCounter++;
            }
            while (!(currCellRow == 7 && currCellCol == 7) && movedLeft && currCellRow + 1 < 8 && matrix[currCellRow + 1, currCellCol] == 0)
            {
                currCellRow++;
                counter++;
            }
            movedLeft = false;
            //left
            if (!(currCellRow == 7 && currCellCol == 7) && currCellCol + 1 < 8 && matrix[currCellRow, currCellCol + 1] == 0)
            {
                turnsCounter++;
                movedLeft = true;
            }
            while (!(currCellRow == 7 && currCellCol == 7) && currCellCol + 1 < 8 && matrix[currCellRow, currCellCol + 1] == 0)
            {
                currCellCol++;
                counter++;
            }

            //up
            if (!(currCellRow == 7 && currCellCol == 7) && movedLeft && currCellRow - 1 >= 0 && matrix[currCellRow - 1, currCellCol] == 0)
            {
                turnsCounter++;
            }
            while (!(currCellRow == 7 && currCellCol == 7) && movedLeft && currCellRow - 1 >= 0 && matrix[currCellRow - 1, currCellCol] == 0)
            {
                currCellRow--;
                counter++;
            }
            movedLeft = false;
            //left
            if (!(currCellRow == 7 && currCellCol == 7) && currCellCol + 1 < 8 && matrix[currCellRow, currCellCol + 1] == 0)
            {
                turnsCounter++;
                movedLeft = true;
            }
            while (!(currCellRow == 7 && currCellCol == 7) && currCellCol + 1 < 8 && matrix[currCellRow, currCellCol + 1] == 0)
            {
                currCellCol++;
                counter++;
            }


            down = !(currCellRow == 7 && currCellCol == 7) && movedLeft && currCellRow + 1 < 8 && matrix[currCellRow + 1, currCellCol] == 0;
            left = !(currCellRow == 7 && currCellCol == 7) && currCellCol + 1 < 8 && matrix[currCellRow, currCellCol + 1] == 0;
            up = !(currCellRow == 7 && currCellCol == 7) && movedLeft && currCellRow - 1 >= 0 && matrix[currCellRow - 1, currCellCol] == 0;
        }



        if (currCellRow == 7 && currCellCol == 7)
        {
            Console.WriteLine("{0} {1}", counter, turnsCounter);
        }
        else
        {
            Console.WriteLine("No {0}", counter);
        }
    }
}

