using System;
using System.Collections.Generic;
using System.Text;

namespace Prb.ForestGame.Core
{        /////////////////////////////////////////////////////////////////////   2.0   /////////////////////////////////////////////////////////////////////

    public class Forest
    {
        //variabelen die voor intern gebruik zijn, de buitenwereld moet hier nooit van weten, enkel ik.
        //we maken opnieuw onze variabele random en vullen hem met een lege Random klasse. We maken een int
        //met het minimum aantal bomen om later intern te gebruiken.

        private static Random random = new Random();
        private int minimumTreeCount = 5;

        //We maken hier een property Trees, wat hier uiteindelijk in zal gaan zitten, is een Lijst van het object/klasse Tree
        //dit is dus een lege lijst van Tree objecten/klasses.
        public List<Tree> Trees { get; set; }

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

        //dit is onze constructor opnieuw, vanaf dat er een nieuwe forest wordt aangemaakt zal deze uitgevoerd worden.
        //we geven het aantal bomen mee die moeten gemaakt worden. Deze parameter zal in de uiteindelijke lus moeten.
        public Forest(int treeCount)
        {
            //Er moet een minimum aantal bomen zijn. We hebben deze eerder in de klasse ingesteld hierboven.
            if (treeCount < minimumTreeCount)
            {
                treeCount = minimumTreeCount;
            }

            //Momenteel is er nog geen lijst van bomen. Enkel de vorm bestaat. Wat we hier doen is een nieuwe lijst aanmaken.
            //Let wel, de lijst is nog altijd leeg, maar er zit wel al een lege lijst in de vorm nu en we kunnen die beginnen vullen.
            //Als je met lijsten werkt moet je die altijd eerst initialiseren voordat je er mee werkt, anders zal je niet ver geraken.
            Trees = new List<Tree>();

            //dit is een for lus (for -> tab -> tab). We tellen hier tot het aantal dat we meegegeven hebben, het aantal bomen dat we willen aanmaken dus.
            for (int i = 1; i < treeCount; i++)
            {
                //we maken een nieuwe variabele tree, dat van het object Tree is. We steken er een nieuwe Tree(i) in. Wat dit doet is onze constructor
                //in Tree.cs oproepen, daar hadden we een parameter id die moest meegegeven worden. Ideaal voor een lus dus.
                Tree tree = new Tree(i);

                //we voegen het object Tree die we net hebben gevuld met relevante data toe aan de voorlopig lege lijst Trees. Die zal nu
                //serieus gevuld raken tijdens de loop. We hebben nu dus echt een hele hoop Tree objecten met verschillende data in onze Trees.
                Trees.Add(tree);
            }
        }
    }
}
