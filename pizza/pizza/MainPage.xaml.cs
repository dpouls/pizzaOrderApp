using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace pizza
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Take information from form and create a pizza order. We will make sure each field has been filled out to some degree.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOrder_Clicked(object sender, EventArgs e)
        {
            // make sure a topping is selected before continuing, else alert them to pick a topping
            if (SwtchCheese.IsToggled || SwtchPepperoni.IsToggled || SwtchPineapple.IsToggled)
            {
                // make sure a crust was selected, else alert them to pick a crust
                if (PckCrust.SelectedIndex > -1)
                {
                    // make sure a city was selected, else alert them to pick a city. if true, then turn all the entries to strings and concatenate them to make an alert that displays the order summary.
                    if (LstViewCity.SelectedItem.ToString() != "")
                    {
                        string toppings = "";
                        string crust = PckCrust.SelectedItem.ToString();
                        string city = LstViewCity.SelectedItem.ToString();
                        toppings = SwtchCheese.IsToggled ? "Cheese" : toppings += SwtchPepperoni.IsToggled ? "Pepperoni" : toppings += SwtchPineapple.IsToggled ? "Pineapple" : "";
                        DisplayAlert("Pizza Order", $"{crust} crust pizza with {toppings}. Delivered to {city}", "Close");
                    } 
                    else
                    {
                        DisplayAlert("Invalid Input", "Please select a city", "Close");
                    }
                }
                else
                {
                    DisplayAlert("Invalid Input", "Please select a crust", "Close");
                }
            }
            else
            {
                DisplayAlert("Invalid Input", "Please select at least one topping", "Close");
            }
        }
    }
}
