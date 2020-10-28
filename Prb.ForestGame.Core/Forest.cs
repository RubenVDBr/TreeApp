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

        //ga naar 3.0 vanonder


        /////////////////////////////////////////////////////////////////////   4.0   /////////////////////////////////////////////////////////////////////
        /// 
        /// we maken hier een int property die de totale vogels zal bijhouden van al onze bomen in totaal. De get binnen de property kan 
        /// je extra programmeren ipv het gewoon leeg te laten zoals:   public int MyProperty { get; set; }
        /// de Get is wat teruggestuurd wordt als we Forest.BirdCount oproepen. 
        /// 
        public int BirdCount
        {
            get
            {
                //we maken hier een nieuwe variabele aan om mee te werken intern.
                int birdCount = 0;

                //we gaan beginnen lussen door onze lijst dat we eerder hebben gemaakt. Lees deze lus als: Voor elk object Boom die wij boom noemen in dit geval, in de lijst Trees.
                //We kunnen hier tree evengoed auto of aiello noemen. In de lus zullen we elk object een voor een overlopen en je kan dit object selecteren of aanspreken
                //dmv de variabele naam dat we hier aanmaken. In dit geval dus tree.iets, maar dit kan je noemen wat je wil, de functionaliteit zal nooit breken.
                //het is gewoon gemakkelijker om te lezen binnenin je lus. (remember, gebruik foreach -> tab -> tab om gemakklijk de structuur te hebben)
                foreach (Tree tree in Trees)
                {
                    //we tellen hier de vogels van een enkele boom op in een totaal, nl birdCount. We zullen dit herhalen voor elke boom in de lijst.
                    //zie hoe gemakkelijk wij aan de vogels van onze boom kunnen, gewoon tree.NumberOfBirds aanspreken en we krijgen het.
                    //Dit is het grote nut van klasses en objecten.
                    birdCount += tree.BirdCount;
                }
                return birdCount;
            }
        }

        //hetzelfde concept als hierboven, maar met squirrels. We overlopen elke boom en kijken als er een squirrel in zit, als dit het geval is
        //tellen we eentje bij squirrelCount. Dat totaal retourneren we hier in deze property. Overloop deze code eens en let goed op hoe we
        //hier opnieuw een property van ons object Tree oproepen.
        public int SquirrelCount
        {
            get
            {
                int squirrelCount = 0;
                foreach (Tree tree in Trees)
                {
                    if (tree.HasSquirrel)
                    {
                        squirrelCount++;
                    }
                }
                return squirrelCount;
            }
        }
        //ga naar 5.0


        /////////////////////////////////////////////////////////////////////   3.0   /////////////////////////////////////////////////////////////////////
        ///
        //dit is onze constructor opnieuw, vanaf dat er een nieuwe forest wordt aangemaakt zal deze uitgevoerd worden.
        //we geven het aantal bomen mee die moeten gemaakt worden. Deze parameter zal in de uiteindelijke lus moeten binnenin onze constructor.
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

        //ga nu naar 4.0 hierboven ergens

        /////////////////////////////////////////////////////////////////////   5.0   /////////////////////////////////////////////////////////////////////
        ///je bent gewend van public voids te schrijven in je wpf app, maar een heel goeie locatie voor die is binnen je klasses. Hier zullen
        ///een aantal methodes gemaakt worden die functionaliteit voor onze button clicks en zo zullen bezorgen. We zullen nog altijd
        ///eventhandlers maken, maar binnen de eventhandler button_click ofzo zullen we gewoon Forest.SquirrelAttack() roepen bvb.
        
        //We willen dat deze methode uitgevoerd wordt als we op de knop squirrels duwen. De eventhandler aanmaken en zo in de wpf app is voor straks.
        //Eerst zullen we de code hier schrijven. Bedoeling is dat de boom een squirrel krijgt en dat de vogels wegvliegen (=gehalveerd worden).
        public void SquirrelPlague()
        {
            //we overlopen elk object boom in de lijst Trees. Als je niet meer weet wat wat is, ctrl + click op de namen en dan
            //ga je terug naar waar we ze aangemaakt hebben. Zo kan je mss eens opfrissen wat onze lijst bvb was.
            foreach (Tree tree in Trees)
            {
                //we maken een int die 0 of 1 zal zijn (technisch gezien is een boolean eleganter ma #care)
                int putSquirrel = random.Next(0, 2);

                //als de putSquirrel 1 is dan 
                if (putSquirrel == 1)
                {
                    //zetten we de boolean HasSquirrel op true
                    tree.HasSquirrel = true;
                    //en delen we de BirdCount door 2
                    tree.BirdCount /= 2;
                }
            }
        }

        //delete een random boom uit mn lijst
        public void LumberJackCutsTree()
        {
            //we maken hier een int aan die een random boom selecteert.
            //we doen dit dmv een random getal van 0 tot de lengte van onze lijst van bomen.
            int treeNumber = random.Next(0, Trees.Count);

            //we spreken onze lijst aan met Trees en roepen een voorgemaakte functie op van windows.
            //RemoveAt verwijdert een boom op de plaats die we meegeven in onze lijst. We geven
            //dus treeNumber mee want die geeft ons een random boom terug.
            Trees.RemoveAt(treeNumber);
        }


        //als we ons object terug willen steken in een listbox of label of whatever dan zal het opnieuw nie weten wa gedaan en gwn
        //Prb.ForestGame.Forest weergeven. Da willen we nie en dit maakt zodat het ipv dat hij nie weet wa gedaan, een string retourneert.
        public override string ToString()
        {
            return $"Forest with {Trees.Count} trees, {BirdCount} birds, {SquirrelCount} squirrels";
        }

        //ga nu naar 6.0 in Wpf MainWindow, dit is de eerste keer dat we hier naartoe gaan.
    }
}
