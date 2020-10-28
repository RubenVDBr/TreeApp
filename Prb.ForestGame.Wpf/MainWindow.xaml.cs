using System.Windows;
using Prb.ForestGame.Core;


namespace Prb.ForestGame.Wpf
{
    public partial class MainWindow : Window
    {
        /////////////////////////////////////////////////////////////////////   6.0   /////////////////////////////////////////////////////////////////////
        /// We maken hier een variabele aan die van de klasse Forest is. Deze is volledig leeg en momenteel redelijk nutteloos, maar eenmaal
        /// we die opvullen kunnen we er over heel ons programma aan. Daarom is deze hier gedeclareerd.
        Forest forest;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        //window loaded = wanneer ons scherm geladen wordt, dus het eerste dat gebeurt bijna.
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //we roepen onze methode CreateForest() op.
            CreateForest();
        }

        private void CreateForest()
        {
            ///we maken hier onze forest aan. ctrl + click eens op die Forest(36), je ziet dat we de constructor daarmee aanspreken. Overloop die code
            ///om zeker te snappen wat er gebeurt wanneer we hier een nieuwe Forest aanmaken. We steken in onze globale variabele forest, die van een object Forest is
            ///36 nieuwe bomen. Nu kunnen we doorheen heel onze app forest aanspreken. Stel dat we de squirrelCount willen weten kunnen we dit nu simpelweg
            ///opvragen via forest.SquirrelCount etc.
            forest = new Forest(36);
            //we geven wa tekst weer in een textblock
            tblActions.Text = $"Forest created\n";

            //we roepen onze functie op om onze listboxes te bouwen, overloop die
            ShowForest();
        }

        //we willen de forest weergeven in onze textblock en alle bomen ook vullen in onze andere listbox
        private void ShowForest()
        {
            //we adden hier in de text van onze textblock onze forest. Let wel, forest is toch geen string??
            //De enige reden dat dit werkt is door onze override in onze Forest.cs klasse helemaal onderaan. Dat
            //is het nut van die override, we krijgen nu da mooi lijntje tekst.
            tblActions.Text += forest;

            //we roepen onze functie van hieronder op.
            ShowTrees();
        }

        //we willen de bomen weergeven in onze lijst.
        private void ShowTrees()
        {
            //ctrl click hier eens op .Items. en .Clear()
            //da is exact hetzelfde concept als wat we nu aan het doen zijn. C# zit al vol met voorgemaakte klasses van windows
            //een lijst heeft de property Items en Items heeft een methode daarin zitten die de lijntjes clearen. Wij zouden
            //evengoed heel deze functionaliteit in onze eigen klasses kunnen programmeren, maar ze zijn nu al voorgemaakt dus nice.
            lstForest.Items.Clear();

            //we overlopen elke boom in onze lijst
            foreach (Tree tree in forest.Trees)
            {
                //we voegen onze variabele die we overlopen in de listbox
                lstForest.Items.Add(tree);
            }
        }

        //wanneer we op de knop squirrels duwen:
        private void btnSquirrelsClimb_Click(object sender, RoutedEventArgs e)
        {
            //we voegen tekst toe aan de texblock
            tblActions.Text += "\n\nSquirrels attack!\n";

            //we roepen de ingebouwde functie die we zelf hebben geprogrammeerd in onze Forest.cs file op. 
            //ctrl + click op die SquirrelPlague om die nog eens te lezen.
            forest.SquirrelPlague();

            //we tonen/refreshen opnieuw onze textblock en lijst
            ShowForest();
        }



        //dit is bijna exact hetzelfde als onze squirrelbutton, maar we roepen gewoon een andere methode vanuit onze klasse.
        private void btnLumberjackCuts_Click(object sender, RoutedEventArgs e)
        {
            //we voegen tekst toe aan de texblock
            tblActions.Text += "\n\nLumberjack!\n";

            //we roepen de ingebouwde functie die we zelf hebben geprogrammeerd in onze Forest.cs file op. 
            //ctrl + click op die LumberJackCutsTree om die nog eens te lezen.
            forest.LumberJackCutsTree();

            //we tonen/refreshen opnieuw onze textblock en lijst
            ShowForest();
        }
    }
}