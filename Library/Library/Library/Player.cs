namespace Library;
//DB
public abstract class Player
{
   protected Deck _deck;
   public abstract IValuable Play();
}

public class Deck
{
   public Deck(IValuable[] deck)
   {
      
   }
}