using System;

namespace ConsoleApp11
{

    enum UserType
    {
    NotSet,
    Free,
    Pro,
    Expert
    }
    class Program
    {
        static void Main(string[] args)
        {
        DocumentWorker doc = null;
        UserType type = UserType.NotSet;
        System.Console.Write("If you want to use Free version, press 1;\nIf you want to use Pro or Expert version, enter your license code:");
        var choice = Console.ReadLine();
        switch (choice)
        {
        case "1": type = UserType.Free; break;
// Pro license code
        case "1234": type = UserType.Pro; break;
// Expert license code
        case "12345678": type = UserType.Expert; break;
        } 

        switch (type)
        {
        case UserType.Free: 
        doc = new DocumentWorker(); break;
        case UserType.Pro:
        doc = new ProDocumentWorker(); break;
        case UserType.Expert:
        doc = new ExpertDocumentWorker(); break;
        default:
        break;
        }

        if (doc == null)
        {  
        Console.WriteLine("Not set");
        return;
        }

        doc.OpenDocument();
        doc.EditDocument();
        doc.SaveDocument();
        }
    }

    class DocumentWorker
    {
    public virtual void OpenDocument() 
    {
        System.Console.WriteLine("Document opened");
    }

    public virtual void EditDocument()
    {
        System.Console.WriteLine("Document editing is availavle in Pro version");
    }

    public virtual void SaveDocument()
    {
        System.Console.WriteLine("Document saving is availavle in Pro version");
    }

    }

    class ProDocumentWorker : DocumentWorker
    {
    public override void EditDocument()
    {
    System.Console.WriteLine("Document Edited");
    base.EditDocument();
    }

    public override void SaveDocument()
    {
    System.Console.WriteLine("Document saved in old format, saving in other formats is available in Expert version");
    base.SaveDocument();
    }
    }

    class ExpertDocumentWorker : ProDocumentWorker
    {
    public override void SaveDocument()
    {
    System.Console.WriteLine("Document saved in a new format");
    base.SaveDocument();
    }
    }
}
