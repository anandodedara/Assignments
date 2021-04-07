
using Xunit;

namespace assignment2.Tests
{
   
    public class UnitTest1
    {
        /// <summary>
        /// Convert into uppercase from lowercase
        /// </summary>

        [Fact]
        public void Convert_To_UpperCase_From_LowerCase()
        {
            // Arrange
            string str= "anand";
            string expectedResult = "ANAND";
            // Act
            string result =str.ToUpperCustom();

            // Assert
            
            Assert.Equal(expectedResult, result);
        }

        /// <summary>
        /// Convert into uppercase from mixedcase
        /// </summary>
        /// 

        [Fact]
        public void Convert_To_UpperCase_From_MixedCase()
        {
            // Arrange
            string str = "My nAme iS AnaND oDedaRa";
            string expectedResult = "MY NAME IS ANAND ODEDARA";
            // Act
            string result = str.ToUpperCustom();

            // Assert

            Assert.Equal(expectedResult, result);
        }

        /// <summary>
        /// Convert into lowercase from uppercase
        /// </summary>

        [Fact]
        public void Convert_To_LowerCase_From_UpperCase()
        {
            // Arrange
            string str = "I AM LIVING IN PORBANDAR";

            // Act
            string result = str.ToLowerCase();
            // Assert
            Assert.Equal("i am living in porbandar", result);
        }

        /// <summary>
        /// Convert into lowercase from mixedcase
        /// </summary>

        [Fact]
        public void Convert_To_LowerCase_From_MixedCase()
        {
            // Arrange
            string str = "This iS ThE TeStCase of ConVert intO MiXEdCase froM LowerCAse";

            // Act
            string result = str.ToLowerCase();
            // Assert
            Assert.Equal("this is the testcase of convert into mixedcase from lowercase", result);
        }

        /// <summary>
        /// Convert into titlecase from lowercase
        /// </summary>

        [Fact]

        public void Convert_To_TitleCase_From_LowerCase()
        {
            string str = "my name is anand odedara";
            string expectedResult = "My Name Is Anand Odedara";

            var result = str.ToTitleCase();
           Assert.Equal(expectedResult, result);
        }

        /// <summary>
        /// Convert into titlecase from uppercase
        /// </summary>

        [Fact]

        public void Convert_To_TitleCase_From_UpperCase()
        {
            string str = "THIS IS TESTING ASSIGNMENT";
            string expectedResult = "This Is Testing Assignment";

            var result = str.ToTitleCase();
            Assert.Equal(expectedResult, result);
        }

        /// <summary>
        /// Check if the given input is in lowercase or not
        /// </summary>

        [Fact]
        public void Check_If_LowerCase()
        {
            string str = "anand";
            bool result = str.CheckLowerCase();
           Assert.True(result);
        }

        /// <summary>
        /// Check if the given input is in uppercase or not
        /// </summary>

        [Fact]
        public void Check_If_UpperCase()
        {
            string str = "ANAND";
            bool result = str.CheckUpperCase();
            Assert.True(result);
        }

        /// <summary>
        /// Convert into capitalize 
        /// </summary>

        [Fact]
        public void Convert_To_Capitalize()
        {
            string str = "anand";
            string result = str.Capitalize();
            Assert.Equal("Anand", result);
        }

        /// <summary>
        /// To check the given input is in numeric form or not
        /// </summary>

        [Fact]
        public void Check_If_Not_Numeric()
        {
            string str = "anand";
            bool result = str.IsNumericValue();
           Assert.False(result);
        }

        /// <summary>
        /// To check the given input is in numeric form or not
        /// </summary>

        [Fact]
        public void Check_If_Numeric()
        {
            string str = "122";
            bool result = str.IsNumericValue();
            Assert.True(result);
        }

        /// <summary>
        /// Remove last character 
        /// </summary>

        [Fact]
        public void Remove_Last_Character()
        {
            string str = "anand";
            string result = str.ToRemoveLastCharachter();
            Assert.Equal("anan", result);
        }

        /// <summary>
        ///   Get word count
        /// </summary>

        [Fact]
        public void Get_Word_Count()
        {
            string str = "test test";
            int result = str.GetWordCount();
           Assert.Equal(2, result);
        }

        /// <summary>
        /// Convert string into integer
        /// </summary>


        [Fact]
        public void Convert_String_To_Int()
        {
            string str = "123456";
            int result = str.ConvertStringToInt();
            Assert.Equal(123456, result);
        }
    }
}
