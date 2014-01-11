using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

        /*A class to hold abstract objects of type "Rocks", each of them possessing several "qualities":
         * - type of rock - rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, -
         * - left-to-right vertical position of the trace of falling - rockInitialCol
         * - up-to-down position to which the rock has fallen - changes over time as rocks go on falling - rockInitialRow
         * - colour of the specific minerals contained in each rock.
         * As rocks can just fall downwards due to Earth's gravitation, so is the only method updating their position only downwards.
        */
public class Rocks
{
    private char rockType;
    private int rockInitialCol;
    private int rockInitialRow;
    private int rockColorIndex;


    public Rocks(char rockType, int rockInitialCol, int rockInitialRow, int rockColorIndex)
    {
        this.rockType = rockType;
        this.rockInitialCol = rockInitialCol;
        this.rockInitialRow = rockInitialRow;
        this.RockColorIndex = rockColorIndex;
    }

    public int RockColorIndex
    {
        get { return rockColorIndex; }
        set { rockColorIndex = value; }
    }

    public char RockType
    {
        get { return rockType; }
        set { rockType = value; }
    }

    public int RockInitialCol
    {
        get { return rockInitialCol; }
        set { rockInitialCol = value; }
    }

    public int RockInitialRow
    {
        get { return rockInitialRow; }
        set { rockInitialRow = value; }
    }

    public void UpdateRockLocation()
    {
        rockInitialRow++;
    }
}

