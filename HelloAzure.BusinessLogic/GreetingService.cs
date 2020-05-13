using System;

namespace HelloAzure.BusinessLogic
{
    public class GreetingService
    {
        public string GetGreeting(string name)
        {
            return $"Hello, {name}, what can do for you!";
        }
    }
}
