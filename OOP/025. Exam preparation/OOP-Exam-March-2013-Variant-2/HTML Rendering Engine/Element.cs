using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLRenderer
{
    public class Element : IElement
    {
        private string name;
        private string textContent;
        private List<IElement> childElems;

        public string Name
        {
            get { return this.name; }
        }

        public string TextContent
        {
            get
            {
                return this.textContent;
            }
            set
            {
                this.textContent = value;
            }
        }

        public IEnumerable<IElement> ChildElements
        {
            get { return this.childElems; }
        }

        public Element(string name = null, string content = null)
        {
            this.name = name;
            this.TextContent = content;
            this.childElems = new List<IElement>();
        }

        public void AddElement(IElement element)
        {
            this.childElems.Add(element);
        }

        public virtual void Render(StringBuilder output)
        {
            if (this.Name != null)
            {
                output.AppendFormat("<{0}>", this.name);
            }
            if (this.TextContent != null)
            {
                string escapedContent = EscapeContent(this.TextContent);
                output.Append(escapedContent);
            }
            foreach (var child in this.ChildElements)
            {
                child.Render(output);
            }
            if (this.Name != null)
	        {
                output.AppendFormat("</{0}>", this.Name);
	        }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            this.Render(output);
            return output.ToString();
        }

        private string EscapeContent(string content)
        {
            string escaped = content.Replace("&", "&amp;");

            string escaped1 = escaped.Replace("<", "&lt;");
            string escaped2 = escaped1.Replace(">", "&gt;");
            return escaped2;
        }
    }
}
