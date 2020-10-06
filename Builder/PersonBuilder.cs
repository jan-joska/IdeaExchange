using System;

namespace Builder
{
    public class PersonBuilder
    {
        public PersonBuilder(string personName)
        {
            Build = new Person(personName);
        }


        public Person Build { get; }

        public PersonBuilder WithBirthDay(DateTime dateOfBirth)
        {
            Build.DateOfBirth = dateOfBirth;
            return this;
        }

        public PersonBuilder WithLeftEye(EyeBuilder eyeBuilder)
        {
            Build.LeftEye = eyeBuilder.Build();

            return this;
        }

        public PersonBuilder WithRithEye(ConsoleColor color)
        {
            Build.RightEye = new Eye(color);
            return this;
        }

    }
}