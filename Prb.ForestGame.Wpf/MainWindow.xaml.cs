using System.Windows;
using Prb.ForestGame.Core;


namespace Prb.ForestGame.Wpf
{
    public partial class MainWindow : Window
    {
        Forest forest = new Forest(36);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Tree tree in forest.Trees)
            {
                lstForest.Items.Add(tree);
            }
        }

        private void btnCreateForest_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateForest()
        {
            forest = new Forest(36);
            tblActions.Text = "Forest created\n";
        }

    }
}