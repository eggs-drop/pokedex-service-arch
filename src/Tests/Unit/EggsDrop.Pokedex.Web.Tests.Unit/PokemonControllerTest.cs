using EggsDrop.Pokedex.Web.Controllers;
using Xunit;

namespace EggsDrop.Pokedex.Web.Tests.Unit
{
    public class PokemonControllerTest
    {
        [Fact]
        public void Get_PlaceholderImplementation_ReturnsMessage() // this is an interim test to get have a test project & test in place with the initial check-in
        {
            var controller = new PokemonController();
            var result = controller.Get();

            Assert.Equal("Success", result.Content);
        }
    }
}
