using Microsoft.AspNetCore.Components;
using ProjectForex.Client.Model;
using ProjectForex.Client.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectForex.Client.Pages
{
    public partial class Account : ComponentBase
    {
        private Root AccountMains;
        private string accountId = "101-004-16583730-001";
        private string ErrorMessage;


        private async Task GetHistoricDataAsync()
        {
            try
            {

                {
                    //https://api-fxpractice.oanda.com/v3/instruments/EUR_USD/candles?count=6&price=M&granularity=S5

                    string uri = "https://api-fxpractice.oanda.com/v3/accounts/"+accountId;
                    Console.WriteLine(uri);
                    AccountMains = await Http.GetJsonAsync<Root>(uri);
                    Console.WriteLine(AccountMains);
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

