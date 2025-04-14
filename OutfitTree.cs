using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    public class OutfitTree
    {
        public OutfitNode Root { get; private set; }

     
        public void Add(Outfit outfit)
        {
            Root = AddRecursive(Root, outfit);
        }

        private OutfitNode AddRecursive(OutfitNode current, Outfit outfit)
        {
            if (current == null)
            {
                return new OutfitNode(outfit);
            }

            if (outfit.Id < current.Outfit.Id)
            {
                current.Left = AddRecursive(current.Left, outfit);
            }
            else if (outfit.Id > current.Outfit.Id)
            {
                current.Right = AddRecursive(current.Right, outfit);
            }

            return current;
        }
        public void Balance()
        {
            List<Outfit> outfits = new List<Outfit>();
            StoreInOrder(Root, outfits);
            Root = BuildBalancedTree(outfits, 0, outfits.Count - 1);
        }

        private void StoreInOrder(OutfitNode node, List<Outfit> outfits)
        {
            if (node != null)
            {
                StoreInOrder(node.Left, outfits);
                outfits.Add(node.Outfit);
                StoreInOrder(node.Right, outfits);
            }
        }

        private OutfitNode BuildBalancedTree(List<Outfit> outfits, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            int mid = (start + end) / 2;
            OutfitNode node = new OutfitNode(outfits[mid]);

            node.Left = BuildBalancedTree(outfits, start, mid - 1);
            node.Right = BuildBalancedTree(outfits, mid + 1, end);

            return node;
        }
        public void PrintInOrder(OutfitNode node)
        {
            if (node != null)
            {
                PrintInOrder(node.Left);
                Console.WriteLine(node.Outfit);
                PrintInOrder(node.Right);
            }
        }
    }
}
