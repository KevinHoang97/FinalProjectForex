using Microsoft.AspNetCore.Components;
using ProjectForex.Client.Model;
using ProjectForex.Client.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectForex.Client.Pages
{
    public partial class HistoricData : ComponentBase
    {
        private RootCandle Mains;
        private string ErrorMessage;
        public string instrument = "EUR_USD";
        public string granularity = "S5";
        private int count = 7;


        private async Task GetHistoricDataAsync()
        {
            try
            {

                {
                    //https://api-fxpractice.oanda.com/v3/instruments/EUR_USD/candles?count=6&price=M&granularity=S5

                    string uri = "https://api-fxpractice.oanda.com/v3/instruments/" + instrument + "/candles?count=" + count + "&price=M&granularity=" + granularity;
                    Console.WriteLine(uri);
                    Mains = await Http.GetJsonAsync<RootCandle>(uri);
                    Console.WriteLine(Mains);
                    ErrorMessage = String.Empty;
                    Console.WriteLine(ErrorMessage);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ErrorMessage = e.Message;
                Console.WriteLine(ErrorMessage);
            }
        }



        protected override async Task OnInitializedAsync()
        {
            await GetHistoricDataAsync();


        }

    }
}
