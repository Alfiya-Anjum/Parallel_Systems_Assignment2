using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirclePaintingSimulation
{
    public class Circle
    {
        public int Id { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public bool IsPainted { get; set; } = false;
        public static float Radius = 10f; //visualization radius
    }
}
