namespace ParseTree.Tests
{
    public class Tests
    {

        [Test]
        public void Calculating_ShouldReturnExpressionValue()
        {
            string filePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData_Calc");
            File.WriteAllText(filePath, "(* (+ 1 1) 2)");
            Node root = Tree.BuildTree(filePath);
            Assert.That(root.Calculate(), Is.EqualTo(4));
        }

        [Test]
        public void WriteExpression_ShouldReturnExpressionInStringForm()
        {
            string filePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData_WriteExp");
            File.WriteAllText(filePath, "(* (+ 1 1) 2)");
            Node root = Tree.BuildTree(filePath);
            Assert.That(root.WriteExpression(), Is.EqualTo("( * ( + 1 1 ) 2 )"));
        }

        [Test]
        public void EmptyFile_ShouldThrowException()
        {
            string filePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData_EmptyFile");
            File.WriteAllText(filePath, "");
            Assert.Throws<Exception>(() => Tree.BuildTree(filePath), "Empty file");
        }

        [Test]
        public void UnknownOperation_ShouldThrowException()
        {
            string filePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData_UnknownOperation");
            File.WriteAllText(filePath, "(^ 6 8)");
            Assert.Throws<Exception>(() => Tree.BuildTree(filePath), "The expression contains an unknown operation. Expected +, -, *, /");
        }

        [Test]
        public void ClosingBracket_ShouldThrowException()
        {
            string filePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData_ClosingBracket");
            File.WriteAllText(filePath, "(+ 6 8");
            Assert.Throws<Exception>(() => Tree.BuildTree(filePath), "Missing closing bracket");
        }

        [Test]
        public void IncorrrectExpression_ShouldThrowException()
        {
            string filePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData_IncorrrectExpression");
            File.WriteAllText(filePath, "(+ bhjwfbhj 8 )");
            Assert.Throws<Exception>(() => Tree.BuildTree(filePath), "Incorrect expression");
        }
    }
}
