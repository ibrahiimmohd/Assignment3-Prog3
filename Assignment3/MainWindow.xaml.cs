using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Assignment3.Models;

namespace Assignment3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBHelperContext context = new DBHelperContext();
        List<Fruit> firstComboList = new List<Fruit>();
        List<Planet> secondComboList = new List<Planet>();

        public MainWindow()
        {
            InitializeComponent();

            firstComboBox.ItemsSource = context.Fruits.ToList();
            secondComboBox.ItemsSource = context.Planets.ToList();
            this.FetchDataFruit();
            this.FetchDataPlanet();
            firstDataGrid.CanUserAddRows = false;
            secondDataGrid.CanUserAddRows = false;
            thirdDataGrid.CanUserAddRows = false;

        }

        private void FirstComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Fruit value = firstComboBox.SelectedItem as Fruit; 
            if (firstComboBox.SelectedIndex >= 0)
            {
                Fruit newFruit = new Fruit();
                newFruit.Name = value.Name;
                newFruit.Color = value.Color;
                context.Fruits.Add(newFruit);
                context.SaveChanges();
            }
            this.FetchDataFruit();
        }

        private void SecondComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Planet value = secondComboBox.SelectedItem as Planet;
            if (secondComboBox.SelectedIndex >= 0)
            {
                Planet newPlanet = new Planet();
                newPlanet.Name = value.Name;
                newPlanet.Color = value.Color;
                context.Planets.Add(newPlanet);
                context.SaveChanges();
            }
            this.FetchDataPlanet();
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            if (firstDataGrid.ItemsSource != null || secondDataGrid.ItemsSource != null || thirdDataGrid.ItemsSource != null)
            {
                context.Fruits.RemoveRange(context.Fruits);
                context.SaveChanges();
                firstDataGrid.ItemsSource = null;
                firstDataGrid.Items.Refresh();
                firstComboBox.SelectedIndex = -1;

                context.Planets.RemoveRange(context.Planets);
                context.SaveChanges();
                secondDataGrid.ItemsSource = null;
                secondDataGrid.Items.Refresh();
                secondComboBox.SelectedIndex = -1;

                thirdDataGrid.ItemsSource = null;
                thirdDataGrid.Items.Refresh();
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (firstDataGrid.ItemsSource != null || secondDataGrid.ItemsSource != null)
            {
                Fruit valueFirstDatagrid = firstDataGrid.SelectedItem as Fruit;
                Planet valueSecondDatagrid = secondDataGrid.SelectedItem as Planet;


                if (valueFirstDatagrid != null)
                {
                    
                    context.Fruits.Remove(valueFirstDatagrid);
                    context.SaveChanges();

                    this.FetchDataFruit();
                    firstComboBox.SelectedIndex = -1;
                }

                if (valueSecondDatagrid != null)
                {
                    context.Planets.Remove(valueSecondDatagrid);
                    context.SaveChanges();

                    this.FetchDataPlanet();
                    secondComboBox.SelectedIndex = -1;
                }
            }
        }

        private void linqProjectBtn_Click(object sender, RoutedEventArgs e)
        {
            /* // Original submission
             * 
             * var query = from fruit in context.Fruits.ToList()
                        select new { FruitName = fruit.Name };
            thirdDataGrid.ItemsSource = query;
            thirdDataGrid.Items.Refresh();*/

            // Modified based on Professor's suggestion
            thirdDataGrid.ItemsSource = context.Fruits.ToList().Select(f => new { FruitName = f.Name });
            thirdDataGrid.Items.Refresh();
        }

        private void linqInnerJoinBtn_Click(object sender, RoutedEventArgs e)
        {
            /* // Original submission
             * var query = from fruit in context.Fruits.ToList()
                        join planet in context.Planets.ToList() on fruit.Color equals planet.Color
                        select new { FruitName = fruit.Name, PlanetName = planet.Name };
            thirdDataGrid.ItemsSource = query;
            thirdDataGrid.Items.Refresh();*/

            // Modified based on Professor's suggestion
            var query = context.Fruits.Join(context.Planets,
                                fruit => fruit.Color,
                                planet => planet.Color,
                                (fruit, planet) => new {
                                    FruitName = fruit.Name,
                                    PlanetName = planet.Name
                                });
            thirdDataGrid.ItemsSource = query.ToList();
            thirdDataGrid.Items.Refresh();
        }

        private void linqFilterBtn_Click(object sender, RoutedEventArgs e)
        {
            /* // Original submission
             * var query = from fruit in context.Fruits.ToList()
                        where fruit.Color == "Red"
                        select new { FruitName = fruit.Name};
            thirdDataGrid.ItemsSource = query;
            thirdDataGrid.Items.Refresh();*/

            // Modified based on Professor's suggestion
            thirdDataGrid.ItemsSource = context.Fruits.ToList().Where(r => r.Color == "Red").Select(f => new { FruitName = f.Name });
            thirdDataGrid.Items.Refresh();

        }

        private void linqOrderAscBtn_Click(object sender, RoutedEventArgs e)
        {
            /* // Original submission
             * var query = from fruit in context.Fruits.ToList()
                        orderby fruit.Name ascending
                        select new { FruitName = fruit.Name };
            
            thirdDataGrid.ItemsSource = query;
            thirdDataGrid.Items.Refresh();*/

            // Modified based on Professor's suggestion
            thirdDataGrid.ItemsSource = context.Fruits.ToList().OrderBy(r => r.Name).Select(f => new { FruitName = f.Name });
            thirdDataGrid.Items.Refresh();
        }

        private void FetchDataFruit()
        {
            firstDataGrid.ItemsSource = context.Fruits.ToList();
            firstDataGrid.Items.Refresh();
        }
        private void FetchDataPlanet()
        {
            secondDataGrid.ItemsSource = context.Planets.ToList();
            secondDataGrid.Items.Refresh();
        }

        private void FirstDataGrid_GotFocus(object sender, RoutedEventArgs e)
        {
            secondDataGrid.UnselectAll();
        }

        private void SecondDataGrid_GotFocus(object sender, RoutedEventArgs e)
        {
            firstDataGrid.UnselectAll();
        }
    }
}
