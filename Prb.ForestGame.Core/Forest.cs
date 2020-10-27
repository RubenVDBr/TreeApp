using System;
using System.Collections.Generic;
using System.Text;

namespace Prb.ForestGame.Core
{
    public class Forest
    {
        //variabelen die voor intern gebruik zijn, de buitenwereld moet hier nooit van weten, enkel ik.
        private static Random random = new Random();
        private int minimumTreeCount = 5;

        public List<Tree> Trees { get; }

        public int BirdCount
        {
            get
            {
                int birdCount = 0;
                foreach (Tree tree in Trees)
                {
                    birdCount += tree.NumberOfBirds;
                }
                return birdCount;
            }
        }

        //public int SquirrelCount
        //{
        //    get
        //    {
        //        int squirrelCount = 0;
        //        foreach (Tree tree in Trees)
        //        {
        //            squirrelCount += tree.NumberOfBirds;
        //        }
        //        return birdCount;
        //    }
        //}

        public Forest(int treeCount)
        {
            if (treeCount < minimumTreeCount)
            {
                treeCount = minimumTreeCount;
            }


            Trees = new List<Tree>();


            for (int i = 1; i < treeCount; i++)
            {
                Tree tree = new Tree(i);
                Trees.Add(tree);
            }
        }
    }
}
