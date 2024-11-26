using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirclePaintingSimulation
{
    public class Worker
    {
        public int Id { get; set; }
        public List<int> PaintedCircles { get; set; } = new List<int>();
        public Color WorkerColor { get; set; } 
    }
}
