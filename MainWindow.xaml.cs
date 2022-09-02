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
using System.IO;
using CWK2.data;
using CWK2.business;

namespace CWK2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Parcel> parcels = new List<Parcel>();
        private List<Courier> couriers = new List<Courier>();
        private Dictionary<string, int> parcelList = new Dictionary<string, int>();

        public MainWindow()
        {
            InitializeComponent();
            
            //Create a facade
            Facade facade = new Facade();
            facade.Method1(); //Call method in the facade

            
        }

        private void AddParcel_Click(object sender, RoutedEventArgs e)
        {
            //Make sure that the area and delivery text boxes are not empty
            if (AreaTxt.Text != "" && DeliveryIDTxt.Text != "")
            {
                Parcel parcel = new Parcel();
                parcel.Area = AreaTxt.Text;
                parcel.deliveryID = DeliveryIDTxt.Text;

                parcels.Add(parcel);

                //Check that postcode begins with "EH"
                if (!AreaTxt.Text.StartsWith("EH"))
                {
                    MessageBox.Show("Invalid postcode");
                }
                else
                {
                    //check that each ID corresponds to the right courier
                    if (CourierTypeTxt.Text == "1")
                    {
                        if (Int32.Parse(NumParcelTxt.Text) >= 1 && Int32.Parse(NumParcelTxt.Text) <= 10)
                        {
                            //display cycle if ID is 1
                            AreaCourierList.Items.Add($"{parcel.Area} - Courier {CourierTypeTxt.Text} (Cycle): {NumParcelTxt.Text}/{Cycle.parcelQuantity}");
                        }
                        else
                        {
                            //if the items are more than the capacity of the courier, diplay an error message 
                            AreaCourierList.Items.Add("No Items or more items than the capacity of the courier.");
                        }
                    }
                    else if (CourierTypeTxt.Text == "2")
                    {
                        if (Int32.Parse(NumParcelTxt.Text) >= 1 && Int32.Parse(NumParcelTxt.Text) <= 5)
                        {
                            //display walk if ID is 2
                            AreaCourierList.Items.Add($"{parcel.Area} - Courier {CourierTypeTxt.Text} (Walk): {NumParcelTxt.Text}/{Walk.parcelQuantity}");
                        }
                        else
                        {
                            //if the items are more than the capacity of the courier, diplay an error message 
                            AreaCourierList.Items.Add("No Items or more items than the capacity of the courier.");
                        }
                    }
                    else if (CourierTypeTxt.Text == "3")
                    {
                        if (Int32.Parse(NumParcelTxt.Text) >= 1 && Int32.Parse(NumParcelTxt.Text) <= 100)
                        {   //display van if ID is 3
                            AreaCourierList.Items.Add($"{parcel.Area} - Courier {CourierTypeTxt.Text} (Van): {NumParcelTxt.Text}/{Van.parcelQuantity}");
                        }
                        else
                        {
                            //if the items are more than the capacity of the courier, diplay an error message 
                            AreaCourierList.Items.Add("No Items or more items than the capacity of the courier.");
                        }
                    }
                    else if (CourierTypeTxt.Text == "" || Int32.Parse(NumParcelTxt.Text) == 0)
                    {
                        //display if nothing is written in the courier text box
                        AreaCourierList.Items.Add("Cannot allocate parcel.");
                    }
                    else
                    {
                        //display if the id given is not 1, 2 or 3
                        AreaCourierList.Items.Add("Cannot allocate parcel.");
                    }
                }

                //Create a singleton object and use it to log messages to a file.
                Singleton s = Singleton.Instance;
                if (CourierTypeTxt.Text == "1" && !(Int32.Parse(NumParcelTxt.Text) > 10)) //This code will check which id belongs to a courier
                {
                    //Output in the log.csv
                    s.log($"New Courier Added ID= {CourierTypeTxt.Text}", $"Type= Cycle");
                    s.log($"New Parcel Added ({AreaTxt.Text} {DeliveryIDTxt.Text}, \"{NameTxt.Text},{AddressTxt.Text}\")", $"Allocated to Courier {CourierTypeTxt.Text}");
                }
                else if (CourierTypeTxt.Text == "2" && !(Int32.Parse(NumParcelTxt.Text) > 5)) //This code will check which id belongs to a courier
                {
                    //Output in the log.csv
                    s.log($"New Courier Added ID= {CourierTypeTxt.Text}", $"Type= Walk");
                    s.log($"New Parcel Added ({AreaTxt.Text} {DeliveryIDTxt.Text}, \"{NameTxt.Text},{AddressTxt.Text}\")", $"Allocated to Courier {CourierTypeTxt.Text}");
                }
                else if (CourierTypeTxt.Text == "3" && !(Int32.Parse(NumParcelTxt.Text) > 100)) //This code will check which id belongs to a courier
                {
                    //Output in the log.csv
                    s.log($"New Courier Added ID= {CourierTypeTxt.Text}", $"Type= Van");
                    s.log($"New Parcel Added ({AreaTxt.Text} {DeliveryIDTxt.Text}, \"{NameTxt.Text},{AddressTxt.Text}\")", $"Allocated to Courier {CourierTypeTxt.Text}");
                }
            }
        }

        private void AddCourier_Click(object sender, RoutedEventArgs e)
        {
            /*This is the add courier section
             * where when the user types the ID
             * it will be displayed in the list box
             */
            Courier courier = new Courier();
            courier.name = CourierTypeTxt.Text;

            /*Check what the ID is and it will show which
             *courier it belongs to
             */
            if (CourierTypeTxt.Text == "1")
            {
                //Show name courier in delivery list box
                DeliveryListCourier.Items.Add("Cycle");
            }
            else if(CourierTypeTxt.Text == "2")
            {
                //Show name courier in delivery list box
                DeliveryListCourier.Items.Add("Walk");
            }
            else if(CourierTypeTxt.Text == "3")
            {
                //Show name courier in delivery list box
                DeliveryListCourier.Items.Add("Van");
            }
            else if(CourierTypeTxt.Text == "")
            {
                //Show error in delivery list box
                DeliveryListCourier.Items.Add("No courier");
            }
            else
            {
                //Show error in delivery list box
                DeliveryListCourier.Items.Add("No existing courier");
            }

            couriers.Add(courier);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            //Clears all text boxes once the Clear button is clicked

            CourierTypeTxt.Clear(); //Courier text box is cleared
            AreaTxt.Clear();  //Area text box is cleared
            DeliveryIDTxt.Clear(); //DeliveryID text box is cleared
            NameTxt.Clear(); //Name text box is cleared
            AddressTxt.Clear();  //Address text box is cleared
            NumParcelTxt.Clear(); //NumParcel text box is cleared
        }

        private void Transfer_Click(object sender, RoutedEventArgs e)
        {
            //Clear the courier text box and item in delivery courier list box
            //string test = CourierTypeTxt.Text.Replace($"{CourierTypeTxt.Text}", $"{CourierTypeTxt.Text}");
            CourierTypeTxt.Clear();
            DeliveryListCourier.Items.RemoveAt(DeliveryListCourier.Items.Count - 1);

            //Update the parcel and courier
            //Create a singleton object and use it to log messages to a file.
            Singleton s = Singleton.Instance;
            AreaCourierList.Items.RemoveAt(AreaCourierList.Items.Count - 1); //clear item in the list box

            if (CourierTypeTxt.Text == "1" && !(Int32.Parse(NumParcelTxt.Text) > 10))  //This code will check which id belongs to a courier
            {
                //Output in the log.csv
                s.log($"New Courier Added ID= {CourierTypeTxt.Text}", $"Type= Cycle");
                s.log($"New Parcel Added ({AreaTxt.Text} {DeliveryIDTxt.Text}, \"{NameTxt.Text},{AddressTxt.Text}\")", $"Allocated to Courier {CourierTypeTxt.Text}");
            }
            else if (CourierTypeTxt.Text == "2" && !(Int32.Parse(NumParcelTxt.Text) > 5)) //This code will check which id belongs to a courier
            {
                //Output in the log.csv
                s.log($"New Courier Added ID= {CourierTypeTxt.Text}", $"Type= Walk");
                s.log($"New Parcel Added ({AreaTxt.Text} {DeliveryIDTxt.Text}, \"{NameTxt.Text},{AddressTxt.Text}\")", $"Allocated to Courier {CourierTypeTxt.Text}");
            }
            else if (CourierTypeTxt.Text == "3" && !(Int32.Parse(NumParcelTxt.Text) > 100)) //This code will check which id belongs to a courier
            {
                //Output in the log.csv
                s.log($"New Courier Added ID= {CourierTypeTxt.Text}", $"Type= Van");
                s.log($"New Parcel Added ({AreaTxt.Text} {DeliveryIDTxt.Text}, \"{NameTxt.Text},{AddressTxt.Text}\")", $"Allocated to Courier {CourierTypeTxt.Text}");
            }

            //do something for private Dictionary<string, Parcel> parcelList = new Dictionary<string, Parcel>();
            int count = 0;
            parcelList.Add(DeliveryIDTxt.Text, count);
            foreach (KeyValuePair<string, int> pl in parcelList)
            {
                //Check that parcel ID already exists
                string testKey = DeliveryIDTxt.Text;
                bool keyExists = parcelList.ContainsKey(testKey);
                if (keyExists)
                {
                    MessageBox.Show($"Parcel ID: {DeliveryIDTxt.Text} is going to be transferred");
                }
            }

        }

        private void ReadCSV_Click(object sender, RoutedEventArgs e)
        {
            /*This is a read csv code where once the 
             * log.csv file is created, it will read
             * the contents in the file
             */
            string path = @"C:\C#\log.csv";  //location or path of the file

            string str = File.ReadAllText(path);  //reads all the contents in the .csv file

            CSV_List.ItemsSource = str; //the contents will be displayed in the list box
        }

        private void WriteCSV_Click(object sender, RoutedEventArgs e)
        {
            /*This code will write two words for the .csv file
             * and in case there is an error it will throw an error
             */
            static void words(string newPostcode, string newName, string filepath)
            {
                try
                {
                    using (System.IO.StreamWriter file = new StreamWriter(filepath, true)) //set filepath to true so it will add contents
                    {
                        //what will be written
                        file.WriteLine("Time, " + DateTime.Now + ",Sender:, "+ newPostcode + " "+ newName);
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Oops! Something went wrong", ex);
                }
            }

            
            words("EH27", "OZIOMA E. O.", "C:\\C#\\log.csv"); //first two words to be written in the log.csv

        }
    }
}