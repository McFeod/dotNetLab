using System;
using LabOneCinema.Logging;

namespace LabOneCinema.People
{
    public class Boss : Person, IHiring<Person>
    {
        public Boss(string name) : base(name)
        {
        }

        public void Hire(Person person, decimal salary)
        {
            throw new System.NotImplementedException();
        }

        public event EventHandler<HiringEventArgs> OnHire;
    }
}