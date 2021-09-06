using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using ProjectForex.Client.Model;
using ProjectForex.Client.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProjectForex.Client.Pages
{
    public partial class Trade : ComponentBase
    {
        public int units;
        public string instrument;
        private Root AccountMains;
        private string accountId = "101-004-16583730-001";
        private string ErrorMessage;
        private string lastTransaction;
        private string message = "Nothing Traded";
        private Boolean success = false;


        public async Task PostBuy(int unit, string instrument)
        {
            {
                Order order = new Order()
                {

                    units = unit,
                    instrument = instrument,
                    timeInForce = "FOK",
                    type = "MARKET",
                    positionFill = "DEFAULT"
                };

                TradeInfo trade = new TradeInfo()
                {
                    order = order
                };



                string uri = "https://api-fxpractice.oanda.com/v3/accounts/101-004-16583730-001/orders";

                string stringjson = JsonConvert.SerializeObject(trade);
                Console.WriteLine(stringjson);

                try
                {

                    var response = await Http.PostBuyJsonAsync2<RootMarket>(uri, stringjson);
                    Console.WriteLine(response);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                // await Http.SendJsonAsync(Http.PostAsync, "https://api-fxpractice.oanda.com/v3/accounts/101-004-16583730-001/orders", tradeInfo);
            }



        }

        public async Task PostSellAsync(int unit, string instrument)
        {

            TradeInfo trade = new TradeInfo
            {
                order = new Order()
                {

                    units = -unit,
                    instrument = instrument,
                    timeInForce = "FOK",
                    type = "MARKET",
                    positionFill = "DEFAULT"
                }
            };



            string uri = "https://api-fxpractice.oanda.com/v3/accounts/101-004-16583730-001/orders";

            string stringjson = JsonConvert.SerializeObject(trade);
            Console.WriteLine(stringjson);

            try
            {

                var response = await Http.PostBuyJsonAsync2<RootMarket>(uri, stringjson);
                Console.WriteLine(response);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            // await Http.SendJsonAsync(Http.PostAsync, "https://api-fxpractice.oanda.com/v3/accounts/101-004-16583730-001/orders", tradeInfo);
        }
       
        public ActionResult TradeAction(int option)
        {
            if (option == 1)
            {
                PostBuy(this.units, this.instrument);
                Console.WriteLine(option);
                success = true;

            }
            else if (option == 2)
            {
                PostSellAsync(this.units, this.instrument);
                Console.WriteLine(option);
                success = true;
            }
            else
            {
                Console.WriteLine("Action not working");
                success = false;
            }
            return null;
        }
        private async Task GetLastTransactionDataAsync()
        {
            try
            {

                {
                    //https://api-fxpractice.oanda.com/v3/instruments/EUR_USD/candles?count=6&price=M&granularity=S5

                    string uri = "https://api-fxpractice.oanda.com/v3/accounts/"+accountId+"/orders/"+lastTransaction;
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
            await GetLastTransactionDataAsync();


        }

    
        public string SuccessMessage(string message)
        {
            if(success = true)
            {
                message = "Transaction Successful";
            }
            else
            {
                message = "Transaction Failed";
            }
         return   this.message = message;
           
        }
    }
}
