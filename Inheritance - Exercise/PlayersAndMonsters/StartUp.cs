namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Hero hero = new BladeKnight("Arthur", 15);
            System.Console.WriteLine(hero);
        }
    }
}