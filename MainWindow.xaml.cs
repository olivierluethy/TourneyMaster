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

    private void btnSimulieren_Click(object sender, RoutedEventArgs e)
    {
      // Wie viele Male drückt man den Knopf?
      gedrückt++;

      // Hat man den Knopf einmal gedrückt?
      if (gedrückt == 1)
      {
        btnSimulieren.Content = "Wer kommt in den Final?";

        string mannschaft1 = Mannschaft1.SelectedValue.ToString();
        string mannschaft2 = Mannschaft2.SelectedValue.ToString();
        string mannschaft3 = Mannschaft3.SelectedValue.ToString();
        string mannschaft4 = Mannschaft4.SelectedValue.ToString();
        string mannschaft5 = Mannschaft5.SelectedValue.ToString();
        string mannschaft6 = Mannschaft6.SelectedValue.ToString();
        string mannschaft7 = Mannschaft7.SelectedValue.ToString();
        string mannschaft8 = Mannschaft8.SelectedValue.ToString();

        Random rnd = new Random();
        int PunkteStand1 = rnd.Next(11);
        int PunkteStand2 = rnd.Next(11);

        // Falls die beiden Teams den gleichen Punktestand haben
        if ((PunkteStand1 == PunkteStand2) && (PunkteStand1 >= 0 && PunkteStand2 >= 0))
        {
          Random div = new Random();
          int equal = div.Next(3);

          if (equal == 0)
          {
            PunkteStand1--;
          }
          else if (equal == 1)
          {
            PunkteStand2--;
          }
          else
          {

          }
        } else if ((PunkteStand1 == PunkteStand2) && (PunkteStand1 <= 0 && PunkteStand2 <= 0))
        {
          Random div = new Random();
          int equal = div.Next(3);

          if (equal == 0)
          {
            PunkteStand1++;
          }
          else if (equal == 1)
          {
            PunkteStand2++;
          }
          else
          {

          }
        }

        lblTore1.Content = PunkteStand1.ToString();
        lblTore2.Content = PunkteStand2.ToString();

        int PunkteStand3 = rnd.Next(11);
        int PunkteStand4 = rnd.Next(11);

        if ((PunkteStand3 == PunkteStand4) && (PunkteStand3 >= 0 && PunkteStand2 >= 4))
        {
          Random div = new Random();
          int equal = div.Next(3);

          if (equal == 0)
          {
            PunkteStand3--;
          }
          else if (equal == 1)
          {
            PunkteStand4--;
          }
          else
          {

          }
        }
        else if ((PunkteStand3 == PunkteStand4) && (PunkteStand3 <= 0 && PunkteStand2 <= 4))
        {
          Random div = new Random();
          int equal = div.Next(3);

          if (equal == 0)
          {
            PunkteStand3++;
          }
          else if (equal == 1)
          {
            PunkteStand4++;
          }
          else
          {

          }
        }

        lblTore3.Content = PunkteStand3.ToString();
        lblTore4.Content = PunkteStand4.ToString();

        int PunkteStand5 = rnd.Next(11);
        int PunkteStand6 = rnd.Next(11);

        if ((PunkteStand5 == PunkteStand6) && (PunkteStand5 >= 0 && PunkteStand6 >= 0))
        {
          Random div = new Random();
          int equal = div.Next(3);

          if (equal == 0)
          {
            PunkteStand5--;
          }
          else if (equal == 1)
          {
            PunkteStand6--;
          }
          else
          {

          }
        }
        else if ((PunkteStand5 == PunkteStand6) && (PunkteStand5 <= 0 && PunkteStand6 <= 0))
        {
          Random div = new Random();
          int equal = div.Next(3);

          if (equal == 0)
          {
            PunkteStand5++;
          }
          else if (equal == 1)
          {
            PunkteStand6++;
          }
          else
          {

          }
        }

        lblTore5.Content = PunkteStand5.ToString();
        lblTore6.Content = PunkteStand6.ToString();

        int PunkteStand7 = rnd.Next(11);
        int PunkteStand8 = rnd.Next(11);

        if ((PunkteStand7 == PunkteStand8) && (PunkteStand7 >= 0 && PunkteStand8 >= 0))
        {
          Random div = new Random();
          int equal = div.Next(3);

          if (equal == 0)
          {
            PunkteStand7--;
          }
          else if (equal == 1)
          {
            PunkteStand8--;
          }
          else
          {

          }
        }
        else if ((PunkteStand7 == PunkteStand8) && (PunkteStand7 <= 0 && PunkteStand8 <= 0))
        {
          Random div = new Random();
          int equal = div.Next(3);

          if (equal == 0)
          {
            PunkteStand7++;
          }
          else if (equal == 1)
          {
            PunkteStand8++;
          }
          else
          {

          }
        }

        lblTore7.Content = PunkteStand7.ToString();
        lblTore8.Content = PunkteStand8.ToString();

        if (PunkteStand1 > PunkteStand2)
        {
          lblErsteGewinner1.Content = mannschaft1;
        }
        else if (PunkteStand1 < PunkteStand2)
        {
          lblErsteGewinner1.Content = mannschaft2;
        }
        if (PunkteStand3 > PunkteStand4)
        {
          lblErsteGewinner2.Content = mannschaft3;
        }
        else if (PunkteStand3 < PunkteStand4)
        {
          lblErsteGewinner2.Content = mannschaft4;
        }
        if (PunkteStand5 > PunkteStand6)
        {
          lblErsteGewinner3.Content = mannschaft5;
        }
        else if (PunkteStand5 < PunkteStand6)
        {
          lblErsteGewinner3.Content = mannschaft6;
        }
        if (PunkteStand7 > PunkteStand8)
        {
          lblErsteGewinner4.Content = mannschaft7;
        }
        else if (PunkteStand7 < PunkteStand8)
        {
          lblErsteGewinner4.Content = mannschaft8;
        }
      }

      // Hat man den Knopf ein zweites Mal gedrückt?
      else if (gedrückt == 2)
      {
        btnSimulieren.Content = "Wer ist der Sieger?";

        Random rnd = new Random();
        int PunkteStand1 = rnd.Next(11);
        int PunkteStand2 = rnd.Next(11);

        if ((PunkteStand1 == PunkteStand2) && (PunkteStand1 >= 0 && PunkteStand2 >= 0))
        {
          Random div = new Random();
          int equal = div.Next(3);

          if (equal == 0)
          {
            PunkteStand1--;
          }
          else if (equal == 1)
          {
            PunkteStand2--;
          }
          else
          {

          }
        }
        else if ((PunkteStand1 == PunkteStand2) && (PunkteStand1 <= 0 && PunkteStand2 <= 0))
        {
          Random div = new Random();
          int equal = div.Next(3);

          if (equal == 0)
          {
            PunkteStand1++;
          }
          else if (equal == 1)
          {
            PunkteStand2++;
          }
          else
          {

          }
        }

        lblErsteGewinner2Tore.Content = PunkteStand2.ToString();
        lblErsteGewinner1Tore.Content = PunkteStand1.ToString();

        int PunkteStand3 = rnd.Next(11);
        int PunkteStand4 = rnd.Next(11);

        if ((PunkteStand3 == PunkteStand4) && (PunkteStand3 >= 0 && PunkteStand4 >= 0))
        {
          Random div = new Random();
          int equal = div.Next(3);

          if (equal == 0)
          {
            PunkteStand3--;
          }
          else if (equal == 1)
          {
            PunkteStand4--;
          }
          else
          {

          }
        }
        else if ((PunkteStand3 == PunkteStand4) && (PunkteStand3 <= 0 && PunkteStand4 <= 0))
        {
          Random div = new Random();
          int equal = div.Next(3);

          if (equal == 0)
          {
            PunkteStand1++;
          }
          else if (equal == 1)
          {
            PunkteStand2++;
          }
          else
          {

          }
        }

        lblErsteGewinner3Tore.Content = PunkteStand3.ToString();
        lblErsteGewinner4Tore.Content = PunkteStand4.ToString();

        string halb1 = lblErsteGewinner1.Content.ToString();
        string halb2 = lblErsteGewinner2.Content.ToString();
        string halb3 = lblErsteGewinner3.Content.ToString();
        string halb4 = lblErsteGewinner4.Content.ToString();

        if (PunkteStand1 < PunkteStand2)
        {
          lblFinal1.Content = halb2.ToString();
        } else if (PunkteStand1 > PunkteStand2)
        {
          lblFinal1.Content = halb1.ToString();
        }
        if (PunkteStand3 < PunkteStand4)
        {
          lblFinal2.Content = halb4.ToString();
        } else if (PunkteStand3 > PunkteStand4)
        {
          lblFinal2.Content = halb3.ToString();
        }
      }

      // Hat man den Knopf ein drittes Mal gedrückt?
      else if (gedrückt == 3)
      {
        btnSimulieren.Content = "Fertig";

        Random rnd = new Random();
        int PunkteStand1 = rnd.Next(11);
        int PunkteStand2 = rnd.Next(11);

        if ((PunkteStand1 == PunkteStand2) && (PunkteStand1 >= 0 && PunkteStand2 >= 0))
        {
          Random div = new Random();
          int equal = div.Next(3);

          if (equal == 0)
          {
            PunkteStand1--;
          }
          else if (equal == 1)
          {
            PunkteStand2--;
          }
          else
          {

          }
        }
        else if ((PunkteStand1 == PunkteStand2) && (PunkteStand1 <= 0 && PunkteStand2 <= 0))
        {
          Random div = new Random();
          int equal = div.Next(3);

          if (equal == 0)
          {
            PunkteStand1++;
          }
          else if (equal == 1)
          {
            PunkteStand2++;
          }
          else
          {

          }
        }

        lblFinal1Tore.Content = PunkteStand1.ToString();
        lblFinal2Tore.Content = PunkteStand2.ToString();

        string final1 = lblFinal1.Content.ToString();
        string final2 = lblFinal2.Content.ToString();

        if (PunkteStand1 < PunkteStand2)
        {
          lblSieger.Content = final2.ToString();
        } else if (PunkteStand1 > PunkteStand2)
        {
          lblSieger.Content = final1.ToString();
        }
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

      if(selectedText == "Barcelona")
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
      else if(selectedText =="Real Madrid")
      {
        Mannschaft2.Items.RemoveAt(mannschaften[1]);
        Mannschaft3.Items.RemoveAt(mannschaften[1]);
        Mannschaft4.Items.RemoveAt(mannschaften[1]);
        Mannschaft5.Items.RemoveAt(mannschaften[1]);
        Mannschaft6.Items.RemoveAt(mannschaften[1]);
        Mannschaft7.Items.RemoveAt(mannschaften[1]);
        Mannschaft8.Items.RemoveAt(mannschaften[1]);
      }else if(selectedText =="Bayern Munich")
      {
        Mannschaft2.Items.RemoveAt(mannschaften[2]);
        Mannschaft3.Items.RemoveAt(mannschaften[2]);
        Mannschaft4.Items.RemoveAt(mannschaften[2]);
        Mannschaft5.Items.RemoveAt(mannschaften[2]);
        Mannschaft6.Items.RemoveAt(mannschaften[2]);
        Mannschaft7.Items.RemoveAt(mannschaften[2]);
        Mannschaft8.Items.RemoveAt(mannschaften[2]);
      }else if(selectedText == "Paris Saint-Germain")
      {
        Mannschaft2.Items.RemoveAt(mannschaften[3]);
        Mannschaft3.Items.RemoveAt(mannschaften[3]);
        Mannschaft4.Items.RemoveAt(mannschaften[3]);
        Mannschaft5.Items.RemoveAt(mannschaften[3]);
        Mannschaft6.Items.RemoveAt(mannschaften[3]);
        Mannschaft7.Items.RemoveAt(mannschaften[3]);
        Mannschaft8.Items.RemoveAt(mannschaften[3]);
      }else if(selectedText== "Atletico Madrid")
      {
        
      }else if(selectedText== "Juventus")
      {
        
      }else if(selectedText== "Manchester City")
      {
        
      }else if(selectedText== "Chelsea")
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
  } }
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