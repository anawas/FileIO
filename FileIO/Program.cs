class Program
{
    private static void UsingFile()
    {
        string personalDocumentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string path = $"{personalDocumentsFolder}\\MyTest.txt";
        if (!File.Exists(path))
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("Hello");
                sw.WriteLine("And");
                sw.WriteLine("Welcome");
            }
        }
        Console.WriteLine($"Written file to {path}");
        Console.WriteLine("Trying to read the file");

        using (StreamReader sr = File.OpenText(path))
        {
            String s;
            while ((s = sr.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
        }
    }
    
    private static void WorkingWithDirs()
    {
        foreach (string entry in Directory.GetDirectories(@"C:\"))
        {
            DisplayFileSystemInfoAttributes(new DirectoryInfo(entry));
        }
    }

    private static void DisplayFileSystemInfoAttributes(FileSystemInfo fsi)
    {
        // Asume that the entry is a file
        string entryType = "File";

        if ((fsi.Attributes & FileAttributes.Directory) == FileAttributes.Directory) {
            entryType = "Directory";
        }

        Console.WriteLine("{0} entry {1} was created on {2:D}",entryType, fsi.FullName, fsi.CreationTime);
    }

    public static void Main()
    {
        // UsingFile();
        WorkingWithDirs();
    }


}