using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    public class OutfitNode
    {
        public Outfit Outfit { get; set; }
        public OutfitNode Left { get; set; }
        public OutfitNode Right { get; set; }

        public OutfitNode(Outfit outfit)
        {
            Outfit = outfit;
            Left = null;
            Right = null;
        }
    }
}
