using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace ExamDAOnAbp.Pages;

public class Index_Tests : ExamDAOnAbpWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
