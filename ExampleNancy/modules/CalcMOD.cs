using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ExampleNancy.DTO;
using Nancy;
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
                var a = new RutaAttribute("la ruta es bla bla");

                var wallet = new WalletView()
                {
                    Id = (Nancy.DynamicDictionaryValue)parameters.category,
                    BankAccountNumber = "123987",
                    CurrentBalance = 150000,
                };

                return wallet; 
            });

            After += ctx =>
            {
                ctx.Response.ContentType = "application/json";
            };

        }
    }
}
