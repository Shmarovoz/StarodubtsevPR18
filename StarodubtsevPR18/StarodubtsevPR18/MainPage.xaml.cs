using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;

namespace StarodubtsevPR18
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void ButtonResult_Clicked(object sender, EventArgs e)
        {
            staclLayout.Children.Clear();
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    HttpClient client = new HttpClient();
                    HttpResponseMessage response = await client.GetAsync($"https://rickandmortyapi.com/api/character/{entryNumber.Text.Replace(".", "")}");
                    HttpContent responseContent = response.Content;
                    string json = await responseContent.ReadAsStringAsync();
                    RickMorty RickMorty = JsonConvert.DeserializeObject<RickMorty>(json);
                    staclLayout.Children.Add(new Image() { Source = ImageSource.FromUri(new Uri(RickMorty.image)), HeightRequest = 250, WidthRequest = 200 });
                    staclLayout.Children.Add(new Label() { Text = "ID: " + (RickMorty.id.ToString()), FontSize = 30, TextColor = Color.Aqua });
                    staclLayout.Children.Add(new Label() { Text = "Name: " + (RickMorty.name.ToString()), FontSize = 30, TextColor = Color.Aqua });
                    staclLayout.Children.Add(new Label() { Text = "Status: " + (RickMorty.status.ToString()), FontSize = 30, TextColor = Color.Aqua });
                    staclLayout.Children.Add(new Label() { Text = "Species: " + (RickMorty.species.ToString()), FontSize = 30, TextColor = Color.Aqua });
                    staclLayout.Children.Add(new Label() { Text = "Type: " + (RickMorty.type.ToString()), FontSize = 30, TextColor = Color.Aqua });
                    staclLayout.Children.Add(new Label() { Text = "Gender: " + (RickMorty.gender.ToString()), FontSize = 30, TextColor = Color.Aqua });
                    staclLayout.Children.Add(new Label() { Text = "Origin: " + (RickMorty.origin.name.ToString()), FontSize = 30, TextColor = Color.Aqua });
                    staclLayout.Children.Add(new Label() { Text = "Location: " + (RickMorty.location.name.ToString()), FontSize = 30, TextColor = Color.Aqua });

                }
                catch (Exception ex)
                {
                    var error = new Label() { Text = ex.Message, TextColor = Color.Red };
                    staclLayout.Children.Add(error);
                }

            }
        }
    }
}
    

