namespace DesignPatternSimulate.Services
{
    public class DatabaseService
    {

        private DatabaseService()
        {
            Console.WriteLine($"{nameof(DatabaseService)} is created");
            
        }

        static DatabaseService _instance;

        public int Count { get; set; } = 0;
        public static DatabaseService GetInstance
        {
            get
            {
                //Singleton yaptığımız kısım burası  bir örneği oluşturulmadıysa oluşturuyoruz. oluştuysa olanı dönüyoruz
                if (_instance == null)
                    _instance = new DatabaseService();

                return _instance;
            }
        
        }

        public bool Connect()
        {
            Count++;
            Console.WriteLine($"{nameof(DatabaseService)} is connected");
            return true;
        }
        public bool Disconnect()
        {
            Count++;
            Console.WriteLine($"{nameof(DatabaseService)} is disconnected");
            return true;
        }
    }
}
