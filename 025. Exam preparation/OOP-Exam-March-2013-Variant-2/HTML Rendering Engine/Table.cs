using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLRenderer
{
    public class Table : Element, ITable
    {
        IElement[,] arr;

        

        public int Rows
        {
            get { return this.arr.GetLength(0); }
        }

        public int Cols
        {
            get { return this.arr.GetLength(1); }
        }

        public IElement this[int row, int col]
        {
            get
            {
                return this.arr[row, col];
            }
            set
            {
                this.arr[row, col] = value;
            }
        }
        
        public Table(int rows, int cols)
            : base("table")
        {
            this.arr = new IElement[rows, cols];
        }

        public override void Render(StringBuilder output)
        {
            output.Append("<table>");
            for (int row = 0; row < this.arr.GetLength(0); row++)
            {
                output.Append("<tr>");
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    output.AppendFormat("<td>{0}</td>", this.arr[row,col].ToString());
                }
                output.Append("</tr>");
            }
            output.Append("</table>");
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            this.Render(output);
            return output.ToString();
        }
    }
}
