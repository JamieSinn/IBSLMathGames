using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGames
{
    class Program
    {
        static Random rnd = new Random();
        static int DiceRun_A;
        static int DiceRun_B;

        static void Main(string[] args)
        {
            string input;
            Console.WriteLine("IB SL Math Games Console Program\nBy Jamie Sinn");
            Console.WriteLine("Valid Commands: dicerun, keyforacar, coingame");
            
            
            while(true)
            {
                Console.WriteLine("Please enter a command: ");
                input = Console.ReadLine();
                switch (input)
                {
                    case "dicerun":
                        for (int i = 0; i <= 30; i++)
                            Console.WriteLine(DiceRun());
                        break;
                    case "keyforacar":
                        for (int i = 0; i <= 30; i++)
                            Console.WriteLine(KeyForACar());
                        break;
                    case "coingame":
                        for (int i = 0; i <= 30; i++)
                            Console.WriteLine(CoinGame());
                        break;
                }
                
                
            }
        }
        static int GetDiceRun_PlayerA()
        {
            
            while(true)
            {
                int PlayerA = rnd.Next(12)+1;
                if(PlayerA >= 3 && PlayerA <= 11)
                {
                    return PlayerA;
                }
            }
        }
        static int GetDiceRun_PlayerB()
        {
            while (true)
            {
                int PlayerB = rnd.Next(12) + 1;
                if (PlayerB >= 3 && PlayerB <= 11 && PlayerB != DiceRun_B)
                {
                    return PlayerB;
                }
            }
            
        }
        static int GetDiceRun_RollA()
        {
            return TwoDice();
        }
        static int GetDiceRun_RollB()
        {
            return TwoDice();
        }
        static string DiceRun()
        {
            DiceRun_A = GetDiceRun_PlayerA();
            DiceRun_B = GetDiceRun_PlayerB();
            int turn = 2;
            while (true)
            {
                if(turn%2==0)
                {
                    if (TwoDice() == 2 || TwoDice() == 12 || TwoDice() == DiceRun_A)
                        return "Player A Wins";

                    turn++;
                }
                else
                {
                    if(TwoDice() == 2 || TwoDice() == 12 || TwoDice() == DiceRun_B)
                        return "Player B Wins";

                    turn++;
                }
                    

                
            }
            
        }

        static int GetKeyForACar_WinningKey()
        {
            return OneDice();
        }  
        static string KeyForACar()
        {
            int winner = GetKeyForACar_WinningKey();
            int turn = 1;
            int prev = 0;
            while (true)
            {
                int cache = OneDice();
                if (turn == 1)
                {
                    if (cache == winner)
                        return "Player 1 Wins";
                    prev = cache;
                    turn++;
                }
                else if (turn == 2 && cache != prev)
                {
                    
                    if (cache == winner)
                        return "Player 2 Wins";
                    prev = cache;
                    turn++;

                }
                else if (turn == 3 && cache != prev)
                {
                    if (cache == winner)
                        return "Player 3 Wins";
                    prev = cache;
                    turn++;
                }
                else if (turn == 4 && cache != prev)
                {
                    if (cache == winner)
                        return "Player 4 Wins";
                    prev = cache;
                    turn++;
                }
                else
                {
                    if (cache == winner)
                        return "Player 5 Wins";
                    prev = 0;
                    turn = 1;
                }


               
            }
            
        }


        static string CoinGame()
        {
            int turn = 2;
            int P1 = 0;
            int P2 = 0;
            while (true)
            {
                

                if (turn % 2 == 0)
                {
                    P1 = FlipCoin();
                    turn++;
                }
                else
                {
                    P2 = FlipCoin();
                    turn++;
                }

                if(P1 ==1 && P2 == 1)
                {
                    return "Both Heads";
                }
                else if((P1 == 1 && P2 == 2) || (P1 == 2 && P2 ==1))
                {
                    return "One Heads, One Tails";
                }
                else if (P1 == 2 && P2 == 2)
                {
                    return "Both Tails";
                }
            }
        }
        static int OneDice() 
        {            
            return rnd.Next(6)+1;         
        }
        static int TwoDice()
        {
            return rnd.Next(12) + 1;
        }
        static int FlipCoin()
        {
            return rnd.Next(0,3);
        }
    }
}
