using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo_7___Polymorphism.Entities
{
    public class General : Machine
    {
        protected override int LifeSpanCostPerMinute => 1;
        public General(string name) : base(name)
        {
            this.LifeSpan = 1000;
        }
        public override void Use(int numberOfMinutes)
        {
            this.LifeSpan = this.LifeSpan - (this.LifeSpanCostPerMinute * numberOfMinutes);
        }

        public override string ToString()
        {
            return $"{this.Name} {base.ToString()}";
        }
    }
}
