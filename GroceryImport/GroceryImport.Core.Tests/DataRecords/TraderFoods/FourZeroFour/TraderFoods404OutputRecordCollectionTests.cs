using System.IO;
using System.Linq;
using System.Text;
using FluentAssertions;
using GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryImport.Core.Tests.DataRecords.TraderFoods.FourZeroFour
{
    [TestClass]
    public class TraderFoods404OutputRecordCollectionTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldNotAllowMultipleEnumerations()
        {
            //Arrange
            string inMemoryFile = @"80000001 Kimchi-flavored white rice                                  00000567 00000000 00000000 00000000 00000000 00000000 NNNNNNNNN      18oz
14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz
40123401 Marlboro Cigarettes                                         00001000 00000549 00000000 00000000 00000000 00000000 YNNNNNNNN          
50133333 Fuji Apples (Organic)                                       00000349 00000000 00000000 00000000 00000000 00000000 NNYNNNNNN        lb";
            StreamReader streamReader = new StreamReader(new MemoryStream(Encoding.ASCII.GetBytes(inMemoryFile)));
            TraderFoods404ProductRecordCollection subject = new TraderFoods404ProductRecordCollection(streamReader);

            //Act
            int ctr = subject.Count();
            int ctr2 = subject.Count();

            //Assert
            ctr.Should().Be(4);
            ctr2.Should().Be(0);
        }

        [TestMethod, TestCategory("unit")]
        public void FileReader_ShouldSkipIncorrectLengthFields()
        {
            //Arrange
            string inMemoryFile = @"80000001 Kimchi-flavored white rice                                  00000567 00000000 00000000 00000000 00000000 00000000 NNNNNNNNN      18oz
14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz
40123401 Marlboro Cigarettes                                         00001000 00000549 00000000 00000000 00000000 00000000 YNNNNNNNN          
50133333 Fuji Apples (Organic)                                       00000349 00000000 00000000 00000000 00000000 00000000 NNYNNNNNN        lb
50133333 Fuji Apples (Organic)                                       00000349 00000000 00000000 00000000 00000000 00000000 NNYNNNNNN          12x12oz
50133333 Fuji Apples (Organic)                                       00000349 00000000 00000000 00000000 00000000 00000000 NNYNNNNNN";
            StreamReader streamReader = new StreamReader(new MemoryStream(Encoding.ASCII.GetBytes(inMemoryFile)));
            TraderFoods404ProductRecordCollection subject = new TraderFoods404ProductRecordCollection(streamReader);

            //Act
            int ctr = subject.Count();

            //Assert
            ctr.Should().Be(4);
        }

        [TestMethod, TestCategory("integration")]
        public void ShouldReadFromAFile()
        {
            //Arrange
            TraderFoods404ProductRecordCollection subject = new TraderFoods404ProductRecordCollection("./InputSample/default.txt");

            //Act
            int ctr = subject.Count();

            //Assert
            ctr.Should().Be(4);
        }
    }
}