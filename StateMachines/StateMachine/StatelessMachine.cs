using System;
using Stateless;
using Stateless.Graph;

namespace StateMachine
{
    public class StatelessBasedMachinne
    {
        public enum State
        {
            On,
            Off,
            Playing,
            Silent
        }

        public enum Trigger
        {
            SwitchOn,
            SwitchOff,
            Play,
            Stop
        }

        private readonly StateMachine<State, Trigger> _machine;

        public StatelessBasedMachinne()
        {
            _machine = new StateMachine<State, Trigger>(State.Off);
            _machine.Configure(State.Off).Permit(Trigger.SwitchOn, State.On)
                .OnEntry(() => Console.WriteLine("Powering up"));
            
            _machine.Configure(State.On).Permit(Trigger.SwitchOff, State.Off)
                .OnEntry(() => Console.WriteLine("Powering down"));
            
            _machine.Configure(State.On).Permit(Trigger.Play, State.Playing)
                .OnEntry(() => Console.WriteLine("Playing"));
            
            _machine.Configure(State.Playing).Permit(Trigger.Stop, State.Silent)
                .OnEntry(() => Console.WriteLine("Stopping"));

            _machine.Configure(State.Off).Ignore(Trigger.Play);

            _machine.Configure(State.Playing).Permit(Trigger.SwitchOff, State.Off)
                .OnEntry(() => Console.WriteLine("Switching off"));
            
            _machine.Configure(State.Silent).Permit(Trigger.Play, State.Playing)
                .OnEntry(() => Console.WriteLine("Playing"));
            
            _machine.Configure(State.Silent).Permit(Trigger.SwitchOff, State.Off)
                .OnEntry(() => Console.WriteLine("Switching off"));
            var graph = UmlDotGraph.Format(_machine.GetInfo());
            Console.WriteLine(graph);
        }

        public void SwitchOn()
        {
            _machine.Fire(Trigger.SwitchOn);
        }

        public void SwitchOff()
        {
            _machine.Fire(Trigger.SwitchOff);
        }

        public void Play()
        {
            _machine.Fire(Trigger.Play);
        }

        public void Stop()
        {
            _machine.Fire(Trigger.Stop);
        }


        public State CurrentState => _machine.State;

    }
}