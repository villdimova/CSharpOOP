namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            
            var sportCar = new SportCar(200, 200);
            sportCar.Drive(10);
            System.Console.WriteLine(sportCar.Fuel);
        }
    }
}
