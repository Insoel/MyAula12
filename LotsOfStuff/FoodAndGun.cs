using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula12
{
    public struct FoodAndGun
    {
        public readonly Food food;
        public readonly Gun gun;

        public FoodAndGun(Food food, Gun gun)
        {
            this.food = food;
            this.gun = gun;
        }
    }
}
