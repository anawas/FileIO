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

    private static void HandlingBinaryFiles()
    {
        string userDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string fileName = $"{userDocuments}\\data.bin";

        Console.WriteLine($"Writing binary output to {fileName}");
        using (var stream = File.Open(fileName, FileMode.Create))
        {
            using (var writer = new BinaryWriter(stream, System.Text.Encoding.UTF8, false)) {
                double result = 1.0;
                for (int i = 0; i < 10; i++)
                {
                    writer.Write(result);
                    result *= 10.0;
                }
            }
        }

        using (var stream = File.Open(fileName, FileMode.Open))
        {
            using (var binReader = new BinaryReader(stream, System.Text.Encoding.UTF8, false))
            {
                double result = 0.0;
                for (int i = 0; i < 10; i++)
                {
                    result = binReader.ReadDouble();
                    Console.WriteLine($"Number {i}: {result}");
                }
            }
        }

    }

    public static void Main()
    {
        // UsingFile();
        // WorkingWithDirs();
        HandlingBinaryFiles();
    }


}