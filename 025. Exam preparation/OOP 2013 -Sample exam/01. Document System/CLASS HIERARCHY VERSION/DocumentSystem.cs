using System;
using System.Collections.Generic;
using System.Text;

public interface IDocument
{
	string Name { get; }
	string Content { get; }
	void LoadProperty(string key, string value);
	void SaveAllProperties(IList<KeyValuePair<string, object>> output);
	string ToString();
}

public interface IEditable
{
	void ChangeContent(string newContent);
}

public interface IEncryptable
{
	bool IsEncrypted { get; }
	void Encrypt();
	void Decrypt();
}

public class DocumentSystem
{
    private static IList<IDocument> docs = new List<IDocument>();

    static void Main()
    {
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }

    private static IList<string> ReadAllCommands()
    {
        List<string> commands = new List<string>();
        while (true)
        {
            string commandLine = Console.ReadLine();
            if (commandLine == "")
            {
                // End of commands
                break;
            }
            commands.Add(commandLine);
        }
        return commands;
    }

    private static void ExecuteCommands(IList<string> commands)
    {
        foreach (var commandLine in commands)
        {
            int paramsStartIndex = commandLine.IndexOf("[");
            string cmd = commandLine.Substring(0, paramsStartIndex);
            int paramsEndIndex = commandLine.IndexOf("]");
            string parameters = commandLine.Substring(
                paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
            ExecuteCommand(cmd, parameters);
        }
    }

    private static void ExecuteCommand(string cmd, string parameters)
    {
        string[] cmdAttributes = parameters.Split(
            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (cmd == "AddTextDocument")
        {
            AddTextDocument(cmdAttributes);
        }
        else if (cmd == "AddPDFDocument")
        {
            AddPdfDocument(cmdAttributes);
        }
        else if (cmd == "AddWordDocument")
        {
            AddWordDocument(cmdAttributes);
        }
        else if (cmd == "AddExcelDocument")
        {
            AddExcelDocument(cmdAttributes);
        }
        else if (cmd == "AddAudioDocument")
        {
            AddAudioDocument(cmdAttributes);
        }
        else if (cmd == "AddVideoDocument")
        {
            AddVideoDocument(cmdAttributes);
        }
        else if (cmd == "ListDocuments")
        {
            ListDocuments();
        }
        else if (cmd == "EncryptDocument")
        {
            EncryptDocument(parameters);
        }
        else if (cmd == "DecryptDocument")
        {
            DecryptDocument(parameters);
        }
        else if (cmd == "EncryptAllDocuments")
        {
            EncryptAllDocuments();
        }
        else if (cmd == "ChangeContent")
        {
            ChangeContent(cmdAttributes[0], cmdAttributes[1]);
        }
        else
        {
            throw new InvalidOperationException("Invalid command: " + cmd);
        }
    }
  
    private static void AddTextDocument(string[] attributes)
    {
        AssignProperties(new TextDocument(), attributes);
    }

    private static void AddPdfDocument(string[] attributes)
    {
        AssignProperties(new PDFDocument(), attributes);
    }

    private static void AddWordDocument(string[] attributes)
    {
        AssignProperties(new WordDocument(), attributes);
    }

    private static void AddExcelDocument(string[] attributes)
    {
        AssignProperties(new ExcelDocument(), attributes);
        
    }

    private static void AddAudioDocument(string[] attributes)
    {
        AssignProperties(new AudioDocument(), attributes);        
    }

    private static void AddVideoDocument(string[] attributes)
    {
        AssignProperties(new VideoDocument(), attributes);
        
    }

    private static void ListDocuments()
    {
        if (docs.Count == 0)
        {
            Console.WriteLine("No documents found");
        }
        else
        {
            foreach (var d in docs)
            {
                Console.WriteLine(d.ToString());
            }
        }
    }

    private static void EncryptDocument(string name)
    {
        bool docExists = false;
        
        foreach (var doc in docs)
        {
            if (doc.Name == name)
            {
                if (doc is IEncryptable)
                {
                    (doc as IEncryptable).Encrypt();
                    Console.WriteLine("Document encrypted: {0}", doc.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: {0}", doc.Name);
                }
                docExists = true;
            }
        }
        if (!docExists)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void DecryptDocument(string name)
    {
        bool docExists = false;

        foreach (var doc in docs)
        {
            if (doc.Name == name)
            {
                if (doc is IEncryptable)
                {
                    (doc as IEncryptable).Decrypt();
                    Console.WriteLine("Document decrypted: {0}", doc.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: {0}", doc.Name);
                }
                docExists = true;
            }
        }
        if (!docExists)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void EncryptAllDocuments()
    {
        bool docExists = false;

        foreach (var doc in docs)
        {
            if (doc is IEncryptable)
            {
                (doc as IEncryptable).Encrypt();
                docExists = true;
            }
         }

        if (!docExists)
        {
            Console.WriteLine("No encryptable documents found");
        }
        else
        {
            Console.WriteLine("All documents encrypted");
        }
    }

    private static void ChangeContent(string name, string content)
    {
        bool isFound = false;
        foreach (var d in docs)
        {
            if (d.Name == name)
            {
                if (d is IEditable)
                {
                    (d as IEditable).ChangeContent(content);
                    Console.WriteLine("Document content changed: {0}", d.Name);
                }
                else
                {
                    Console.WriteLine("Document is not editable: {0}", d.Name);
                }
                isFound = true;
            }
        }
        if (!isFound)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void AssignProperties(IDocument document, string[] props)
    {
        foreach (var p in props)
        {
            string[] splitted = p.Split('=');
            document.LoadProperty(splitted[0], splitted[1]);
        }

        if (document.Name == null)
        {
            Console.WriteLine("Document has no name");
        }
        else
        {
            docs.Add(document);
            Console.WriteLine("Document added: {0}", document.Name);
        }
    }
}
