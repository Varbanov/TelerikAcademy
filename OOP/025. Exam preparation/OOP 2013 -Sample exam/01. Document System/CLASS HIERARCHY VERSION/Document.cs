using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Document : IDocument
{
    public string Name { get; protected set; }
    public string Content { get; protected set; }

    public virtual void LoadProperty(string key, string value)
    {
        if (key == "name")
        {
            this.Name = value;
        }
        else if (key == "content")
        {
            this.Content = value;
        }
        else
        {
            throw new ArgumentException("Key {0} is invalid", key);
        }
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("name", this.Name));
        output.Add(new KeyValuePair<string, object>("content", this.Content));
    }

    public override string ToString()
    {
        List<KeyValuePair<string, object>> props = new List<KeyValuePair<string, object>>();
        this.SaveAllProperties(props);
        props.Sort((x, y) => x.Key.CompareTo(y.Key));

        StringBuilder res = new StringBuilder();
        res.Append(this.GetType().Name);
        res.Append("[");
        foreach (var item in props)
        {
            if (item.Value != null)
            {
                res.AppendFormat("{0}={1};", item.Key, item.Value);
            }
        }
        res.Remove(res.Length - 1, 1);
        res.Append("]");

        return res.ToString();
    }
}