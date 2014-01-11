using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

namespace HTMLRenderer
{
	public interface IElement
	{
		string Name { get; }
		string TextContent { get; set; }
		IEnumerable<IElement> ChildElements { get; }
		void AddElement(IElement element);
		void Render(StringBuilder output);
		string ToString();
	}

	public interface ITable : IElement
	{
		int Rows { get; }
		int Cols { get; }
		IElement this[int row, int col] { get; set; }
	}

    public interface IElementFactory
    {
		IElement CreateElement(string name);
		IElement CreateElement(string name, string content);
		ITable CreateTable(int rows, int cols);
    }

    public class HTMLElementFactory : IElementFactory
    {
		public IElement CreateElement(string name)
		{
            IElement element = new Element(name);
            return element;
		}

		public IElement CreateElement(string name, string content)
		{
            IElement element = new Element(name, content);
            return element;
		}

		public ITable CreateTable(int rows, int cols)
		{
            ITable table = new Table(rows, cols);
            return table;
		}
	}


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
                    output.AppendFormat("<td>{0}</td>", this.arr[row, col].ToString());
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

    public class HTMLRendererCommandExecutor
    {
        static void Main()
        {
			string csharpCode = ReadInputCSharpCode();
			CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using HTMLRenderer;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
}
