using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3DataManmagement.Models;
using GraphQL.Client;
using GraphQL.Common.Request;
using Xamarin.Forms;

namespace Assignment3DataManmagement
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // ResponseLabel.Text = "Fetching data from github";

            var qRequest = new GraphQLRequest
            {
                Query = @"{allFilms {films {title director} } }"
            };
            String url = "https://swapi.apis.guru/graphiql";
            var graphQLClient = new GraphQLClient(url);
            var graphQLResponse = await graphQLClient.PostAsync(qRequest);
            Post_List.ItemsSource = graphQLResponse.Data.allFilms.films.ToObject<List<Film>>();
        }
    }
}
