using System;
using System.IO;
using Audit;
using Xunit;

namespace Audi.Tests;

public class AuditManagerIntegrationTest
{
    private const string DirectoryName = "audits";

    [Fact]
    public void A_new_file_is_created_when_the_current_file_overflows()
    {
        // Arrange
        var timeOfTest = DateTime.Now;
        var fileSystemMock =
            new WinFileSystem(Path.Combine(Path.GetTempPath(), timeOfTest.ToString("yyyy-MM-dd.HH-mm-ss")));
        //fileSystemMock
        //    .Setup(x => x.GetFiles(DirectoryName))
        //    .Returns(new[]
        //    {
        //        Path.Combine(DirectoryName, "audit_1.txt"),
        //        Path.Combine(DirectoryName, "audit_2.txt")
        //    });

        //fileSystemMock
        //    .Setup(x => x.ReadAllLines(Path.Combine(DirectoryName, "audit_2.txt")))
        //    .Returns(new List<string>
        //    {
        //        "Peter;2019-04-06 16:30:00",
        //        "Jane;2019-04-06 16:40:00",
        //        "Jack;2019-04-06 17:00:00"
        //    });
        var sut = new AuditManager(3, DirectoryName, fileSystemMock);

        // Act
        sut.AddRecord("Alice", DateTime.Parse("2019-04-06T18:00:00"));

        // Assert
        //fileSystemMock.Verify(x => x.WriteAllText(
        //    Path.Combine(DirectoryName, "audit_3.txt"),
        //    "Alice;2019-04-06 18:00:00"));
    }
}