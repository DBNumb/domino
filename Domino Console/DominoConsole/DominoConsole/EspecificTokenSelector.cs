using System.Net.Security;
namespace DominoConsole;
using Library;
public class AsignaFichaPlayers: IReglaDeSelección
{
    public void AsignaFichaPlayer(List<Token> domain, Player[] players, int max)
    {
        Console.BackgroundColor = ConsoleColor.White;
        
        Random random = new Random();
        bool[] mask = new bool[domain.Count];

        for (int i = 0; i < players.Length; i++)
        {Console.Clear();
            while (players[i].PlayerHand.Count < max)
            {
                int x = random.Next(0, mask.Length);
                if (mask[x] == false)
                {
                    mask[x] = true;
                    players[i].PlayerHand.Add(domain[x]);
                    
                }
            }
            Console.ForegroundColor = ConsoleColor.Black;
            MenuWheel.Show($"Mano del jugador{i}: ");
            PlayGame.PrintCollection(players[i].PlayerHand);
            Thread.Sleep(1000);
        }
    }
}

public class ReseleccionarAsignacion: IReglaDeSelección
{
    private int max;
    public ReseleccionarAsignacion(int max)
    {
        this.max = max;
    }

    private AsignaFichaPlayers classic = new AsignaFichaPlayers();
    public void AsignaFichaPlayer(List<Token> domain, Player[] players, int max)
    { MenuWheel.Show($"Los jugadores cambiaran {this.max} fichas");
        Thread.Sleep(1000);
       classic.AsignaFichaPlayer(domain,players,max);
       Console.BackgroundColor = ConsoleColor.White;
       Console.ForegroundColor = ConsoleColor.Black;
       Console.Clear(); 
       
        for (int i=0;i<players.Length;i++)
        {Console.Clear();
            MenuWheel.Show($"Mano actual del jugador {i}");
            PlayGame.PrintCollection(players[i].PlayerHand);
            Console.ForegroundColor = ConsoleColor.Black;
            Thread.Sleep(1000);
            Reselect(players[i].strategy.GiveSortedHand(players[i].PlayerHand),this.max);
        }
        
        
        classic.AsignaFichaPlayer(domain,players,max);
        
    }

    private void Reselect(List<Token> PlayerSortedHand, int i)
    {
        for (int k = 0; k < i; k++)
        {
            PlayerSortedHand.Remove(PlayerSortedHand[0]);
        }
    }
}