using System;
using System.IO;

class DirAppend
{
    public static void Main()
    {
        using (StreamWriter w = File.AppendText("log.txt"))
        {
            Log("Test1", w);
            Log("Test2", w);
        }

        using (StreamReader r = File.OpenText("log.txt"))
        {
            DumpLog(r);
        }
    }

    public static void Log(string logMessage, TextWriter w)
    {
        w.Write("\r\nLog Entry : ");
        w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
            DateTime.Now.ToLongDateString());
        w.WriteLine("  :");
        w.WriteLine("  :{0}", logMessage);
        w.WriteLine("-------------------------------");
    }

    public static void DumpLog(StreamReader r)
    {
        string line;
        while ((line = r.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
    }

    public static string GetTempPath()
    {
        string path = System.Environment.GetEnvironmentVariable("TEMP");
        if (!path.EndsWith("\\")) path += "\\";
        Console.WriteLine(path);
        return path;
    }

    public static void LogMessageToFile(string msg)
    {
        System.IO.StreamWriter sw = System.IO.File.AppendText(
            GetTempPath() + "My Log File.txt");
        try
        {
            string logLine = System.String.Format(
                "{0:G}: {1}.", System.DateTime.Now, msg);
            sw.WriteLine(logLine);
        }
        finally
        {
            sw.Close();
        }
    }
}