using Labo_7___Polymorphism.Data;
using Labo_7___Polymorphism.Entities;
using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Labo_7___Polymorphism;

public partial class MainWindow : Window
{
    private Store<Machine> _store = new Store<Machine>();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void ImportButton_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog ofd = new OpenFileDialog();
        if (ofd.ShowDialog() == true)
        {
            using (StreamReader sr = new StreamReader(ofd.FileName))
            {
                string[] line;
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine().Split(',');
                    switch (line[0])
                    {
                        case ("L"):
                            LaserCutter laserCutter = new LaserCutter(
                                    line[1],
                                    Convert.ToInt16(line[2]),
                                    Convert.ToInt16(line[3]),
                                    Convert.ToSingle(line[4]),
                                    Convert.ToDouble(line[5])
                                );
                            _store.AddItem(laserCutter);
                            break;
                        case ("R"):
                            Router router = new Router(
                                    line[1],
                                    Convert.ToInt16(line[2]),
                                    Convert.ToInt16(line[3]),
                                    Convert.ToSingle(line[4])
                                );
                            _store.AddItem(router);
                            break;
                        case ("G"):
                            General general = new General(
                                    line[1]
                                );
                            _store.AddItem(general);
                            break;
                    }
                }
            }
            foreach (Machine machine in _store.GetAllItems())
            {
                itemsListBox.Items.Add(machine);
            }

            clearButton.IsEnabled = true;
            sortButton.IsEnabled = true;
            filterButton.IsEnabled = true;
        }
    }

    private void RemoveButton_Click(object sender, RoutedEventArgs e)
    {
        if (itemsListBox.SelectedIndex != -1 || itemsListBox.SelectedItem != null)
        {
            itemsListBox.Items.Remove(itemsListBox.SelectedItem);
        }
    }

    private void ClearButton_Click(object sender, RoutedEventArgs e)
    {
        _store.ClearAllItems();
        itemsListBox.Items.Clear();
    }

    private void UseButton_Click(object sender, RoutedEventArgs e)
    {
        if (itemsListBox.SelectedIndex != -1 || itemsListBox.SelectedItems != null)
        {
            Machine machine = itemsListBox.SelectedItem as Machine;
            bool validInput = int.TryParse(inputTextBox.Text, out int amountOfMinutes);
            if (validInput)
            {
                machine.Use(amountOfMinutes);
            }
            else
            {
                MessageBox.Show("Invalid input for amount of numbers.");
            }
        }
    }

    private void SortButton_Click(object sender, RoutedEventArgs e)
    {
        
    }

    private void FilterButton_Click(object sender, RoutedEventArgs e)
    {
        
    }

    private void itemsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (itemsListBox.SelectedIndex != -1 || itemsListBox.SelectedItem != null)
        {
            removeButton.IsEnabled = true;
        }
        else
        {
            removeButton.IsEnabled = false;
        }
    }
}