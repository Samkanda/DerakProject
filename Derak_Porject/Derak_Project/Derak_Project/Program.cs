using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Derak_Project
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


            /*//original console test I had
            DurakDeck deck = new DurakDeck();
            List<DurakHand> players = new List<DurakHand>();
            players.Add(new DurakHuman());
            players.Add(new DurakHuman());
            players.Add(new DurakHuman());
            players.Add(new DurakHuman());
            DurakBout[] durakRound;


            deck.Shuffle();

            foreach (DurakHand player in players)
            {
                player.DrawToMinimum(deck);
                Console.WriteLine(player.ToString());
            }

            while (true)
            {
                durakRound = new DurakBout[DurakBout.Defender.Count];
                foreach (DurakHand player in players)
                {
                    player.TakeTurn();//knowledge of the list of durakbouts needs to get inside this method somehow
                }
            }*/
        }
    }
}
