using System;
using System.Collections.Generic;

namespace StateMachine
{
    public class TableBasedStateMachine
    {
        private readonly Dictionary<KeyValuePair<State, Operation>, Action> _table =
            new Dictionary<KeyValuePair<State, Operation>, Action>();

        private State _currentState = State.Red;

        public TableBasedStateMachine()
        {
            //Fill table
            _table.Add(new KeyValuePair<State, Operation>(State.Green, Operation.Tick),
                () =>
                {
                    _currentState = State.YellowFromGreen;
                    Red = false;
                    Yellow = true;
                    Green = false;
                });

            _table.Add(new KeyValuePair<State, Operation>(State.Red, Operation.Tick),
                () =>
                {
                    _currentState = State.YellowFromRed;
                    Red = true;
                    Yellow = true;
                    Green = false;
                });

            _table.Add(new KeyValuePair<State, Operation>(State.YellowFromGreen, Operation.Tick),
                () =>
                {
                    _currentState = State.Red;
                    Red = true;
                    Yellow = false;
                    Green = false;
                });

            _table.Add(new KeyValuePair<State, Operation>(State.YellowFromRed, Operation.Tick),
                () =>
                {
                    _currentState = State.Green;
                    Red = false;
                    Yellow = false;
                    Green = true;
                });
        }

        public bool Red { get; private set; }
        public bool Yellow { get; private set; }
        public bool Green { get; private set; }

        private class ColorContext : IDisposable
        {
            private readonly ConsoleColor _original;

            public ColorContext(ConsoleColor color)
            {
                _original = Console.ForegroundColor;
                Console.ForegroundColor = color;
            }

            public void Dispose()
            {
                Console.ForegroundColor = _original;
            }
        }

        public void Display()
        {
            Console.WriteLine($"Current state: {_currentState}");
            Console.WriteLine($"Red:    {Red}");
            Console.WriteLine($"Yellow: {Yellow}");
            Console.WriteLine($"Green:  {Green}");
            Console.WriteLine("-----");
        }

        private enum State
        {
            Red,
            YellowFromRed,
            YellowFromGreen,
            Green
        }

        private enum Operation
        {
            Tick
        }

        public void Tick()
        {
            _table[new KeyValuePair<State, Operation>(_currentState, Operation.Tick)].Invoke();
        }

    }
}