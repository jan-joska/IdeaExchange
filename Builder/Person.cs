using System;

namespace Builder
{
    public class Person
    {
        internal Person(string name)
        {
            Name = name;
        }



        public string Name { get; }

        public DateTime DateOfBirth { get; set; }


        public Eye LeftEye { get; set; }
        public Eye RightEye { get; set; }

        public override string ToString()
        {
            return
                $"{nameof(Name)}: {Name}, {nameof(DateOfBirth)}: {DateOfBirth}, {nameof(LeftEye)}: {LeftEye}, {nameof(RightEye)}: {RightEye}";
        }
    }
}