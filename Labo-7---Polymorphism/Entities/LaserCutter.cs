using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Labo_7___Polymorphism.Entities
{
    public class LaserCutter : Router
    {
        public double Accuracy { get; set; }
        protected override int LifeSpanCostPerMinute => 1500;

        public LaserCutter
            (string naam, int breedte, int lengte, float kostprijsperminuut, double accuracy)
            : base(naam, breedte, lengte, kostprijsperminuut)
        {
            this.LifeSpan = 5000;
            this.Accuracy = accuracy;
        }

        public override void Use(int numberOfMinutes)
        {
            this.LifeSpan = Convert.ToInt32((this.LifeSpan - (CostPerMinute + 100)));
        }

        public override string ToString()
        {
            return $"LASER:\t{this.Name} ({this.WorkSpaceLength}x{this.WorkSpaceWidth}) [accuracy: {this.Accuracy}] {base.LifeSpanInfo()}";
        }
    }
}
