using Microsoft.JSInterop;

namespace BlazorJS
{
    public class Hello
    {
        public Hello(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        [JSInvokable]
        public string SayHello() => $"Hello, {Name}!";
    }
}
