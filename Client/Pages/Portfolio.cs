using Microsoft.AspNetCore.Components;
using ProjectForex.Client.Model;
using ProjectForex.Client.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectForex.Client.Pages
{
    public partial class Portfolio : ComponentBase
    {
        private Root accountMain;

        private string ErrorMessage;
        private string accountId = "101-004-16583730-001";
        public string instrument = "EUR_USD";
        //private string lastTrans;



        private async Task GetOpenTradesDataAsync()
        {
            try
            {

                {
                    //https://api-fxpractice.oanda.com/v3/accounts/101-004-16583730-001/openTrades
                    // string uri = "https://api-fxpractice.oanda.com/v3/instruments/EUR_USD/candles?count=6&price=M&granularity=S5";

                    string uri = "https://api-fxpractice.oanda.com/v3/accounts/" + accountId + "/openTrades";
                    //   Console.WriteLine(uri);
                    accountMain = await Http.GetJsonAsync<Root>(uri);
                    //     Console.WriteLine(accountMain);
                    ErrorMessage = String.Empty;
                    //   Console.WriteLine(ErrorMessage);
                    Console.WriteLine(accountMain.lastTransactionID);


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ErrorMessage = e.Message;
                //    Console.WriteLine(ErrorMessage);
            }
        }




        protected override async Task OnInitializedAsync()
        {
            await GetOpenTradesDataAsync();

        }

      /*  private async Task GetSpecificTradesDataAsync()
        {
            try
            {

                {
                    //https://api-fxpractice.oanda.com/v3/accounts/101-004-16583730-001/openTrades
                    // string uri = "https://api-fxpractice.oanda.com/v3/accounts/101-004-16583730-001/trades?instrument=USD_CAD";

                    string uri = "https://api-fxpractice.oanda.com/v3/accounts/" + accountId + "/trades?instrument="+instrument;
                    //   Console.WriteLine(uri);
                    accountMain = await Http.GetJsonAsync<Root>(uri);
                    //     Console.WriteLine(accountMain);
                    ErrorMessage = String.Empty;
                    //   Console.WriteLine(ErrorMessage);
                    Console.WriteLine(accountMain.lastTransactionID);


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ErrorMessage = e.Message;
                //    Console.WriteLine(ErrorMessage);
            }
        }
*/



    }
}
