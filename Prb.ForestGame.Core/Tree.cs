using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Prb.ForestGame.Core
{
    public class Tree
    {
        //het boomtype zal altijd maar uit 2 types bestaan, dit staat vast. Dus we gebruiken een enum. Een soort constante array
        //dit had evengoed een 'public string TreeType
        public enum TreeType { Decidious, Evergreen }

        //we roepen een willekeurig getal op. Als je hovert over Random, dan zie je dat dit ook een klasse is. Visual studio
        //heeft dus voor ons al een Random klasse voorgemaakt. We steken hier een lege klasse/blueprint in de variabele 'random'
        //om later te gebruiken.
        private static Random random = new Random();

        //we declareren een property, dit is een onderdeel van je object/klasse. Dit wordt op deze manier gedaan en kan heel kort
        //via "prop" -> tab -> tab heel gemakkelijk en snel aangemaakt. Get = kan gelezen worden, 
        //set = kan geschreven/aangepast worden
        public int Id { get; set; }


        public int NumberOfBirds { get; set; }

        //minimum en maximum hoogte staan op private, dit moet niet uitgezonden worden in het uiteindelijke scherm.
        //we hebben dit puur intern in onze klasse nodig. Dit is een soort constraint. We gebruiken deze variabelen enkel 
        //wanneer we ons uiteindelijke hoogte (als property) aanmaken.
        private int minHeight = 5;
        private int maxHeight = 10;
        private int height;
        private int maxBirdCount = 10;

        //we declareren onze property en kunnen hier code schrijven in onze set en get. Dit wordt niet vaak gedaan maar
        //wordt dus op deze manier gedaan. Dit zijn voorwaarden van je property.
        public int Height
        {
            get { return height; }
            set
            {
                if (height <= minHeight)
                {
                    height = minHeight;
                }
                else if (value >= maxHeight)
                {
                    height = maxHeight;
                }
                height = value; }
        }

        //een property die aangeeft als een boom een squirrel bevat of niet. Get = kan gelezen worden, 
        //set = kan geschreven/aangepast worden
        public bool HasSquirrel { get; set; }
        public TreeType Type { get; set; }


        public Tree(int number)
        {
            Id = number;
            Type = (TreeType)random.Next(0, Enum.GetValues(typeof(TreeType)).Length);
            //Type = (TreeType)random.Next(0, 2);             dit is hetzelfde, dit hierboven is wat moeilijk, maar berekent de lengte van de enum

            NumberOfBirds = random.Next(maxBirdCount + 1);
            Height = random.Next(minHeight, maxHeight + 1);
            HasSquirrel = false;
        }
        
        //dit is constructor chaining. Het zal eerst de constructor van hierboven uitvoeren. This zou eigenlijk 'public Tree(int number)
        //zijn van hierboven. stel dat we nog een public Tree hadden met de parameter (int numberOfBirds) dan zou dit 
        //this(numberOfBirds) zijn. 
        public Tree(int number, int height): this(number)
        {
            Height = height;
        }

        //op het moment dat je een stukje tekst van deze klasse wil tonen. Dus wanneer je de klasse.ToString() doet, dan zal
        //het automatisch deze string sturen. In dit geval zou dit zijn wanneer we Tree.ToString() aanroepen. Je kan niet zomaar
        //een volledig object veranderen naar een string. Da zou een error geven, maar als je dit hier zo definieert dan 
        //override je dit en return je deze string in de plaats.
        public override string ToString()
        {
            return $"Tree {Id} of type {Type} - birds: {NumberOfBirds}, height: {Height} - squirrel: {HasSquirrel}";
        }
    }
}
