using System;

namespace StateMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            TableBasedStateMachine s = new TableBasedStateMachine();
            for (int i = 0; i < 10; i++)
            {
                s.Tick();
                s.Display();
            }

            try
            {
                StatelessBasedMachinne m = new StatelessBasedMachinne();
                m.SwitchOn();
                m.SwitchOff();
                m.Play();
                m.SwitchOn();
                m.Play();
                m.Stop();
                m.Play();
                m.SwitchOff();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }
        }
    }
}
