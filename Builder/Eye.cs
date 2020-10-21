using System;

namespace Builder
{
    public class Eye
    {
        internal Eye(ConsoleColor color)
        {
            Color = color;
        }

        public ConsoleColor Color { get; }

        public string Name { get; set; }

        public override string ToString()
        {
            return Color.ToString();
        }
    }
}