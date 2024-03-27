using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Turnierspielplan
{
  /// <summary>
  /// Interaktionslogik für MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private static int gedrückt = 0;

        private List<string> availableTeams = new List<string> { "Barcelona", "Real Madrid", "Bayern Munich", "Paris Saint-Germain", "Atletico Madrid", "Juventus", "Manchester City", "Chelsea" };

        private void btnSimulieren_Click(object sender, RoutedEventArgs e)
        {
            // Increase the button press count
            gedrückt++;

            // Change button content based on press count
            string btnContent = "";
            switch (gedrückt)
            {
                case 1:
                    btnContent = "Wer kommt in den Final?";
                    if (Mannschaft1.SelectedValue != null && Mannschaft2.SelectedValue != null &&
                        Mannschaft3.SelectedValue != null && Mannschaft4.SelectedValue != null &&
                        Mannschaft5.SelectedValue != null && Mannschaft6.SelectedValue != null &&
                        Mannschaft7.SelectedValue != null && Mannschaft8.SelectedValue != null)
                    {
                        SimulateMatch(Mannschaft1.SelectedValue.ToString(), Mannschaft2.SelectedValue.ToString(), lblTore1, lblTore2);
                        SimulateMatch(Mannschaft3.SelectedValue.ToString(), Mannschaft4.SelectedValue.ToString(), lblTore3, lblTore4);
                        SimulateMatch(Mannschaft5.SelectedValue.ToString(), Mannschaft6.SelectedValue.ToString(), lblTore5, lblTore6);
                        SimulateMatch(Mannschaft7.SelectedValue.ToString(), Mannschaft8.SelectedValue.ToString(), lblTore7, lblTore8);
                    }
                    else
                    {
                        // Display an error message
                        MessageBox.Show("Bitte wählen Sie alle Mannschaften aus.", "Fehlende Auswahl", MessageBoxButton.OK, MessageBoxImage.Error);
                        gedrückt--;
                    }
                    break;
                case 2:
                    btnContent = "Wer ist der Sieger?";
                    if (lblErsteGewinner1.Content != null && lblErsteGewinner2.Content != null &&
                        lblErsteGewinner3.Content != null && lblErsteGewinner4.Content != null)
                    {
                        SimulateMatch(lblErsteGewinner1.Content.ToString(), lblErsteGewinner2.Content.ToString(), lblErsteGewinner1Tore, lblErsteGewinner2Tore);
                        SimulateMatch(lblErsteGewinner3.Content.ToString(), lblErsteGewinner4.Content.ToString(), lblErsteGewinner3Tore, lblErsteGewinner4Tore);
                    }
                    else
                    {
                        // Handle the case where not all values are selected
                        // Maybe display an error message or take appropriate action
                    }
                    break;
                case 3:
                    btnContent = "Fertig";
                    if (lblFinal1.Content != null && lblFinal2.Content != null)
                    {
                        SimulateMatch(lblFinal1.Content.ToString(), lblFinal2.Content.ToString(), lblFinal1Tore, lblFinal2Tore);
                    }
                    else
                    {
                        // Handle the case where not all values are selected
                        // Maybe display an error message or take appropriate action
                    }
                    break;
            }

            btnSimulieren.Content = btnContent;
            if (gedrückt == 3)
            {
                DetermineWinner();
            }
        }

        private void SimulateMatch(string team1, string team2, Label lblTeam1Score, Label lblTeam2Score)
        {
            Random rnd = new Random();
            int score1 = rnd.Next(11);
            int score2 = rnd.Next(11);

            if (score1 == score2)
            {
                int equal = rnd.Next(3);
                if (equal == 0 && score1 > 0)
                {
                    score1--;
                }
                else if (equal == 1 && score2 > 0)
                {
                    score2--;
                }
                else if (equal == 2)
                {
                    score1++;
                }
                else
                {
                    score2++;
                }
            }

            lblTeam1Score.Content = score1.ToString();
            lblTeam2Score.Content = score2.ToString();
        }

        private void DetermineWinner()
        {
            string final1 = lblFinal1.Content.ToString();
            string final2 = lblFinal2.Content.ToString();
            int score1 = int.Parse(lblFinal1Tore.Content.ToString());
            int score2 = int.Parse(lblFinal2Tore.Content.ToString());

            if (score1 < score2)
            {
                lblSieger.Content = final2;
            }
            else if (score1 > score2)
            {
                lblSieger.Content = final1;
            }
        }


        public void Mannschaft1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            List<int> mannschaften = new List<int>();
            mannschaften.Add(0);
            mannschaften.Add(1);
            mannschaften.Add(2);
            mannschaften.Add(3);
            mannschaften.Add(4);
            mannschaften.Add(5);
            mannschaften.Add(6);
            mannschaften.Add(7);

            var selectedItem = e.AddedItems[0] as ComboBoxItem;
            var itemStackPanel = selectedItem.Content as StackPanel;

            // Get the TextBlock object from 'itemStackPanel' object
            // TextBlock is with index 1 because it is defined second
            //  after Image inside the StackPanel in your XAML
            var textBlock = itemStackPanel.Children[1] as TextBlock;
            // This variable will hold 'Engineer' or 'Manager'
            var selectedText = textBlock.Text;

            // MessageBox.Show("Ausgewählt: " + selectedText);

            if (selectedText == "Barcelona")
            {
                int index = Mannschaft1.Items.IndexOf("Barcelona");

                Mannschaft2.Items.RemoveAt(Mannschaft1.SelectedIndex);
                Mannschaft3.Items.Remove(selectedText);
                Mannschaft4.Items.Remove(selectedText);
                Mannschaft5.Items.Remove(selectedText);
                Mannschaft6.Items.Remove(selectedText);
                Mannschaft7.Items.Remove(selectedText);
                Mannschaft8.Items.Remove(selectedText);
            }
            else if (selectedText == "Real Madrid")
            {
                Mannschaft2.Items.RemoveAt(mannschaften[1]);
                Mannschaft3.Items.RemoveAt(mannschaften[1]);
                Mannschaft4.Items.RemoveAt(mannschaften[1]);
                Mannschaft5.Items.RemoveAt(mannschaften[1]);
                Mannschaft6.Items.RemoveAt(mannschaften[1]);
                Mannschaft7.Items.RemoveAt(mannschaften[1]);
                Mannschaft8.Items.RemoveAt(mannschaften[1]);
            }
            else if (selectedText == "Bayern Munich")
            {
                Mannschaft2.Items.RemoveAt(mannschaften[2]);
                Mannschaft3.Items.RemoveAt(mannschaften[2]);
                Mannschaft4.Items.RemoveAt(mannschaften[2]);
                Mannschaft5.Items.RemoveAt(mannschaften[2]);
                Mannschaft6.Items.RemoveAt(mannschaften[2]);
                Mannschaft7.Items.RemoveAt(mannschaften[2]);
                Mannschaft8.Items.RemoveAt(mannschaften[2]);
            }
            else if (selectedText == "Paris Saint-Germain")
            {
                Mannschaft2.Items.RemoveAt(mannschaften[3]);
                Mannschaft3.Items.RemoveAt(mannschaften[3]);
                Mannschaft4.Items.RemoveAt(mannschaften[3]);
                Mannschaft5.Items.RemoveAt(mannschaften[3]);
                Mannschaft6.Items.RemoveAt(mannschaften[3]);
                Mannschaft7.Items.RemoveAt(mannschaften[3]);
                Mannschaft8.Items.RemoveAt(mannschaften[3]);
            }
            else if (selectedText == "Atletico Madrid")
            {

            }
            else if (selectedText == "Juventus")
            {

            }
            else if (selectedText == "Manchester City")
            {

            }
            else if (selectedText == "Chelsea")
            {

            }
        }

        private void Mannschaft2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {/*
      var selectedItem = e.AddedItems[0] as ComboBoxItem;
      var itemStackPanel = selectedItem.Content as StackPanel;

      // Get the TextBlock object from 'itemStackPanel' object
      // TextBlock is with index 1 because it is defined second
      //  after Image inside the StackPanel in your XAML
      var textBlock = itemStackPanel.Children[1] as TextBlock;
      // This variable will hold 'Engineer' or 'Manager'
      var selectedText = textBlock.Text;

      MessageBox.Show("Ausgewählt: " + selectedText);*/
            var selectedItem = e.AddedItems[0] as ComboBoxItem;
            var itemStackPanel = selectedItem.Content as StackPanel;
            var Barcelona = 0;
            var Real_Madrid = 1;
            var Bayern_Munich = 2;
            var Paris_St_Germain = 3;
            var Atletico_Madrid = 4;
            var Juventus = 5;
            var Manchester_City = 6;
            var Chelsea = 7;

            // Get the TextBlock object from 'itemStackPanel' object
            // TextBlock is with index 1 because it is defined second
            //  after Image inside the StackPanel in your XAML
            var textBlock = itemStackPanel.Children[1] as TextBlock;
            // This variable will hold 'Engineer' or 'Manager'
            var selectedText = textBlock.Text;

            //MessageBox.Show("Ausgewählt: " + selectedText);

            if (selectedText == "Barcelona")
            {
                Mannschaft1.Items.RemoveAt(Barcelona);
                Mannschaft3.Items.RemoveAt(Barcelona);
                Mannschaft4.Items.RemoveAt(Barcelona);
                Mannschaft5.Items.RemoveAt(Barcelona);
                Mannschaft6.Items.RemoveAt(Barcelona);
                Mannschaft7.Items.RemoveAt(Barcelona);
                Mannschaft8.Items.RemoveAt(Barcelona);
            }
            else if (selectedText == "Real Madrid")
            {
                Mannschaft1.Items.RemoveAt(Real_Madrid);
                Mannschaft3.Items.RemoveAt(Real_Madrid);
                Mannschaft4.Items.RemoveAt(Real_Madrid);
                Mannschaft5.Items.RemoveAt(Real_Madrid);
                Mannschaft6.Items.RemoveAt(Real_Madrid);
                Mannschaft7.Items.RemoveAt(Real_Madrid);
                Mannschaft8.Items.RemoveAt(Real_Madrid);
            }
            else if (selectedText == "Bayern Munich")
            {
                Mannschaft1.Items.RemoveAt(Bayern_Munich);
                Mannschaft3.Items.RemoveAt(Bayern_Munich);
                Mannschaft4.Items.RemoveAt(Bayern_Munich);
                Mannschaft5.Items.RemoveAt(Bayern_Munich);
                Mannschaft6.Items.RemoveAt(Bayern_Munich);
                Mannschaft7.Items.RemoveAt(Bayern_Munich);
                Mannschaft8.Items.RemoveAt(Bayern_Munich);
            }
            else if (selectedText == "Paris Saint-Germain")
            {
                Mannschaft1.Items.RemoveAt(Paris_St_Germain);
                Mannschaft3.Items.RemoveAt(Paris_St_Germain);
                Mannschaft4.Items.RemoveAt(Paris_St_Germain);
                Mannschaft5.Items.RemoveAt(Paris_St_Germain);
                Mannschaft6.Items.RemoveAt(Paris_St_Germain);
                Mannschaft7.Items.RemoveAt(Paris_St_Germain);
                Mannschaft8.Items.RemoveAt(Paris_St_Germain);
            }
            else if (selectedText == "Atletico Madrid")
            {
                Mannschaft1.Items.RemoveAt(Atletico_Madrid);
                Mannschaft3.Items.RemoveAt(Atletico_Madrid);
                Mannschaft4.Items.RemoveAt(Atletico_Madrid);
                Mannschaft5.Items.RemoveAt(Atletico_Madrid);
                Mannschaft6.Items.RemoveAt(Atletico_Madrid);
                Mannschaft7.Items.RemoveAt(Atletico_Madrid);
                Mannschaft8.Items.RemoveAt(Atletico_Madrid);
            }
            else if (selectedText == "Juventus")
            {
                Mannschaft1.Items.RemoveAt(Juventus);
                Mannschaft3.Items.RemoveAt(Juventus);
                Mannschaft4.Items.RemoveAt(Juventus);
                Mannschaft5.Items.RemoveAt(Juventus);
                Mannschaft6.Items.RemoveAt(Juventus);
                Mannschaft7.Items.RemoveAt(Juventus);
                Mannschaft8.Items.RemoveAt(Juventus);
            }
            else if (selectedText == "Manchester City")
            {
                Mannschaft1.Items.RemoveAt(Manchester_City);
                Mannschaft3.Items.RemoveAt(Manchester_City);
                Mannschaft4.Items.RemoveAt(Manchester_City);
                Mannschaft5.Items.RemoveAt(Manchester_City);
                Mannschaft6.Items.RemoveAt(Manchester_City);
                Mannschaft7.Items.RemoveAt(Manchester_City);
                Mannschaft8.Items.RemoveAt(Manchester_City);
            }
            else if (selectedText == "Chelsea")
            {
                Mannschaft1.Items.RemoveAt(Chelsea);
                Mannschaft3.Items.RemoveAt(Chelsea);
                Mannschaft4.Items.RemoveAt(Chelsea);
                Mannschaft5.Items.RemoveAt(Chelsea);
                Mannschaft6.Items.RemoveAt(Chelsea);
                Mannschaft7.Items.RemoveAt(Chelsea);
                Mannschaft8.Items.RemoveAt(Chelsea);
            }
        }

        private void Mannschaft3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {/*
      var selectedItem = e.AddedItems[0] as ComboBoxItem;
      var itemStackPanel = selectedItem.Content as StackPanel;

      // Get the TextBlock object from 'itemStackPanel' object
      // TextBlock is with index 1 because it is defined second
      //  after Image inside the StackPanel in your XAML
      var textBlock = itemStackPanel.Children[1] as TextBlock;
      // This variable will hold 'Engineer' or 'Manager'
      var selectedText = textBlock.Text;

      MessageBox.Show("Ausgewählt: " + selectedText);*/
            var selectedItem = e.AddedItems[0] as ComboBoxItem;
            var itemStackPanel = selectedItem.Content as StackPanel;
            var Barcelona = 0;
            var Real_Madrid = 1;
            var Bayern_Munich = 2;
            var Paris_St_Germain = 3;
            var Atletico_Madrid = 4;
            var Juventus = 5;
            var Manchester_City = 6;
            var Chelsea = 7;

            // Get the TextBlock object from 'itemStackPanel' object
            // TextBlock is with index 1 because it is defined second
            //  after Image inside the StackPanel in your XAML
            var textBlock = itemStackPanel.Children[1] as TextBlock;
            // This variable will hold 'Engineer' or 'Manager'
            var selectedText = textBlock.Text;

            //MessageBox.Show("Ausgewählt: " + selectedText);

            if (selectedText == "Barcelona")
            {
                Mannschaft1.Items.RemoveAt(Barcelona);
                Mannschaft2.Items.RemoveAt(Barcelona);
                Mannschaft4.Items.RemoveAt(Barcelona);
                Mannschaft5.Items.RemoveAt(Barcelona);
                Mannschaft6.Items.RemoveAt(Barcelona);
                Mannschaft7.Items.RemoveAt(Barcelona);
                Mannschaft8.Items.RemoveAt(Barcelona);
            }
            else if (selectedText == "Real Madrid")
            {
                Mannschaft1.Items.RemoveAt(Real_Madrid);
                Mannschaft2.Items.RemoveAt(Real_Madrid);
                Mannschaft4.Items.RemoveAt(Real_Madrid);
                Mannschaft5.Items.RemoveAt(Real_Madrid);
                Mannschaft6.Items.RemoveAt(Real_Madrid);
                Mannschaft7.Items.RemoveAt(Real_Madrid);
                Mannschaft8.Items.RemoveAt(Real_Madrid);
            }
            else if (selectedText == "Bayern Munich")
            {
                Mannschaft1.Items.RemoveAt(Bayern_Munich);
                Mannschaft2.Items.RemoveAt(Bayern_Munich);
                Mannschaft4.Items.RemoveAt(Bayern_Munich);
                Mannschaft5.Items.RemoveAt(Bayern_Munich);
                Mannschaft6.Items.RemoveAt(Bayern_Munich);
                Mannschaft7.Items.RemoveAt(Bayern_Munich);
                Mannschaft8.Items.RemoveAt(Bayern_Munich);
            }
            else if (selectedText == "Paris Saint-Germain")
            {
                Mannschaft1.Items.RemoveAt(Paris_St_Germain);
                Mannschaft2.Items.RemoveAt(Paris_St_Germain);
                Mannschaft4.Items.RemoveAt(Paris_St_Germain);
                Mannschaft5.Items.RemoveAt(Paris_St_Germain);
                Mannschaft6.Items.RemoveAt(Paris_St_Germain);
                Mannschaft7.Items.RemoveAt(Paris_St_Germain);
                Mannschaft8.Items.RemoveAt(Paris_St_Germain);
            }
            else if (selectedText == "Atletico Madrid")
            {
                Mannschaft1.Items.RemoveAt(Atletico_Madrid);
                Mannschaft2.Items.RemoveAt(Atletico_Madrid);
                Mannschaft4.Items.RemoveAt(Atletico_Madrid);
                Mannschaft5.Items.RemoveAt(Atletico_Madrid);
                Mannschaft6.Items.RemoveAt(Atletico_Madrid);
                Mannschaft7.Items.RemoveAt(Atletico_Madrid);
                Mannschaft8.Items.RemoveAt(Atletico_Madrid);
            }
            else if (selectedText == "Juventus")
            {
                Mannschaft1.Items.RemoveAt(Juventus);
                Mannschaft2.Items.RemoveAt(Juventus);
                Mannschaft4.Items.RemoveAt(Juventus);
                Mannschaft5.Items.RemoveAt(Juventus);
                Mannschaft6.Items.RemoveAt(Juventus);
                Mannschaft7.Items.RemoveAt(Juventus);
                Mannschaft8.Items.RemoveAt(Juventus);
            }
            else if (selectedText == "Manchester City")
            {
                Mannschaft1.Items.RemoveAt(Manchester_City);
                Mannschaft2.Items.RemoveAt(Manchester_City);
                Mannschaft4.Items.RemoveAt(Manchester_City);
                Mannschaft5.Items.RemoveAt(Manchester_City);
                Mannschaft6.Items.RemoveAt(Manchester_City);
                Mannschaft7.Items.RemoveAt(Manchester_City);
                Mannschaft8.Items.RemoveAt(Manchester_City);
            }
            else if (selectedText == "Chelsea")
            {
                Mannschaft1.Items.RemoveAt(Chelsea);
                Mannschaft2.Items.RemoveAt(Chelsea);
                Mannschaft4.Items.RemoveAt(Chelsea);
                Mannschaft5.Items.RemoveAt(Chelsea);
                Mannschaft6.Items.RemoveAt(Chelsea);
                Mannschaft7.Items.RemoveAt(Chelsea);
                Mannschaft8.Items.RemoveAt(Chelsea);
            }
        }

        private void Mannschaft4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {/*
      var selectedItem = e.AddedItems[0] as ComboBoxItem;
      var itemStackPanel = selectedItem.Content as StackPanel;

      // Get the TextBlock object from 'itemStackPanel' object
      // TextBlock is with index 1 because it is defined second
      //  after Image inside the StackPanel in your XAML
      var textBlock = itemStackPanel.Children[1] as TextBlock;
      // This variable will hold 'Engineer' or 'Manager'
      var selectedText = textBlock.Text;

      MessageBox.Show("Ausgewählt: " + selectedText);*/
            var selectedItem = e.AddedItems[0] as ComboBoxItem;
            var itemStackPanel = selectedItem.Content as StackPanel;
            var Barcelona = 0;
            var Real_Madrid = 1;
            var Bayern_Munich = 2;
            var Paris_St_Germain = 3;
            var Atletico_Madrid = 4;
            var Juventus = 5;
            var Manchester_City = 6;
            var Chelsea = 7;

            // Get the TextBlock object from 'itemStackPanel' object
            // TextBlock is with index 1 because it is defined second
            //  after Image inside the StackPanel in your XAML
            var textBlock = itemStackPanel.Children[1] as TextBlock;
            // This variable will hold 'Engineer' or 'Manager'
            var selectedText = textBlock.Text;

            //MessageBox.Show("Ausgewählt: " + selectedText);

            if (selectedText == "Barcelona")
            {
                Mannschaft1.Items.RemoveAt(Barcelona);
                Mannschaft2.Items.RemoveAt(Barcelona);
                Mannschaft3.Items.RemoveAt(Barcelona);
                Mannschaft5.Items.RemoveAt(Barcelona);
                Mannschaft6.Items.RemoveAt(Barcelona);
                Mannschaft7.Items.RemoveAt(Barcelona);
                Mannschaft8.Items.RemoveAt(Barcelona);
            }
            else if (selectedText == "Real Madrid")
            {
                Mannschaft1.Items.RemoveAt(Real_Madrid);
                Mannschaft2.Items.RemoveAt(Real_Madrid);
                Mannschaft3.Items.RemoveAt(Real_Madrid);
                Mannschaft5.Items.RemoveAt(Real_Madrid);
                Mannschaft6.Items.RemoveAt(Real_Madrid);
                Mannschaft7.Items.RemoveAt(Real_Madrid);
                Mannschaft8.Items.RemoveAt(Real_Madrid);
            }
            else if (selectedText == "Bayern Munich")
            {
                Mannschaft1.Items.RemoveAt(Bayern_Munich);
                Mannschaft2.Items.RemoveAt(Bayern_Munich);
                Mannschaft3.Items.RemoveAt(Bayern_Munich);
                Mannschaft5.Items.RemoveAt(Bayern_Munich);
                Mannschaft6.Items.RemoveAt(Bayern_Munich);
                Mannschaft7.Items.RemoveAt(Bayern_Munich);
                Mannschaft8.Items.RemoveAt(Bayern_Munich);
            }
            else if (selectedText == "Paris Saint-Germain")
            {
                Mannschaft1.Items.RemoveAt(Paris_St_Germain);
                Mannschaft2.Items.RemoveAt(Paris_St_Germain);
                Mannschaft3.Items.RemoveAt(Paris_St_Germain);
                Mannschaft5.Items.RemoveAt(Paris_St_Germain);
                Mannschaft6.Items.RemoveAt(Paris_St_Germain);
                Mannschaft7.Items.RemoveAt(Paris_St_Germain);
                Mannschaft8.Items.RemoveAt(Paris_St_Germain);
            }
            else if (selectedText == "Atletico Madrid")
            {
                Mannschaft1.Items.RemoveAt(Atletico_Madrid);
                Mannschaft2.Items.RemoveAt(Atletico_Madrid);
                Mannschaft3.Items.RemoveAt(Atletico_Madrid);
                Mannschaft5.Items.RemoveAt(Atletico_Madrid);
                Mannschaft6.Items.RemoveAt(Atletico_Madrid);
                Mannschaft7.Items.RemoveAt(Atletico_Madrid);
                Mannschaft8.Items.RemoveAt(Atletico_Madrid);
            }
            else if (selectedText == "Juventus")
            {
                Mannschaft1.Items.RemoveAt(Juventus);
                Mannschaft2.Items.RemoveAt(Juventus);
                Mannschaft3.Items.RemoveAt(Juventus);
                Mannschaft5.Items.RemoveAt(Juventus);
                Mannschaft6.Items.RemoveAt(Juventus);
                Mannschaft7.Items.RemoveAt(Juventus);
                Mannschaft8.Items.RemoveAt(Juventus);
            }
            else if (selectedText == "Manchester City")
            {
                Mannschaft1.Items.RemoveAt(Manchester_City);
                Mannschaft2.Items.RemoveAt(Manchester_City);
                Mannschaft3.Items.RemoveAt(Manchester_City);
                Mannschaft5.Items.RemoveAt(Manchester_City);
                Mannschaft6.Items.RemoveAt(Manchester_City);
                Mannschaft7.Items.RemoveAt(Manchester_City);
                Mannschaft8.Items.RemoveAt(Manchester_City);
            }
            else if (selectedText == "Chelsea")
            {
                Mannschaft1.Items.RemoveAt(Chelsea);
                Mannschaft2.Items.RemoveAt(Chelsea);
                Mannschaft3.Items.RemoveAt(Chelsea);
                Mannschaft5.Items.RemoveAt(Chelsea);
                Mannschaft6.Items.RemoveAt(Chelsea);
                Mannschaft7.Items.RemoveAt(Chelsea);
                Mannschaft8.Items.RemoveAt(Chelsea);
            }
        }

        private void Mannschaft5_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {/*
      var selectedItem = e.AddedItems[0] as ComboBoxItem;
      var itemStackPanel = selectedItem.Content as StackPanel;

      // Get the TextBlock object from 'itemStackPanel' object
      // TextBlock is with index 1 because it is defined second
      //  after Image inside the StackPanel in your XAML
      var textBlock = itemStackPanel.Children[1] as TextBlock;
      // This variable will hold 'Engineer' or 'Manager'
      var selectedText = textBlock.Text;

      MessageBox.Show("Ausgewählt: " + selectedText);*/
            var selectedItem = e.AddedItems[0] as ComboBoxItem;
            var itemStackPanel = selectedItem.Content as StackPanel;
            var Barcelona = 0;
            var Real_Madrid = 1;
            var Bayern_Munich = 2;
            var Paris_St_Germain = 3;
            var Atletico_Madrid = 4;
            var Juventus = 5;
            var Manchester_City = 6;
            var Chelsea = 7;

            // Get the TextBlock object from 'itemStackPanel' object
            // TextBlock is with index 1 because it is defined second
            //  after Image inside the StackPanel in your XAML
            var textBlock = itemStackPanel.Children[1] as TextBlock;
            // This variable will hold 'Engineer' or 'Manager'
            var selectedText = textBlock.Text;

            //MessageBox.Show("Ausgewählt: " + selectedText);

            if (selectedText == "Barcelona")
            {
                Mannschaft1.Items.RemoveAt(Barcelona);
                Mannschaft2.Items.RemoveAt(Barcelona);
                Mannschaft3.Items.RemoveAt(Barcelona);
                Mannschaft4.Items.RemoveAt(Barcelona);
                Mannschaft6.Items.RemoveAt(Barcelona);
                Mannschaft7.Items.RemoveAt(Barcelona);
                Mannschaft8.Items.RemoveAt(Barcelona);

                Real_Madrid = 0;
                Bayern_Munich = 1;
                Paris_St_Germain = 2;
                Atletico_Madrid = 3;
                Juventus = 4;
                Manchester_City = 5;
                Chelsea = 6;
            }
            else if (selectedText == "Real Madrid")
            {
                Mannschaft1.Items.RemoveAt(Real_Madrid);
                Mannschaft2.Items.RemoveAt(Real_Madrid);
                Mannschaft3.Items.RemoveAt(Real_Madrid);
                Mannschaft4.Items.RemoveAt(Real_Madrid);
                Mannschaft6.Items.RemoveAt(Real_Madrid);
                Mannschaft7.Items.RemoveAt(Real_Madrid);
                Mannschaft8.Items.RemoveAt(Real_Madrid);

                Barcelona = 0;
                Bayern_Munich = 1;
                Paris_St_Germain = 2;
                Atletico_Madrid = 3;
                Juventus = 4;
                Manchester_City = 5;
                Chelsea = 6;
            }
            else if (selectedText == "Bayern Munich")
            {
                Mannschaft1.Items.RemoveAt(Bayern_Munich);
                Mannschaft2.Items.RemoveAt(Bayern_Munich);
                Mannschaft3.Items.RemoveAt(Bayern_Munich);
                Mannschaft4.Items.RemoveAt(Bayern_Munich);
                Mannschaft6.Items.RemoveAt(Bayern_Munich);
                Mannschaft7.Items.RemoveAt(Bayern_Munich);
                Mannschaft8.Items.RemoveAt(Bayern_Munich);

                Barcelona = 0;
                Real_Madrid = 1;
                Paris_St_Germain = 2;
                Atletico_Madrid = 3;
                Juventus = 4;
                Manchester_City = 5;
                Chelsea = 6;
            }
            else if (selectedText == "Paris Saint-Germain")
            {
                Mannschaft1.Items.RemoveAt(Paris_St_Germain);
                Mannschaft2.Items.RemoveAt(Paris_St_Germain);
                Mannschaft3.Items.RemoveAt(Paris_St_Germain);
                Mannschaft4.Items.RemoveAt(Paris_St_Germain);
                Mannschaft6.Items.RemoveAt(Paris_St_Germain);
                Mannschaft7.Items.RemoveAt(Paris_St_Germain);
                Mannschaft8.Items.RemoveAt(Paris_St_Germain);

                Barcelona = 0;
                Real_Madrid = 1;
                Bayern_Munich = 2;
                Atletico_Madrid = 3;
                Juventus = 4;
                Manchester_City = 5;
                Chelsea = 6;
            }
            else if (selectedText == "Atletico Madrid")
            {
                Mannschaft1.Items.RemoveAt(Atletico_Madrid);
                Mannschaft2.Items.RemoveAt(Atletico_Madrid);
                Mannschaft3.Items.RemoveAt(Atletico_Madrid);
                Mannschaft4.Items.RemoveAt(Atletico_Madrid);
                Mannschaft6.Items.RemoveAt(Atletico_Madrid);
                Mannschaft7.Items.RemoveAt(Atletico_Madrid);
                Mannschaft8.Items.RemoveAt(Atletico_Madrid);

                Barcelona = 0;
                Real_Madrid = 1;
                Bayern_Munich = 2;
                Paris_St_Germain = 3;
                Juventus = 4;
                Manchester_City = 5;
                Chelsea = 6;
            }
            else if (selectedText == "Juventus")
            {
                Mannschaft1.Items.RemoveAt(Juventus);
                Mannschaft2.Items.RemoveAt(Juventus);
                Mannschaft3.Items.RemoveAt(Juventus);
                Mannschaft4.Items.RemoveAt(Juventus);
                Mannschaft6.Items.RemoveAt(Juventus);
                Mannschaft7.Items.RemoveAt(Juventus);
                Mannschaft8.Items.RemoveAt(Juventus);

                Barcelona = 0;
                Real_Madrid = 1;
                Bayern_Munich = 2;
                Paris_St_Germain = 3;
                Atletico_Madrid = 4;
                Manchester_City = 5;
                Chelsea = 6;
            }
            else if (selectedText == "Manchester City")
            {
                Mannschaft1.Items.RemoveAt(Manchester_City);
                Mannschaft2.Items.RemoveAt(Manchester_City);
                Mannschaft3.Items.RemoveAt(Manchester_City);
                Mannschaft4.Items.RemoveAt(Manchester_City);
                Mannschaft6.Items.RemoveAt(Manchester_City);
                Mannschaft7.Items.RemoveAt(Manchester_City);
                Mannschaft8.Items.RemoveAt(Manchester_City);

                Barcelona = 0;
                Real_Madrid = 1;
                Bayern_Munich = 2;
                Paris_St_Germain = 3;
                Atletico_Madrid = 4;
                Juventus = 5;
                Chelsea = 6;
            }
            else if (selectedText == "Chelsea")
            {
                Mannschaft1.Items.RemoveAt(Chelsea);
                Mannschaft2.Items.RemoveAt(Chelsea);
                Mannschaft3.Items.RemoveAt(Chelsea);
                Mannschaft4.Items.RemoveAt(Chelsea);
                Mannschaft6.Items.RemoveAt(Chelsea);
                Mannschaft7.Items.RemoveAt(Chelsea);
                Mannschaft8.Items.RemoveAt(Chelsea);

                Barcelona = 0;
                Real_Madrid = 1;
                Bayern_Munich = 2;
                Paris_St_Germain = 3;
                Atletico_Madrid = 4;
                Juventus = 5;
                Manchester_City = 6;
            }
        }

        private void Mannschaft6_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {/*
      var selectedItem = e.AddedItems[0] as ComboBoxItem;
      var itemStackPanel = selectedItem.Content as StackPanel;

      // Get the TextBlock object from 'itemStackPanel' object
      // TextBlock is with index 1 because it is defined second
      //  after Image inside the StackPanel in your XAML
      var textBlock = itemStackPanel.Children[1] as TextBlock;
      // This variable will hold 'Engineer' or 'Manager'
      var selectedText = textBlock.Text;

      MessageBox.Show("Ausgewählt: " + selectedText);*/
            var selectedItem = e.AddedItems[0] as ComboBoxItem;
            var itemStackPanel = selectedItem.Content as StackPanel;
            var Barcelona = 0;
            var Real_Madrid = 1;
            var Bayern_Munich = 2;
            var Paris_St_Germain = 3;
            var Atletico_Madrid = 4;
            var Juventus = 5;
            var Manchester_City = 6;
            var Chelsea = 7;

            // Get the TextBlock object from 'itemStackPanel' object
            // TextBlock is with index 1 because it is defined second
            //  after Image inside the StackPanel in your XAML
            var textBlock = itemStackPanel.Children[1] as TextBlock;
            // This variable will hold 'Engineer' or 'Manager'
            var selectedText = textBlock.Text;

            //MessageBox.Show("Ausgewählt: " + selectedText);

            if (selectedText == "Barcelona")
            {
                Mannschaft1.Items.RemoveAt(Barcelona);
                Mannschaft2.Items.RemoveAt(Barcelona);
                Mannschaft3.Items.RemoveAt(Barcelona);
                Mannschaft4.Items.RemoveAt(Barcelona);
                Mannschaft5.Items.RemoveAt(Barcelona);
                Mannschaft7.Items.RemoveAt(Barcelona);
                Mannschaft8.Items.RemoveAt(Barcelona);

                Real_Madrid = 0;
                Bayern_Munich = 1;
                Paris_St_Germain = 2;
                Atletico_Madrid = 3;
                Juventus = 4;
                Manchester_City = 5;
                Chelsea = 6;
            }
            else if (selectedText == "Real Madrid")
            {
                Mannschaft1.Items.RemoveAt(Real_Madrid);
                Mannschaft2.Items.RemoveAt(Real_Madrid);
                Mannschaft3.Items.RemoveAt(Real_Madrid);
                Mannschaft4.Items.RemoveAt(Real_Madrid);
                Mannschaft5.Items.RemoveAt(Real_Madrid);
                Mannschaft7.Items.RemoveAt(Real_Madrid);
                Mannschaft8.Items.RemoveAt(Real_Madrid);

                Barcelona = 0;
                Bayern_Munich = 1;
                Paris_St_Germain = 2;
                Atletico_Madrid = 3;
                Juventus = 4;
                Manchester_City = 5;
                Chelsea = 6;
            }
            else if (selectedText == "Bayern Munich")
            {
                Mannschaft1.Items.RemoveAt(Bayern_Munich);
                Mannschaft2.Items.RemoveAt(Bayern_Munich);
                Mannschaft3.Items.RemoveAt(Bayern_Munich);
                Mannschaft4.Items.RemoveAt(Bayern_Munich);
                Mannschaft5.Items.RemoveAt(Bayern_Munich);
                Mannschaft7.Items.RemoveAt(Bayern_Munich);
                Mannschaft8.Items.RemoveAt(Bayern_Munich);

                Barcelona = 0;
                Real_Madrid = 1;
                Paris_St_Germain = 2;
                Atletico_Madrid = 3;
                Juventus = 4;
                Manchester_City = 5;
                Chelsea = 6;
            }
            else if (selectedText == "Paris Saint-Germain")
            {
                Mannschaft1.Items.RemoveAt(Paris_St_Germain);
                Mannschaft2.Items.RemoveAt(Paris_St_Germain);
                Mannschaft3.Items.RemoveAt(Paris_St_Germain);
                Mannschaft4.Items.RemoveAt(Paris_St_Germain);
                Mannschaft5.Items.RemoveAt(Paris_St_Germain);
                Mannschaft7.Items.RemoveAt(Paris_St_Germain);
                Mannschaft8.Items.RemoveAt(Paris_St_Germain);

                Barcelona = 0;
                Real_Madrid = 1;
                Bayern_Munich = 2;
                Atletico_Madrid = 3;
                Juventus = 4;
                Manchester_City = 5;
                Chelsea = 6;
            }
            else if (selectedText == "Atletico Madrid")
            {
                Mannschaft1.Items.RemoveAt(Atletico_Madrid);
                Mannschaft2.Items.RemoveAt(Atletico_Madrid);
                Mannschaft3.Items.RemoveAt(Atletico_Madrid);
                Mannschaft4.Items.RemoveAt(Atletico_Madrid);
                Mannschaft5.Items.RemoveAt(Atletico_Madrid);
                Mannschaft7.Items.RemoveAt(Atletico_Madrid);
                Mannschaft8.Items.RemoveAt(Atletico_Madrid);

                Barcelona = 0;
                Real_Madrid = 1;
                Bayern_Munich = 2;
                Paris_St_Germain = 3;
                Juventus = 4;
                Manchester_City = 5;
                Chelsea = 6;
            }
            else if (selectedText == "Juventus")
            {
                Mannschaft1.Items.RemoveAt(Juventus);
                Mannschaft2.Items.RemoveAt(Juventus);
                Mannschaft3.Items.RemoveAt(Juventus);
                Mannschaft4.Items.RemoveAt(Juventus);
                Mannschaft5.Items.RemoveAt(Juventus);
                Mannschaft7.Items.RemoveAt(Juventus);
                Mannschaft8.Items.RemoveAt(Juventus);

                Barcelona = 0;
                Real_Madrid = 1;
                Bayern_Munich = 2;
                Paris_St_Germain = 3;
                Atletico_Madrid = 4;
                Manchester_City = 5;
                Chelsea = 6;
            }
            else if (selectedText == "Manchester City")
            {
                Mannschaft1.Items.RemoveAt(Manchester_City);
                Mannschaft2.Items.RemoveAt(Manchester_City);
                Mannschaft3.Items.RemoveAt(Manchester_City);
                Mannschaft4.Items.RemoveAt(Manchester_City);
                Mannschaft5.Items.RemoveAt(Manchester_City);
                Mannschaft7.Items.RemoveAt(Manchester_City);
                Mannschaft8.Items.RemoveAt(Manchester_City);

                Barcelona = 0;
                Real_Madrid = 1;
                Bayern_Munich = 2;
                Paris_St_Germain = 3;
                Atletico_Madrid = 4;
                Juventus = 5;
                Chelsea = 6;
            }
            else if (selectedText == "Chelsea")
            {
                Mannschaft1.Items.RemoveAt(Chelsea);
                Mannschaft2.Items.RemoveAt(Chelsea);
                Mannschaft3.Items.RemoveAt(Chelsea);
                Mannschaft4.Items.RemoveAt(Chelsea);
                Mannschaft5.Items.RemoveAt(Chelsea);
                Mannschaft7.Items.RemoveAt(Chelsea);
                Mannschaft8.Items.RemoveAt(Chelsea);

                Barcelona = 0;
                Real_Madrid = 1;
                Bayern_Munich = 2;
                Paris_St_Germain = 3;
                Atletico_Madrid = 4;
                Juventus = 5;
                Manchester_City = 6;
            }
        }

        private void Mannschaft7_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {/*
      var selectedItem = e.AddedItems[0] as ComboBoxItem;
      var itemStackPanel = selectedItem.Content as StackPanel;

      // Get the TextBlock object from 'itemStackPanel' object
      // TextBlock is with index 1 because it is defined second
      //  after Image inside the StackPanel in your XAML
      var textBlock = itemStackPanel.Children[1] as TextBlock;
      // This variable will hold 'Engineer' or 'Manager'
      var selectedText = textBlock.Text;

      MessageBox.Show("Ausgewählt: " + selectedText);*/
            var selectedItem = e.AddedItems[0] as ComboBoxItem;
            var itemStackPanel = selectedItem.Content as StackPanel;
            var Barcelona = 0;
            var Real_Madrid = 1;
            var Bayern_Munich = 2;
            var Paris_St_Germain = 3;
            var Atletico_Madrid = 4;
            var Juventus = 5;
            var Manchester_City = 6;
            var Chelsea = 7;

            // Get the TextBlock object from 'itemStackPanel' object
            // TextBlock is with index 1 because it is defined second
            //  after Image inside the StackPanel in your XAML
            var textBlock = itemStackPanel.Children[1] as TextBlock;
            // This variable will hold 'Engineer' or 'Manager'
            var selectedText = textBlock.Text;

            //MessageBox.Show("Ausgewählt: " + selectedText);

            if (selectedText == "Barcelona")
            {
                Mannschaft1.Items.RemoveAt(Barcelona);
                Mannschaft2.Items.RemoveAt(Barcelona);
                Mannschaft3.Items.RemoveAt(Barcelona);
                Mannschaft4.Items.RemoveAt(Barcelona);
                Mannschaft5.Items.RemoveAt(Barcelona);
                Mannschaft6.Items.RemoveAt(Barcelona);
                Mannschaft8.Items.RemoveAt(Barcelona);

                Real_Madrid = 0;
                Bayern_Munich = 1;
                Paris_St_Germain = 2;
                Atletico_Madrid = 3;
                Juventus = 4;
                Manchester_City = 5;
                Chelsea = 6;
            }
            else if (selectedText == "Real Madrid")
            {
                Mannschaft1.Items.RemoveAt(Real_Madrid);
                Mannschaft2.Items.RemoveAt(Real_Madrid);
                Mannschaft3.Items.RemoveAt(Real_Madrid);
                Mannschaft4.Items.RemoveAt(Real_Madrid);
                Mannschaft5.Items.RemoveAt(Real_Madrid);
                Mannschaft6.Items.RemoveAt(Real_Madrid);
                Mannschaft8.Items.RemoveAt(Real_Madrid);

                Barcelona = 0;
                Bayern_Munich = 1;
                Paris_St_Germain = 2;
                Atletico_Madrid = 3;
                Juventus = 4;
                Manchester_City = 5;
                Chelsea = 6;
            }
            else if (selectedText == "Bayern Munich")
            {
                Mannschaft1.Items.RemoveAt(Bayern_Munich);
                Mannschaft2.Items.RemoveAt(Bayern_Munich);
                Mannschaft3.Items.RemoveAt(Bayern_Munich);
                Mannschaft4.Items.RemoveAt(Bayern_Munich);
                Mannschaft5.Items.RemoveAt(Bayern_Munich);
                Mannschaft6.Items.RemoveAt(Bayern_Munich);
                Mannschaft8.Items.RemoveAt(Bayern_Munich);

                Barcelona = 0;
                Real_Madrid = 1;
                Paris_St_Germain = 2;
                Atletico_Madrid = 3;
                Juventus = 4;
                Manchester_City = 5;
                Chelsea = 6;
            }
            else if (selectedText == "Paris Saint-Germain")
            {
                Mannschaft1.Items.RemoveAt(Paris_St_Germain);
                Mannschaft2.Items.RemoveAt(Paris_St_Germain);
                Mannschaft3.Items.RemoveAt(Paris_St_Germain);
                Mannschaft4.Items.RemoveAt(Paris_St_Germain);
                Mannschaft5.Items.RemoveAt(Paris_St_Germain);
                Mannschaft6.Items.RemoveAt(Paris_St_Germain);
                Mannschaft8.Items.RemoveAt(Paris_St_Germain);

                Barcelona = 0;
                Real_Madrid = 1;
                Bayern_Munich = 2;
                Atletico_Madrid = 3;
                Juventus = 4;
                Manchester_City = 5;
                Chelsea = 6;
            }
            else if (selectedText == "Atletico Madrid")
            {
                Mannschaft1.Items.RemoveAt(Atletico_Madrid);
                Mannschaft2.Items.RemoveAt(Atletico_Madrid);
                Mannschaft3.Items.RemoveAt(Atletico_Madrid);
                Mannschaft4.Items.RemoveAt(Atletico_Madrid);
                Mannschaft5.Items.RemoveAt(Atletico_Madrid);
                Mannschaft6.Items.RemoveAt(Atletico_Madrid);
                Mannschaft8.Items.RemoveAt(Atletico_Madrid);

                Barcelona = 0;
                Real_Madrid = 1;
                Bayern_Munich = 2;
                Paris_St_Germain = 3;
                Juventus = 4;
                Manchester_City = 5;
                Chelsea = 6;
            }
            else if (selectedText == "Juventus")
            {
                Mannschaft1.Items.RemoveAt(Juventus);
                Mannschaft2.Items.RemoveAt(Juventus);
                Mannschaft3.Items.RemoveAt(Juventus);
                Mannschaft4.Items.RemoveAt(Juventus);
                Mannschaft5.Items.RemoveAt(Juventus);
                Mannschaft6.Items.RemoveAt(Juventus);
                Mannschaft8.Items.RemoveAt(Juventus);

                Barcelona = 0;
                Real_Madrid = 1;
                Bayern_Munich = 2;
                Paris_St_Germain = 3;
                Atletico_Madrid = 4;
                Manchester_City = 5;
                Chelsea = 6;
            }
            else if (selectedText == "Manchester City")
            {
                Mannschaft1.Items.RemoveAt(Manchester_City);
                Mannschaft2.Items.RemoveAt(Manchester_City);
                Mannschaft3.Items.RemoveAt(Manchester_City);
                Mannschaft4.Items.RemoveAt(Manchester_City);
                Mannschaft5.Items.RemoveAt(Manchester_City);
                Mannschaft6.Items.RemoveAt(Manchester_City);
                Mannschaft8.Items.RemoveAt(Manchester_City);

                Barcelona = 0;
                Real_Madrid = 1;
                Bayern_Munich = 2;
                Paris_St_Germain = 3;
                Atletico_Madrid = 4;
                Juventus = 5;
                Chelsea = 6;
            }
            else if (selectedText == "Chelsea")
            {
                Mannschaft1.Items.RemoveAt(Chelsea);
                Mannschaft2.Items.RemoveAt(Chelsea);
                Mannschaft3.Items.RemoveAt(Chelsea);
                Mannschaft4.Items.RemoveAt(Chelsea);
                Mannschaft5.Items.RemoveAt(Chelsea);
                Mannschaft6.Items.RemoveAt(Chelsea);
                Mannschaft8.Items.RemoveAt(Chelsea);

                Barcelona = 0;
                Real_Madrid = 1;
                Bayern_Munich = 2;
                Paris_St_Germain = 3;
                Atletico_Madrid = 4;
                Juventus = 5;
                Manchester_City = 6;
            }
        }

        private void Mannschaft8_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {/*
      var selectedItem = e.AddedItems[0] as ComboBoxItem;
      var itemStackPanel = selectedItem.Content as StackPanel;

      // Get the TextBlock object from 'itemStackPanel' object
      // TextBlock is with index 1 because it is defined second
      //  after Image inside the StackPanel in your XAML
      var textBlock = itemStackPanel.Children[1] as TextBlock;
      // This variable will hold 'Engineer' or 'Manager'
      var selectedText = textBlock.Text;

      MessageBox.Show("Ausgewählt: " + selectedText);*/
            var selectedItem = e.AddedItems[0] as ComboBoxItem;
            var itemStackPanel = selectedItem.Content as StackPanel;
            var Barcelona = 0;
            var Real_Madrid = 1;
            var Bayern_Munich = 2;
            var Paris_St_Germain = 3;
            var Atletico_Madrid = 4;
            var Juventus = 5;
            var Manchester_City = 6;
            var Chelsea = 7;

            // Get the TextBlock object from 'itemStackPanel' object
            // TextBlock is with index 1 because it is defined second
            //  after Image inside the StackPanel in your XAML
            var textBlock = itemStackPanel.Children[1] as TextBlock;
            // This variable will hold 'Engineer' or 'Manager'
            var selectedText = textBlock.Text;

            //MessageBox.Show("Ausgewählt: " + selectedText);

            if (selectedText == "Barcelona")
            {
                Mannschaft1.Items.RemoveAt(Barcelona);
                Mannschaft2.Items.RemoveAt(Barcelona);
                Mannschaft3.Items.RemoveAt(Barcelona);
                Mannschaft4.Items.RemoveAt(Barcelona);
                Mannschaft5.Items.RemoveAt(Barcelona);
                Mannschaft6.Items.RemoveAt(Barcelona);
                Mannschaft7.Items.RemoveAt(Barcelona);

                Real_Madrid = 0;
                Bayern_Munich = 1;
                Paris_St_Germain = 2;
                Atletico_Madrid = 3;
                Juventus = 4;
                Manchester_City = 5;
                Chelsea = 6;
            }
            else if (selectedText == "Real Madrid")
            {
                Mannschaft1.Items.RemoveAt(Real_Madrid);
                Mannschaft2.Items.RemoveAt(Real_Madrid);
                Mannschaft3.Items.RemoveAt(Real_Madrid);
                Mannschaft4.Items.RemoveAt(Real_Madrid);
                Mannschaft5.Items.RemoveAt(Real_Madrid);
                Mannschaft6.Items.RemoveAt(Real_Madrid);
                Mannschaft7.Items.RemoveAt(Real_Madrid);

                Barcelona = 0;
                Bayern_Munich = 1;
                Paris_St_Germain = 2;
                Atletico_Madrid = 3;
                Juventus = 4;
                Manchester_City = 5;
                Chelsea = 6;
            }
            else if (selectedText == "Bayern Munich")
            {
                Mannschaft1.Items.RemoveAt(Bayern_Munich);
                Mannschaft2.Items.RemoveAt(Bayern_Munich);
                Mannschaft3.Items.RemoveAt(Bayern_Munich);
                Mannschaft4.Items.RemoveAt(Bayern_Munich);
                Mannschaft5.Items.RemoveAt(Bayern_Munich);
                Mannschaft6.Items.RemoveAt(Bayern_Munich);
                Mannschaft7.Items.RemoveAt(Bayern_Munich);

                Barcelona = 0;
                Real_Madrid = 1;
                Paris_St_Germain = 2;
                Atletico_Madrid = 3;
                Juventus = 4;
                Manchester_City = 5;
                Chelsea = 6;
            }
            else if (selectedText == "Paris Saint-Germain")
            {
                Mannschaft1.Items.RemoveAt(Paris_St_Germain);
                Mannschaft2.Items.RemoveAt(Paris_St_Germain);
                Mannschaft3.Items.RemoveAt(Paris_St_Germain);
                Mannschaft4.Items.RemoveAt(Paris_St_Germain);
                Mannschaft5.Items.RemoveAt(Paris_St_Germain);
                Mannschaft6.Items.RemoveAt(Paris_St_Germain);
                Mannschaft7.Items.RemoveAt(Paris_St_Germain);

                Barcelona = 0;
                Real_Madrid = 1;
                Bayern_Munich = 2;
                Atletico_Madrid = 3;
                Juventus = 4;
                Manchester_City = 5;
                Chelsea = 6;
            }
            else if (selectedText == "Atletico Madrid")
            {
                Mannschaft1.Items.RemoveAt(Atletico_Madrid);
                Mannschaft2.Items.RemoveAt(Atletico_Madrid);
                Mannschaft3.Items.RemoveAt(Atletico_Madrid);
                Mannschaft4.Items.RemoveAt(Atletico_Madrid);
                Mannschaft5.Items.RemoveAt(Atletico_Madrid);
                Mannschaft6.Items.RemoveAt(Atletico_Madrid);
                Mannschaft7.Items.RemoveAt(Atletico_Madrid);

                Barcelona = 0;
                Real_Madrid = 1;
                Bayern_Munich = 2;
                Paris_St_Germain = 3;
                Juventus = 4;
                Manchester_City = 5;
                Chelsea = 6;
            }
            else if (selectedText == "Juventus")
            {
                Mannschaft1.Items.RemoveAt(Juventus);
                Mannschaft2.Items.RemoveAt(Juventus);
                Mannschaft3.Items.RemoveAt(Juventus);
                Mannschaft4.Items.RemoveAt(Juventus);
                Mannschaft5.Items.RemoveAt(Juventus);
                Mannschaft6.Items.RemoveAt(Juventus);
                Mannschaft7.Items.RemoveAt(Juventus);

                Barcelona = 0;
                Real_Madrid = 1;
                Bayern_Munich = 2;
                Paris_St_Germain = 3;
                Atletico_Madrid = 4;
                Manchester_City = 5;
                Chelsea = 6;
            }
            else if (selectedText == "Manchester City")
            {
                Mannschaft1.Items.RemoveAt(Manchester_City);
                Mannschaft2.Items.RemoveAt(Manchester_City);
                Mannschaft3.Items.RemoveAt(Manchester_City);
                Mannschaft4.Items.RemoveAt(Manchester_City);
                Mannschaft5.Items.RemoveAt(Manchester_City);
                Mannschaft6.Items.RemoveAt(Manchester_City);
                Mannschaft7.Items.RemoveAt(Manchester_City);

                Barcelona = 0;
                Real_Madrid = 1;
                Bayern_Munich = 2;
                Paris_St_Germain = 3;
                Atletico_Madrid = 4;
                Juventus = 5;
                Chelsea = 6;
            }
            else if (selectedText == "Chelsea")
            {
                Mannschaft1.Items.RemoveAt(Chelsea);
                Mannschaft2.Items.RemoveAt(Chelsea);
                Mannschaft3.Items.RemoveAt(Chelsea);
                Mannschaft4.Items.RemoveAt(Chelsea);
                Mannschaft5.Items.RemoveAt(Chelsea);
                Mannschaft6.Items.RemoveAt(Chelsea);
                Mannschaft7.Items.RemoveAt(Chelsea);

                Barcelona = 0;
                Real_Madrid = 1;
                Bayern_Munich = 2;
                Paris_St_Germain = 3;
                Atletico_Madrid = 4;
                Juventus = 5;
                Manchester_City = 6;
            }
        }
    }
}
/*
  private void Mannschaft2_MouseLeave(object sender, MouseEventArgs e)
  {
    if (Mannschaft2.SelectedIndex > -1)
    { //somthing was selected

      Mannschaft1.Items.RemoveAt(Mannschaft2.SelectedIndex);
      Mannschaft3.Items.RemoveAt(Mannschaft2.SelectedIndex);
      Mannschaft4.Items.RemoveAt(Mannschaft2.SelectedIndex);
      Mannschaft5.Items.RemoveAt(Mannschaft2.SelectedIndex);
      Mannschaft6.Items.RemoveAt(Mannschaft2.SelectedIndex);
      Mannschaft7.Items.RemoveAt(Mannschaft2.SelectedIndex);
      Mannschaft8.Items.RemoveAt(Mannschaft2.SelectedIndex);
      //selecteditem = Mannschaft1.SelectedItem.ToString();
    }
  }

  private void Mannschaft3_MouseLeave(object sender, MouseEventArgs e)
  {
    if (Mannschaft3.SelectedIndex > -1)
    { //somthing was selected

      Mannschaft1.Items.RemoveAt(Mannschaft3.SelectedIndex);
      Mannschaft2.Items.RemoveAt(Mannschaft3.SelectedIndex);
      Mannschaft4.Items.RemoveAt(Mannschaft3.SelectedIndex);
      Mannschaft5.Items.RemoveAt(Mannschaft3.SelectedIndex);
      Mannschaft6.Items.RemoveAt(Mannschaft3.SelectedIndex);
      Mannschaft7.Items.RemoveAt(Mannschaft3.SelectedIndex);
      Mannschaft8.Items.RemoveAt(Mannschaft3.SelectedIndex);
      //selecteditem = Mannschaft1.SelectedItem.ToString();
    }
  }

  private void Mannschaft4_MouseLeave(object sender, MouseEventArgs e)
  {
    if (Mannschaft4.SelectedIndex > -1)
    { //somthing was selected

      Mannschaft1.Items.RemoveAt(Mannschaft4.SelectedIndex);
      Mannschaft2.Items.RemoveAt(Mannschaft4.SelectedIndex);
      Mannschaft3.Items.RemoveAt(Mannschaft4.SelectedIndex);
      Mannschaft5.Items.RemoveAt(Mannschaft4.SelectedIndex);
      Mannschaft6.Items.RemoveAt(Mannschaft4.SelectedIndex);
      Mannschaft7.Items.RemoveAt(Mannschaft4.SelectedIndex);
      Mannschaft8.Items.RemoveAt(Mannschaft4.SelectedIndex);
      //selecteditem = Mannschaft1.SelectedItem.ToString();
    }
  }

  private void Mannschaft5_MouseLeave(object sender, MouseEventArgs e)
  {
    if (Mannschaft5.SelectedIndex > -1)
    { //somthing was selected

      Mannschaft1.Items.RemoveAt(Mannschaft5.SelectedIndex);
      Mannschaft2.Items.RemoveAt(Mannschaft5.SelectedIndex);
      Mannschaft3.Items.RemoveAt(Mannschaft5.SelectedIndex);
      Mannschaft4.Items.RemoveAt(Mannschaft5.SelectedIndex);
      Mannschaft6.Items.RemoveAt(Mannschaft5.SelectedIndex);
      Mannschaft7.Items.RemoveAt(Mannschaft5.SelectedIndex);
      Mannschaft8.Items.RemoveAt(Mannschaft5.SelectedIndex);
      //selecteditem = Mannschaft1.SelectedItem.ToString();
    }
  }

  private void Mannschaft6_MouseLeave(object sender, MouseEventArgs e)
  {
    if (Mannschaft6.SelectedIndex > -1)
    { //somthing was selected

      Mannschaft1.Items.RemoveAt(Mannschaft6.SelectedIndex);
      Mannschaft2.Items.RemoveAt(Mannschaft6.SelectedIndex);
      Mannschaft3.Items.RemoveAt(Mannschaft6.SelectedIndex);
      Mannschaft4.Items.RemoveAt(Mannschaft6.SelectedIndex);
      Mannschaft5.Items.RemoveAt(Mannschaft6.SelectedIndex);
      Mannschaft7.Items.RemoveAt(Mannschaft6.SelectedIndex);
      Mannschaft8.Items.RemoveAt(Mannschaft6.SelectedIndex);
      //selecteditem = Mannschaft1.SelectedItem.ToString();
    }
  }

  private void Mannschaft7_MouseLeave(object sender, MouseEventArgs e)
  {
    if (Mannschaft7.SelectedIndex > -1)
    { //somthing was selected

      Mannschaft1.Items.RemoveAt(Mannschaft7.SelectedIndex);
      Mannschaft2.Items.RemoveAt(Mannschaft7.SelectedIndex);
      Mannschaft3.Items.RemoveAt(Mannschaft7.SelectedIndex);
      Mannschaft4.Items.RemoveAt(Mannschaft7.SelectedIndex);
      Mannschaft5.Items.RemoveAt(Mannschaft7.SelectedIndex);
      Mannschaft6.Items.RemoveAt(Mannschaft7.SelectedIndex);
      Mannschaft8.Items.RemoveAt(Mannschaft7.SelectedIndex);
      //selecteditem = Mannschaft1.SelectedItem.ToString();
    }
  }

  private void Mannschaft8_MouseLeave(object sender, MouseEventArgs e)
  {
    if (Mannschaft8.SelectedIndex > -1)
    { //somthing was selected

      Mannschaft1.Items.RemoveAt(Mannschaft8.SelectedIndex);
      Mannschaft2.Items.RemoveAt(Mannschaft8.SelectedIndex);
      Mannschaft3.Items.RemoveAt(Mannschaft8.SelectedIndex);
      Mannschaft4.Items.RemoveAt(Mannschaft8.SelectedIndex);
      Mannschaft5.Items.RemoveAt(Mannschaft8.SelectedIndex);
      Mannschaft6.Items.RemoveAt(Mannschaft8.SelectedIndex);
      Mannschaft7.Items.RemoveAt(Mannschaft8.SelectedIndex);
      //selecteditem = Mannschaft1.SelectedItem.ToString();
    }
  }
}
}
*/