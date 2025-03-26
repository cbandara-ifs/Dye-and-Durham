using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using name_sorter.Application.Contracts;
using name_sorter.Application.File;

namespace name_sorter.Tests.File
{
    public class FileProcessorTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<IFileProcessor> _mockFileProcessor;
        private readonly Mock<IFileValidator> _mockFileValidator;
        private readonly Mock<IFilePathGenerator> _mockFilePathGenerator;
        private readonly FileProcessor _sut;

        public FileProcessorTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));
            _mockFileProcessor = _fixture.Freeze<Mock<IFileProcessor>>();
            _mockFileValidator = _fixture.Freeze<Mock<IFileValidator>>();
            _mockFilePathGenerator = _fixture.Freeze<Mock<IFilePathGenerator>>();
            _sut = _fixture.Build<FileProcessor>().OmitAutoProperties().Create();
        }

        [Fact]
        public void ProcessFile_ValidTextFile_ShouldCallSortOnceandWriteOnce()
        {
            var inputFilePath = "Test.txt";
            List<string> sortedList = new List<string> { "Alice Doe", "Bob Smith" };
            var outputFilepath = _fixture.Create<string>();

            _mockFileValidator.Setup(s => s.ValidateFileExists(It.IsAny<string>())).Returns(true);

            _mockFilePathGenerator.Setup(s => s.GenerateFilePath(It.IsAny<string>())).Returns(outputFilepath);

            _mockFileProcessor.Setup(s => s.SupportsExtension(".txt")).Returns(true);

            _mockFileProcessor.Setup(p => p.SortFile(It.IsAny<string>()))
                 .Returns(sortedList);

            _sut.ProcessFile(inputFilePath);

            _mockFileProcessor.Verify(p => p.SortFile(inputFilePath), Times.Once);

            _mockFileProcessor.Verify(p => p.WriteToFile(It.IsAny<string>(), It.IsAny<List<string>>()), Times.Once);
        }

        [Fact]
        public void ProcessFile_NotATextFile_ShouldNotCallSortOrWrite()
        {
            var inputFilePath = "Test.csv";
            var outputFilepath = _fixture.Create<string>();

            _mockFileValidator.Setup(s => s.ValidateFileExists(It.IsAny<string>())).Returns(true);

            _mockFilePathGenerator.Setup(s => s.GenerateFilePath(It.IsAny<string>())).Returns(outputFilepath);

            _mockFileProcessor.Setup(s => s.SupportsExtension(".csv")).Returns(false);

            _sut.ProcessFile(inputFilePath);

            _mockFileProcessor.Verify(p => p.SortFile(inputFilePath), Times.Never);

            _mockFileProcessor.Verify(p => p.WriteToFile(It.IsAny<string>(), It.IsAny<List<string>>()), Times.Never);
        }

        [Fact]
        public void ProcessFile_FileDoesNotExist_ShouldNotCallSortOrWrite()
        {
            var inputFilePath = "Test.csv";
            var outputFilepath = _fixture.Create<string>();

            _mockFileValidator.Setup(s => s.ValidateFileExists(It.IsAny<string>())).Returns(false);

            _sut.ProcessFile(inputFilePath);

            _mockFileProcessor.Verify(p => p.SortFile(inputFilePath), Times.Never);

            _mockFileProcessor.Verify(p => p.WriteToFile(It.IsAny<string>(), It.IsAny<List<string>>()), Times.Never);
        }
    }
}
