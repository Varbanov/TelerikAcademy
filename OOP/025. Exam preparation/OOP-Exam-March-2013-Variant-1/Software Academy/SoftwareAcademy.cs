using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

namespace SoftwareAcademy
{

    public class Teacher : ITeacher
    {
        private List<ICourse> courses = new List<ICourse>();

        public string Name { get; set; }

        public void AddCourse(ICourse course)
        {
            this.courses.Add(course);
        }


        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            res.AppendFormat("Teacher: Name={0}", this.Name);
            if (this.courses.Count > 0)
            {
                res.Append("; Courses=[");

                foreach (var course in this.courses)
                {
                    res.AppendFormat("{0}, ", course.Name);
                }
                res.Remove(res.Length - 2, 2);
                res.Append("]");
            }

            return res.ToString();
        }
    }

    public class OffsiteCourse : Course, IOffsiteCourse
    {
        public string Town { get; set; }

        public override string ToString()
        {
            string baseStr = base.ToString();
            StringBuilder res = new StringBuilder();
            res.Append(baseStr);
            res.AppendFormat("; Town={0}", this.Town);
            return res.ToString();
        }
    }

    public class LocalCourse : Course, ILocalCourse
    {
        public string Lab { get; set; }

        public override string ToString()
        {
            string baseStr = base.ToString();
            StringBuilder res = new StringBuilder();
            res.Append(baseStr);
            res.AppendFormat("; Lab={0}", this.Lab);
            return res.ToString();
        }
    }

    public abstract class Course : ICourse
    {

        public string Name { get; set; }
        public ITeacher Teacher { get; set; }
        private List<string> topics = new List<string>();

        public void AddTopic(string topic)
        {
            this.topics.Add(topic);
        }

        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            res.AppendFormat("{0}: Name={1}", this.GetType().Name, this.Name);
            if (this.Teacher != null)
            {
                res.AppendFormat("; Teacher={0}", this.Teacher.Name);
            }
            if (this.topics.Count > 0)
            {
                res.AppendFormat("; Topics=[");

                foreach (var topic in this.topics)
                {
                    res.AppendFormat("{0}, ", topic);
                }
                res.Remove(res.Length - 2, 2);
                res.Append("]");
            }
            return res.ToString();
        }
    }

    public interface ITeacher
    {
        string Name { get; set; }
        void AddCourse(ICourse course);
        string ToString();
    }

    public interface ICourse
    {
        string Name { get; set; }
        ITeacher Teacher { get; set; }
        void AddTopic(string topic);
        string ToString();
    }

    public interface ILocalCourse : ICourse
    {
        string Lab { get; set; }
    }

    public interface IOffsiteCourse : ICourse
    {
        string Town { get; set; }
    }

    public interface ICourseFactory
    {
        ITeacher CreateTeacher(string name);
        ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab);
        IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town);
    }

    public class CourseFactory : ICourseFactory
    {
        public ITeacher CreateTeacher(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Name cannot be null.");
            }
            else
            {
                ITeacher teacher = new Teacher();
                teacher.Name = name;
                return teacher;
            }
        }

        public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        {
            if (name == null || lab == null)
            {
                throw new ArgumentNullException("Error: Either name or lab are null.");
            }
            else
            {
                ILocalCourse course = new LocalCourse();
                course.Name = name;
                course.Teacher = teacher;
                course.Lab = lab;
                return course;
            }
        }

        public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        {
            if (name == null || town == null)
            {
                throw new ArgumentNullException("Either name or town are null");
            }
            else
            {
                IOffsiteCourse course = new OffsiteCourse();
                course.Name = name;
                course.Teacher = teacher;
                course.Town = town;
                return course;
            }
        }
    }

    public class SoftwareAcademyCommandExecutor
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
                  using SoftwareAcademy;

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
