using System;

namespace Builder
{
    public class EyeBuilder
    {
        private readonly Eye _instance;

        public EyeBuilder(ConsoleColor color)
        {
            _instance = new Eye(color);
        }

        public EyeBuilder SetName(string name)
        {
            _instance.Name = name;
            return this;
        }

        public Eye Build()
        {
            return _instance;
        }
    }
}