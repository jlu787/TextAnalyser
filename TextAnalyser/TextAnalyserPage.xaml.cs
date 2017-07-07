using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace TextAnalyser
{
    public partial class TextAnalyserPage : ContentPage
    {
        public TextAnalyserPage()
        {
            InitializeComponent();


        }

        async void clickAnalyseAsync(object sender, EventArgs args)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:6740");

                var sendText = new SendText();
                var document = new Document();

                document.language = "en";
                document.id = "1";
                document.text = textToBeAnalysed.Text;

                sendText.documents.Add(document);

                var content = new FormUrlEncodedContent(sendText);
                var result = await client.PostAsync("/text/analytics/v2.0/sentiment", JsonConvert.DeserializeObject(sendText));
                string resultContent = await result.Content.ReadAsStringAsync();
            }
            //DisplayAlert("Click", "Analyse was clicked", "Ok");
        }

        void clickReset(object sender, EventArgs args)
		{
            DisplayAlert("Click", "Reset was clicked", "Ok");
		}

		void clickHistory(object sender, EventArgs args)
		{
            DisplayAlert("Click", "History was clicked", "Ok");
		}
    }
}
