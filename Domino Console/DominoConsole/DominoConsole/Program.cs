using System.Threading.Channels;

namespace DominoConsole;

public static class Program
{
    public static void Main(string[] args)
    {  
        bool menuout = false;
        Action<string> WritewholeLine = s => Console.WriteLine(s);
        Action<string> Write = s => Console.Write(s); 
        WritewholeLine("Elija qué variaciónes quiere adicionar al juego en caso de qué no elija alguna\nse usaran la clásica ");
        WritewholeLine("1- Regla de Turnos");
        WritewholeLine("2- Regla de fichas");
        WritewholeLine("3- Cantidad y Tipos de jugadores");
        WritewholeLine("4- Regla de ganar: ");
        WritewholeLine("10- Continuar: ");
        WritewholeLine("11- Salir: ");
        while (!menuout)
        {
            
        }
    }
}



