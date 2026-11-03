namespace TinyScanner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the path or test filename: ");
            string inputPath = (Console.ReadLine() ?? "").Trim().Trim('"'); 
            
            string testsDir = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\tests"));
            string testFilePath = Path.Combine(testsDir, inputPath);
            if (File.Exists(testFilePath))
            {
                inputPath = testFilePath;
            }
            else
            {
                Console.WriteLine($"Error: File '{inputPath}' was not found.");
                Console.WriteLine($"Checked in tests folder: '{testFilePath}'");
                return;
            }
            

            string sourceCode = File.ReadAllText(inputPath);

            TinyScanner scanner = new TinyScanner(sourceCode);
            List<Token> tokens = scanner.Scan();
            Console.WriteLine("Tokens found:");
            Console.WriteLine("----------------------------");
            foreach (Token token in tokens)
            {
                Console.WriteLine(token);
            }
            Console.WriteLine("----------------------------");

            string outputPath = Path.Combine(
                Path.GetDirectoryName(Path.GetFullPath(inputPath)) ?? ".",
                "output.txt");
            SaveOutput(tokens, outputPath);

            Console.WriteLine($"\nOutput saved to '{outputPath}'.");
            if (!Console.IsInputRedirected)
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }

        }

        static void SaveOutput(List<Token> tokens, string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (Token token in tokens)
                {
                    writer.WriteLine(token.ToString());
                }
            }
        }
    }
}
