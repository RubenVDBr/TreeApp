using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Prb.ForestGame.Core
{
    //vergeet niet je class direct public te maken.
    public class Tree
    {
        /////////////////////////////////////////////////////////////////////   1.0   /////////////////////////////////////////////////////////////////////
        /// 
        /// We hebben nu onze klasse aangemaakt en beginnen met een heleboel properties in te stellen. Je moet je dit voorstellen alsof we
        /// een blueprint aan het maken zijn. Of zo'n spel van kleuters waar ze blokjes in de juiste vormen moeten steken. 
        /// Wij stellen hier gewoon de vormen in, later kunnen er dan blokjes in gestoken worden. 
        /// 

        //we maken hier onze eerste property aan. Ons Boom object zal dus een TreeType hebben, tis van de eerste keer een beetje een uitzondering.
        //het boomtype zal altijd maar uit 2 types bestaan, dit staat vast. Dus we gebruiken een enum. Een soort constante array die nooit zal veranderen.
        //als we later dus dit willen aanspreken, zullen we deze enum met Decidious en Evergreen terugkrijgen.
        public enum TreeType { Decidious, Evergreen }

        //we prepareren hier onze functionaliteit om later een random getal te kunnen genereren. Als je hovert over Random, 
        //dan zie je dat dit ook een klasse is. Visual studio
        //heeft dus voor ons al een 'Random' klasse voorgemaakt. We steken hier een lege klasse/blueprint in de variabele 'random'
        //om later te gebruiken. We kunnen vanaf nu supergemakkelijk random.eenPropertyofFunctie oproepen, zoals random.Next(1,4)
        private static Random random = new Random();

        //we declareren een property, dit is nog een onderdeel van je object/klasse. Dit wordt op deze manier gedaan en kan heel kort
        //via "prop" -> tab -> tab heel gemakkelijk en snel aangemaakt. Get en Set betekenen heel snel: Get = kan gelezen worden, 
        //set = kan geschreven/aangepast worden. Als we een prop aanmaken dan begint dit altijd met een hoofdletter, in tegenstelling tot gewone variabelen.
        //public int MyProperty { get; set; }         (prop result)
        public int Id { get; set; }


        //minimum en maximum hoogte staan op private, dit moet niet uitgezonden worden naar de uiteindelijke app.
        //we hebben dit puur intern in onze klasse nodig. We gebruiken deze variabelen enkel wanneer we onze
        //uiteindelijke hoogte (als property) aanmaken.
        private int minHeight = 5;
        private int maxHeight = 10;
        private int height;

        //nog eentje die we enkel intern nodig hebben, note dat dit ook gewone variabelen zijn en geen properties. 
        //Properties kan je herkennen aan hun {get; set;}
        private int maxBirdCount = 10;

        //we declareren onze property en kunnen hier code schrijven in onze set en get. Dit wordt niet vaak gedaan maar
        //wordt dus op deze manier gedaan. Dit zijn voorwaarden van je property. We spelen hier met onze variabelen
        //die we eerder hebben aangemaakt. Uiteindelijk zegt deze code heel simpel: We maken een int Height aan voor
        //ons object Tree. Deze moet de variabele height returnen en als de height kleiner is dan het minimum, wordt het minimum
        //dan. Als het groter is dan de max, wordt de max. 

        //probeer zeker hier eens te werken met snippets. Als je sommige woordjes intypt en dan 2 keer op tab duwt kan je
        //het jezelf soms zo makkelijk maken. Hier hebben we propfull gebruikt. Een lijst van de snippets die je het meest zal gebruiken:
        //for, foreach, if, else, prop, ctor en while
        public int Height
        {
            get { return height; }
            set
            {
                if (value <= minHeight)
                {
                    height = minHeight;
                }
                else if (value >= maxHeight)
                {
                    height = maxHeight;
                }
                else 
                {
                    height = value;
                }
                
            }
        }
        
        //een property die aangeeft als een boom een squirrel bevat of niet. Get = kan gelezen worden, 
        //set = kan geschreven/aangepast worden
        public bool HasSquirrel { get; set; }

        //Waarom hebben we hier nu opnieuw een type??? Hebben we niet in het begin onze enum aangemaakt met onze 2 types? 
        //Je kan nie echt Boom.TreeType oproepen want we krijgen een enum terug. We willen echt efficient ons type terugkrijgen
        //ipv een random enum. Zeker als je enum gigantisch groot is bvb.
        public TreeType Type { get; set; }

        //als we propfull -> tab -> tab doen dan krijgen we een veel langere versie van onze gewone prop. propfull result ↓

        //private int myVar;

        //public int MyProperty
        //{
        //    get { return myVar; }
        //    set { myVar = value; }
        //}

        //let goed op de hoofdletters hier
        //we doen bijna exact hetzelfde als bij de height. Dit is een soort constraint op onze property. Kan niet onder 0 zijn.
        private int birdCount;

        public int BirdCount
        {
            get { return birdCount; }
            set 
            {
                if (value < 0)
                {
                    birdCount = 0;
                }
                else
                {
                    birdCount = value;
                }
            }
        }


        //Deze code wordt uitgevoerd wanneer er een nieuwe boom gemaakt wordt. Zo'n code heten we een constructor. Dit wordt in het begin
        //uitgevoerd, dus maakt niet uit als deze vanonder of vanboven staat. De positie is gewoon conventie. (ctor -> tab -> tab btw)
        //Wat we hier doen is een nieuw object maken, we hebben dus onze vorm of blueprint helemaal klaargezet maar er zit nog niks in. 
        //Als we straks dit oproepen in onze wpf app zal er hier dus een boom aangemaakt worden en zullen we hem vullen.
        public Tree(int id) //we geven een nummer mee met de code als parameter.
        {
            //ctrl + click eens op de Id. Je ziet dat we die boven hebben aangemaakt. Nu zijn we een voor een onze properties aan het vullen.
            //onze Tree.Id vullen we met het meegegeven id van hierboven.
            Id = id;

            //Stel dat we hier 
            //Type = (TreeType)1;
            //doen, dan zouden alle bomen die aangemaakt worden Evergreen worden, omdat deze de laatste positie heeft in de enum. (remember, begint vanaf positie 0)
            //maar we willen dat het een van de twee willekeurig kiest uit de enum. Hier gebruiken we random.Next(0,2) voor. We moeten wel geen nummer steken in type
            //maar een TreeType. Ctrl + click eens op Type en je zal zien dat Type een TreeType is. Geen string, geen int maar iets dat we volledig zelf hebben aangemaakt.
            //(TreeType) is een makkelijke manier om dit om te zetten naar het object dat we willen.

            Type = (TreeType)random.Next(0, Enum.GetValues(typeof(TreeType)).Length);
            //Type = (TreeType)random.Next(0, 2);             dit is hetzelfde, dit hierboven is wat moeilijk, maar berekent de lengte van de enum.


            //Hier vullen we de int NumberOfBirds met een random nummer die maximum maxBirdCount + 1 heeft. Waarom +1? Omdat als je random.Next(1,8) doet zal het max 
            //nummer 7 zijn. 8 is de grens, dus je moet altijd +1 doen.
            BirdCount = random.Next(maxBirdCount + 1);

            //we vullen de hoogte in, ook met een random, deze keer stellen we het minimum ook wel in.
            Height = random.Next(minHeight, maxHeight + 1);

            //de boolean HasSquirrel zal automatisch voor elke aangemaakte boom op false staan.
            HasSquirrel = false;
        }
        
        //dit is constructor chaining. Het zal eerst de constructor van hierboven uitvoeren. This zou eigenlijk 'public Tree(int number)'
        //zijn van hierboven. stel dat we nog een public Tree hadden met de parameter (int numberOfBirds) dan zou dit 
        //this(numberOfBirds) zijn. Stel dat je een id EN een height meekrijgt wordt deze uitgevoerd. Altijd eerst de constructor na de : tho.
        //Dit is redelijk advanced en zie je pas in Programming advanced (badum tss) denk ik.
        public Tree(int id, int height): this(id)
        {
            Height = height;
        }

        //als je een instantie van je klasse in je listbox dumpt, standaard geeft ie dan Prb.ForestGame.Core.Tree terug. Hij weet nie
        //goe wat hij moet teruggeven. De ToString() methode bestaat voor elk object al in c#. Dus met zo'n override als hier 
        //zetten we een soort replacement voor wat hij moet teruggeven als hij nie weet wat terug te geven, dus als het Prb.ForestGame.core.Tree is.
        public override string ToString()
        {
            return $"Tree {Id} of type {Type} - birds: {birdCount}, height: {Height} - squirrel: {HasSquirrel}";
        }
    }
    //ga nu naar 2.0 in Forest.cs
}
