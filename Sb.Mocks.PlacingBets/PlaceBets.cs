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
                    BetCombinations = new List<PlaceBetCombination>()
                    {
                        new PlaceBetCombination()
                        {
                            BetSelections = new List<PlaceBetSelection>
                            {
                                new PlaceBetSelection{
                                    MarketSeletectionId = 1,
                                    CurrentOdds = 1.0,
                                    CurrentSelection = "1"
                                },
                                new PlaceBetSelection{
                                    MarketSeletectionId = 2,
                                    CurrentOdds = 1.2,
                                    CurrentSelection = "2"
                                }
                            },
                            Stake = 4.0
                        },

                        new PlaceBetCombination()
                        {
                            BetSelections = new List<PlaceBetSelection>
                            {
                                new PlaceBetSelection{
                                    MarketSeletectionId = 3,
                                    CurrentOdds = 3.0,
                                    CurrentSelection = "X"
                                }
                            },
                            Stake = 4.0
                        }
                    }
                };

                Bus.Send(coupon);

                Console.WriteLine("Coupon has been sent");
            }
        }

        public void Stop()
        {
            
        }
    }
}
