using Newtonsoft.Json;
using VTopeApiBot.Types.Enums;
using VTopeApiBot.Types.Responses;
using Xunit;
using static Xunit.Assert;

namespace VTopeApiBot.Tests.Avaible_Methods
{
    public class CodeResponseTests
    {
        [Fact]
        public void Deserialize_Ok_Response()
        {
            // Arrange
            const string json = @"{ ""code"":  ""ok""}";

            // Act
            var response = JsonConvert.DeserializeObject<CodeResponse>(json);
            
            // Assert
            Equal(Code.Ok, response.Code);
        }
        
        [Fact]
        public void Deserialize_NotFound_Response()
        {
            // Arrange
            const string json = @"{ ""code"":  ""notfound""}";

            // Act
            var response = JsonConvert.DeserializeObject<CodeResponse>(json);
            
            // Assert
            Equal(Code.NotFound, response.Code);
        }
    }
}