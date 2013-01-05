using NServiceBus;
using Sb.BetProcessor.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sb.Mocks.PlacingBets
{
    public class PlaceBets : IWantToRunAtStartup
    {
        public IBus Bus { get; set; }

        public void Run()
        {
            Console.WriteLine("Press enter key to place coupon");

            while(Console.ReadLine() != null)
            {
                var coupon = new PlaceCoupon{
                    Bets = new List<PlaceBet>{
                        new PlaceBet{
                            MarketSeletectionId = 1,
                            Stake = 1.0
                        },
                        new PlaceBet{
                            MarketSeletectionId = 2,
                            Stake = 1.2
                        }
                    }
                };
                Bus.Send(coupon);

                Console.WriteLine("Coupon has been send");
            }
        }

        public void Stop()
        {
            
        }
    }
}
