namespace Archiver.Tests
{
    public class ArchiverTests
    {
        [Test]
        public void CompresUncompressTextFile_ShouldReturnDuplicateOfOriginalFile()
        {
            string input = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");
            string compressed = Path.Combine(TestContext.CurrentContext.TestDirectory, "compressed.zipped");
            string uncompressed = Path.Combine(TestContext.CurrentContext.TestDirectory, "uncompressed.txt");

            File.WriteAllText(input, "AppleBananaOrange");

            LZW.Compress(input, compressed);
            LZW.Uncompress(compressed, uncompressed);

            byte[] inputData = File.ReadAllBytes(input);
            byte[] outputData = File.ReadAllBytes(uncompressed);

            Assert.That(outputData, Is.EqualTo(inputData));
        }

        [Test]
        public void CompresUncompressBinaryFile_ShouldReturnDuplicateOfOriginalFile()
        {
            string input = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");
            string compressed = Path.Combine(TestContext.CurrentContext.TestDirectory, "compressed.zipped");
            string uncompressed = Path.Combine(TestContext.CurrentContext.TestDirectory, "uncompressed.txt");

            byte[] data = new byte[1000];
            for (int i = 0; i < 1000; ++i)
            {
                data[i] = (byte)i;
            }

            File.WriteAllBytes(input, data);

            LZW.Compress(input, compressed);
            LZW.Uncompress(compressed, uncompressed);

            byte[] inputData = File.ReadAllBytes(input);
            byte[] outputData = File.ReadAllBytes(uncompressed);

            Assert.That(outputData, Is.EqualTo(inputData));
        }

        [Test]
        public void GivenNonExistentFilePath_ShouldReturnErrorMessage()
        {
            string input = "TestData.txt";
            var console = new StringWriter();
            Console.SetOut(console);

            Program.Main([input, "-c"]);

            Assert.That(console.ToString(), Is.EqualTo("The file path is incorrect.\r\n"));
        }

        [Test]
        public void GivenNotZippedFile_ShouldReturnErrorMessage()
        {
            string notZipped = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");
            var console = new StringWriter();
            Console.SetOut(console);

            Program.Main([notZipped, "-u"]);

            Assert.That(console.ToString(), Is.EqualTo("Incorrect file path. Expected .zipped.\r\n"));
        }
    }
}
