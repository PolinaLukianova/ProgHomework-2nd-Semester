namespace Archiver;

public class Program
{
    public static void Main(string[] args)
    {
        string inputPath = args[0];
        string key = args[1];

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("The file path is incorrect.");
            return;
        }

        string outputPath;
        if (key == "-c")
        {
            int lastDot = inputPath.LastIndexOf('.');
            if (lastDot != -1)
            {
                outputPath = inputPath[..lastDot] + ".zipped";
            }
            else
            {
                outputPath = inputPath + ".zipped";
            }

            LZW.Compress(inputPath, outputPath);
        }
        else if (key == "-u")
        {
            if (!inputPath.EndsWith(".zipped"))
            {
                Console.WriteLine("Incorrect file path. Expected .zipped.");
                return;
            }

            int lastDot = inputPath.LastIndexOf('.');
            outputPath = inputPath[..lastDot];

            LZW.Uncompress(inputPath, outputPath);
        }
    }
}