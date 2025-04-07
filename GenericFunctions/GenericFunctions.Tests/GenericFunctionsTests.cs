namespace GenericFunctions.Tests
{
    public class GenericFunctionsTests
    {

        [Test]
        public void MapIntData_ShouldReturnTransformedList()
        {
            Assert.That(
                Functions.Map([1, 2, 3], x => x * 2),
                Is.EqualTo(new List<int>() { 2, 4, 6 }));
        }

        [Test]
        public void MapStringData_ShouldReturnTransformedList()
        {
            Assert.That(
                Functions.Map(["apple", "planet", "essential"], x => x[..2]),
                Is.EqualTo(new List<string>() { "ap", "pl", "es" }));
        }

        [Test]
        public void MapInputStringDataOutputIntData_ShouldReturnTransformedList()
        {
            Assert.That(
                Functions.Map(["apple", "planet", "essential"], x => x.Length),
                Is.EqualTo(new List<int>() { 5, 6, 9 }));
        }

        [Test]
        public void FilterIntData_ShouldReturnFilteredList()
        {
            Assert.That(
                Functions.Filter([1, 2, 3, 4], x => x % 2 == 0),
                Is.EqualTo(new List<int>() { 2, 4}));
        }

        [Test]
        public void FilterStringData_ShouldReturnFilteredList()
        {
            Assert.That(
                Functions.Filter(["apple", "banana", "cow", "dog", "cat"], x => x.Contains('a')),
                Is.EqualTo(new List<string>() { "apple", "banana","cat" }));
        }

        [Test]
        public void FoldIntData_ShouldReturnValue()
        {
            Assert.That(
                Functions.Fold([1, 2, 3], 1, (acc, elem) => acc * elem),
                Is.EqualTo(6));
        }

        [Test]
        public void FoldStringData_ShouldReturnValue()
        {
            Assert.That(
                Functions.Fold(["ap", "pl", "e", ", ", "ban", "ana"], "fruit: ", (acc, elem) => acc + elem),
                Is.EqualTo("fruit: apple, banana"));
        }
    }
}