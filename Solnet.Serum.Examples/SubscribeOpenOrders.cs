using Solnet.Rpc;
using Solnet.Serum.Models;
using System;
using System.Collections.Generic;

namespace Solnet.Serum.Examples
{
    public class SubscribeOpenOrders : IRunnableExample
    {
        private readonly ISerumClient _serumClient;
        
        private List<ISerumClient> _serumClients;
        
        /// <summary>
        /// Public key for Open Orders Account.
        /// </summary>
        private const string OpenOrdersAccountAddress = "4beBRAZSVcCm7jD7yAmizqqVyi39gVrKNeEPskickzSF";

        public SubscribeOpenOrders()
        {
            _serumClient = ClientFactory.GetClient(Cluster.MainNet);
            _serumClients = new List<ISerumClient>();
            _serumClient.Connect();
            Console.WriteLine($"Initializing {ToString()}");
        }

        public void Run()
        {
            SubscribeSingle();
        }

        private void SubscribeSingle()
        {
            Subscription sub = _serumClient.SubscribeOpenOrdersAccount((subWrapper, account) =>
            {
                Console.WriteLine($"OpenOrdersAccount:: Owner: {account.Owner.Key} Market: {account.Market.Key}\n" +
                                  $"BaseTotal: {account.BaseTokenTotal} BaseFree: {account.BaseTokenFree}\n" +
                                  $"QuoteTotal: {account.QuoteTokenTotal} QuoteFree: {account.QuoteTokenFree}\n" +
                                  $"Total Orders: {account.Orders.Count}");
                /*
                 foreach (Order order in account.Orders)
                {
                    Console.WriteLine($"Order:: IsBid: {order.IsBid} Price: {order.Price}");
                }
                */
            }, OpenOrdersAccountAddress);
            
            Console.ReadKey();
        }
    }
}