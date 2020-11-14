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

            firstComboBox.ItemsSource = context.Fruits.ToList();//Fruit.GetItems();
            secondComboBox.ItemsSource = context.Planets.ToList();//Planet.GetItems();
            this.FetchDataFruit();
            this.FetchDataPlanet();
            //Add to DB
            //Planet newFruit = new Planet();
            //newFruit.Name = $"Earth";
            //newFruit.Color = $"Green 123";
            //context.Planet.Add(newFruit);
            //// context.Fruit.AddRange(); if want to add list
            //context.SaveChanges();

            //Retrieve from DB specific only 1 by first or default
            //similar with Fruit::where('Color','Green6')->first()
            //Fruit fruit = context.Fruit.Where(f => f.Color == "Green6").FirstOrDefault();
            //MessageBox.Show($"Retrieve from DB Id = {fruit.FruitId}, name = {fruit.Name}, color = {fruit.Color}, updated at = {fruit.UpdatedAt}");

            // Retrieve from DB specific only 1 by first or default
            // similar with Fruit::where('FruitId',1)->get()
            //List<Fruit> fruits = context.Fruit.ToList();

            //foreach (Fruit f in fruits)
            //{
            //    MessageBox.Show($"Retrieve from DB Id = {f.FruitId}, name = {f.Name}, color = {f.Color}, updated at = {f.UpdatedAt}");
            //}
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

        //I did the logic where when you select an item on the datagrid, it would unselect the "same" item on the other datagrid
        //The issue is there are no similarities at the moment, will need to clarify this later
        private void FirstDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Fruit value = firstComboBox.SelectedItem as Fruit;

            //if (value != null)
            //{
            //    //int index = secondComboList.IndexOf(secondComboList.Find(item => item.Contains(value)));
            //    int index = secondComboList.IndexOf(secondComboList.Find(item => item.Name == value.Name);
            //    if (index != -1)
            //    {
            //        secondComboList.RemoveAt(index);
            //    }

            //    secondDataGrid.ItemsSource = secondComboList;
            //    secondDataGrid.Items.Refresh();
            //}
            if (value != null)
            {
                //int index = secondComboList.IndexOf(secondComboList.Find(item => item.Contains(value)));
                int index = firstComboList.IndexOf(firstComboList.Find(item => item.Name == value.Name));
                if (index != -1)
                {
                    firstComboList.RemoveAt(index);
                }

                secondDataGrid.ItemsSource = firstComboList;
                secondDataGrid.Items.Refresh();
            }
        }

        //I did the logic where when you select an item on the datagrid, it would unselect the "same" item on the other datagrid
        //The issue is there are no similarities at the moment, will need to clarify this later
        private void SecondDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string value = secondDataGrid.SelectedItem as string;

            //if (value != null)
            //{
            //    int index = firstComboList.IndexOf(firstComboList.Find(item => item.Contains(value)));
            //    if (index != -1)
            //    {
            //        firstComboList.RemoveAt(index);
            //    }
               
            //    firstDataGrid.ItemsSource = firstComboList;
            //    firstDataGrid.Items.Refresh();
            //}
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            if (firstDataGrid.ItemsSource != null || secondDataGrid.ItemsSource != null || thirdDataGrid.ItemsSource != null)
            {
                firstComboList.Clear();
                firstDataGrid.ItemsSource = firstComboList;
                firstDataGrid.Items.Refresh();
                firstComboBox.SelectedIndex = -1;

                secondDataGrid.ItemsSource = secondComboList;
                secondComboList.Clear();
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
                Planet valueSecondDatagrid = firstDataGrid.SelectedItem as Planet;

                int index;

                if (valueFirstDatagrid != null)
                {
                    index = firstComboList.IndexOf(firstComboList.Find(item => item.Name == valueFirstDatagrid.Name));
                    if (index != -1)
                    {
                        firstComboList.RemoveAt(index);
                    }
                    firstDataGrid.ItemsSource = firstComboList;
                    firstDataGrid.Items.Refresh();
                    firstComboBox.SelectedIndex = -1;
                }

                if (valueSecondDatagrid != null)
                {
                    index = secondComboList.IndexOf(secondComboList.Find(item => item.Name == valueSecondDatagrid.Name));
                    if (index != -1)
                    {
                        secondComboList.RemoveAt(index);
                    }
                    secondDataGrid.ItemsSource = secondComboList;
                    secondDataGrid.Items.Refresh();
                    secondComboBox.SelectedIndex = -1;
                }
            }
        }

        private void linqInnerJoinBtn_Click(object sender, RoutedEventArgs e)
        {
            var query = from fruit in context.Fruits.ToList()
                        join planet in context.Planets.ToList() on fruit.Color equals planet.Color
                        select new { FruitName = fruit.Name, PlanetName = planet.Name };
            thirdDataGrid.ItemsSource = query;
            thirdDataGrid.Items.Refresh();
        }

        private void linqFilterBtn_Click(object sender, RoutedEventArgs e)
        {
            var query = from fruit in context.Fruits.ToList()
                        where fruit.Color == "red"
                        select new { FruitName = fruit.Name};
            thirdDataGrid.ItemsSource = query;
            thirdDataGrid.Items.Refresh();
        }

        private void linqOrderAscBtn_Click(object sender, RoutedEventArgs e)
        {
            var query = from fruit in context.Fruits.ToList()
                        orderby fruit.Name ascending
                        select new { FruitName = fruit.Name };
            thirdDataGrid.ItemsSource = query;
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

        private void linqProjectBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Do something");
        }
    }
}
