using NameSorterService.Classes;

namespace NameSorterTests
{
    public class TextFileHelperTests
    {
        private readonly TextFileHelper _sut;
        public TextFileHelperTests()
        {
            _sut = new TextFileHelper();
        }

        [Theory]
        [InlineData("")]
        [InlineData("kjgs*&^%&*^$%(*&%(*&^$&%*&^*^$$$$()*()_()_$)_")]
        public void ReadTextFileThatDoesNotExistTest(string filePath)
        {
            Assert.ThrowsAny<FileNotFoundException>(() => _sut.ReadTextFile(filePath));
        }

        [Fact]
        public void ReadTextFileThatExistsTest()
        {
            var inputPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\", "unsorted-names-list.txt"));

            _sut.ReadTextFile(inputPath);
        }

        [Fact]
        public void WriteTextFileWithEmptyFilePathTest()
        {
            Assert.ThrowsAny<ArgumentNullException>(() => _sut.WriteTextFile("","test text"));
        }

    }
}
