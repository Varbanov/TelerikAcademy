using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class PDFDocument : BinaryDocument, IEncryptable
{
    public uint? NumOfPages { get; set; }
    private bool isEncrypted;

    public override void LoadProperty(string key, string value)
    {
        if (key == "pages")
        {
            this.NumOfPages = uint.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("pages", this.NumOfPages));
    }

    public bool IsEncrypted
    {
        get { return this.isEncrypted; }
    }

    public void Encrypt()
    {
        this.isEncrypted = true;
    }

    public void Decrypt()
    {
        this.isEncrypted = false;
    }

    public override string ToString()
    {
        if (this.isEncrypted)
        {
            return String.Format("{0}[encrypted]", this.GetType().Name);
        }
        else
        {
            return base.ToString();
        }
    }
}