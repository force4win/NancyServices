using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ExampleNancy.DTO;
using Nancy;
using Nancy.Extensions;
using Nancy.Routing.Constraints;
using Newtonsoft.Json;
using WalletsApi.Views;

namespace ExampleNancy.modules
{
    
    public class CalcMod : NancyModule
    {

        private string path = "calc";
        public CalcMod()
        {
            
            Get("/calc/{category}", parameters =>
            {
                var wallet = new WalletView()
                {
                    Id = (Nancy.DynamicDictionaryValue)parameters.category,
                    BankAccountNumber = "123987",
                    CurrentBalance = 150000,
                };

                return wallet; 
            });


            Post("/calc", parameters =>
                {

                    var a = this.Request.Body.AsString();
                    Console.WriteLine("Los parametros llegaron "+a);
                    var b = JsonConvert.DeserializeObject<RequestGeneric>(a);

                    var wallet = new WalletView()
                    {
                        Id = b.Key,
                        BankAccountNumber = b.Object,
                        CurrentBalance = 150000,
                    };

                    return wallet;
                }

            );

        }
    }
}
