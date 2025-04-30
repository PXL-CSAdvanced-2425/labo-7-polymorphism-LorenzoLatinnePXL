using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Labo_7___Polymorphism.Entities
{
    public class Router : Machine
    {
        public double WorkSpaceWidth { get; set; }
        public double WorkSpaceLength { get; set; }
        public double CostPerMinute { get; set; }
        protected override int LifeSpanCostPerMinute => 50;

        public Router(string name, int breedte, int lengte, float kostprijsperminuut) : base(name)
        {
            WorkSpaceWidth = breedte;
            WorkSpaceLength = lengte;
            CostPerMinute = kostprijsperminuut;
            this.LifeSpan = 25000;
        }

        public override void Use(int numberOfMinutes)
        {
            LifeSpan = this.LifeSpan - numberOfMinutes;
        }

        public override string ToString()
        {
            return $"ROUTER:\t'{this.Name}' ({this.WorkSpaceLength}x{this.WorkSpaceWidth}) {base.LifeSpanInfo()}";
        }
    }
}
