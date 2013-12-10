using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ExcelDocument : OfficeDocument
{
    public uint Rows { get; set; }
    public uint Cols { get; set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "rows")
        {
            this.Rows = uint.Parse(value);
        }
        else if (key == "cols")
        {
            this.Cols = uint.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("rows", this.Rows));
        output.Add(new KeyValuePair<string, object>("cols", this.Cols));

    }
}