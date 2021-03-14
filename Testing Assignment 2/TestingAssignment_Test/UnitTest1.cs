using TestingAssignment;
using System;
using Xunit;

namespace TestingAssignment_Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test_WordCount()
        {
            //Arrange
            var input = "Anand P Odedara";
            var expectedValue = 3;
            // Act
            var result = AssignmentBLL.WordCount(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Test_NumberValidation()
        {
            //Arrange
            var input = "885";
            var expectedValue = true;
            // Act
            var result = AssignmentBLL.NumberValidation(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Test_AddLowerCase()
        {
            //Arrange
            var input = "ANAND";
            var expectedValue = "anand";
            // Act
            var result = AssignmentBLL.AddLowerCase(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Test_AddUpperCase()
        {
            //Arrange
            var input = "Anand";
            var expectedValue = "ANAND";
            // Act
            var result = AssignmentBLL.AddUpperCase(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Test_CheckLowerCase()
        {
            //Arrange
            var input = "lower case test";
            var expectedValue = true;
            // Act
            var result = AssignmentBLL.CheckLowerCase(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Test_CheckUpperCase()
        {
            //Arrange
            var input = "ANAND";
            var expectedValue = true;
            // Act
            var result = AssignmentBLL.CheckUpperCase(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Test_FirstUpperLetter()
        {
            //Arrange
            var input = "anand";
            var expectedValue = "Anand";
            // Act
            var result = AssignmentBLL.FirstUpperLetter(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Test_LastCharacterRemove()
        {
            //Arrange
            var input = "anand";
            var expectedValue = "anan";
            // Act
            var result = AssignmentBLL.LastCharacterRemove(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Test_StringToInt()
        {
            //Arrange
            var input = "885";
            var expectedValue = 885;
            // Act
            var result = AssignmentBLL.StringToInt(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }
    }
}
