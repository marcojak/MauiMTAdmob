namespace MauiLib2
{
    // All the code in this file is included in all platforms.
    public class TestService : ITestService
    {
        string ITestService.SayHello()
        {
            return "Hello";
        }
    }
}