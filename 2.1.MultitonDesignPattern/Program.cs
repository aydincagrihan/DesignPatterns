#region Açıklamalar
/*
 
 Uygulama bazında bir sınıfın SINIRLI sayıda instance'ını oluşturmak için kullanılan bir tasarım desenidir.
Yazılım mühendisliğinde sıkça kullanılan tasarım desenlerinden biri olan Multiton, Singleton deseninin bir genellemesi olarak kabul edilir. Singleton deseni bir sınıftan yalnızca tek bir nesne (instance) oluşturulmasına izin verirken, Multiton deseni belirli anahtarlarla ilişkilendirilmiş, kontrollü sayıda ve yönetilen bir nesne havuzu oluşturulmasını sağlar.

Multiton Deseni Nedir?
Multiton tasarım deseni, bir sınıfın birden fazla örneğinin oluşturulmasına olanak tanıyan ancak bu örnekleri bir harita (map) veya sözlük (dictionary) yapısı içinde yöneterek her bir anahtara karşılık yalnızca tek bir örnek olmasını garanti eden bir yaratımsal (creational) desendir. Bu sayede, aynı anahtar ile yapılan sonraki nesne taleplerinde yeni bir nesne oluşturmak yerine, daha önce oluşturulmuş olan nesne geri döndürülür.

Temel olarak, her bir nesnenin benzersiz bir anahtar (key) ile tanımlandığı bir "tekil nesneler kaydı" olarak düşünülebilir.

Nasıl Çalışır?
Multiton deseninin çalışma prensibi oldukça basittir:

Özel Kurucu Metot (Private Constructor): Sınıfın dışından new anahtar kelimesi ile doğrudan nesne oluşturulmasını engellemek için kurucu metot özel (private) olarak tanımlanır.

Statik Nesne Havuzu: Oluşturulan nesneleri ve bu nesnelere karşılık gelen anahtarları tutmak için genellikle statik bir Map, Dictionary veya HashMap veri yapısı kullanılır.

Statik Erişim Metodu: Nesne talep etmek için kullanılan, genellikle getInstance() olarak adlandırılan ve bir anahtar parametresi alan statik bir metot bulunur. Bu metot şu mantıkla çalışır:

Verilen anahtarın nesne havuzunda olup olmadığını kontrol eder.

Eğer anahtar havuzda mevcutsa, o anahtara karşılık gelen mevcut nesneyi döndürür.

Eğer anahtar havuzda yoksa, yeni bir nesne oluşturur, bu nesneyi verilen anahtar ile birlikte havuza ekler ve ardından yeni oluşturulan nesneyi döndürür.

Bu mekanizma sayesinde, her bir anahtar için yalnızca bir nesnenin var olması garanti altına alınır.

 Özellik	            Singleton	                                                Multiton
Nesne Sayısı	Uygulama yaşam döngüsü boyunca sadece bir tane.     	Her bir anahtar için bir tane, toplamda birden fazla.
Erişim Metodu	Genellikle parametresizdir (getInstance()).	        Bir anahtar parametresi alır (getInstance(key)).
Kullanım Amacı	Tüm sistemde tek olması gereken global bir kaynak (örn. konfigürasyon yöneticisi, loglama servisi) için kullanılır.	Benzer türde ancak farklı konfigürasyonlara veya durumlara sahip birden fazla yönetilen kaynak (örn. veritabanı bağlantıları, tema yöneticileri) için kullanılır.
Esneklik	    Daha katıdır, sadece tek bir durumu yönetir.	        Farklı anahtarlar aracılığıyla farklı nesneleri yönetebildiği için daha esnektir.
 




Multiton Deseninin Avantajları ve Dezavantajları
Avantajları
Kontrollü Nesne Sayısı: Bir sınıftan rastgele sayıda nesne oluşturulmasını engelleyerek kaynak kullanımını optimize eder.

Kaynak Yönetimi: Özellikle veritabanı bağlantıları, ağ soketleri veya donanım sürücüleri gibi maliyetli ve sınırlı kaynakların yönetiminde etkilidir. Her bir farklı kaynak için (örneğin, farklı veritabanları için) ayrı bir nesne oluşturulmasını sağlar.

Gecikmeli Yükleme (Lazy Loading): Nesneler sadece ihtiyaç duyulduğunda ve ilk kez talep edildiğinde oluşturulur. Bu da uygulamanın başlangıç performansını artırabilir.

Global Erişim Noktası: Anahtarlar aracılığıyla ilgili nesnelere kolay ve merkezi bir erişim imkanı sunar.

Dezavantajları
Global Durum (Global State): Singleton'da olduğu gibi, Multiton deseni de global bir durum yarattığı için eleştirilir. Bu durum, kodun daha az modüler olmasına ve bileşenler arasında istenmeyen bağımlılıklara yol açabilir.

Test Edilebilirlik Zorlukları: Global durumu ve statik metotları nedeniyle birim testleri (unit testing) yazmak zorlaşır. Nesneleri taklit etmek (mocking) karmaşık hale gelebilir.

Bellek Sızıntısı Riski: Nesne havuzunda tutulan nesneler, uygulama sonlanana kadar bellekten temizlenmeyebilir (garbage collector tarafından toplanamayabilir). Eğer çok sayıda ve büyük boyutlu nesne anahtarlarla oluşturulursa, bu durum zamanla bellek sızıntılarına yol açabilir.

Çoklu İş Parçacığı (Multi-threading) Sorunları: getInstance() metodunun eş zamanlı olarak birden fazla iş parçacığı tarafından çağrıldığı durumlarda, aynı anahtar için birden fazla nesne oluşturulmasını önlemek amacıyla lock veya synchronized gibi senkronizasyon mekanizmalarının dikkatli bir şekilde uygulanması gerekir.

Kullanım Alanları (Use Cases)
Multiton deseni aşağıdaki gibi senaryolarda oldukça kullanışlıdır:

Veritabanı Bağlantıları: Bir uygulamada birden fazla veritabanı (örn. birincil, raporlama, arşiv) kullanılıyorsa, her bir veritabanı bağlantısını bir anahtarla (örn. veritabanı adı) yönetmek için Multiton kullanılabilir.

DatabaseManager.getInstance("PrimaryDB")

DatabaseManager.getInstance("ReportingDB")

Yapılandırma Yöneticileri: Farklı modüller veya ortamlar (geliştirme, test, üretim) için farklı yapılandırma setlerini yönetmek.

Donanım Sürücüleri: Sistemde birden fazla aynı türde donanım (örn. yazıcılar, seri portlar) varsa, her bir donanım için ayrı bir sürücü nesnesini yönetmek.

Tema veya Profil Yönetimi: Bir kullanıcı arayüzü uygulamasında, farklı kullanıcılar veya temalar için farklı ayar nesnelerini yönetmek.

C# ile Basit Bir Multiton Örneği
Aşağıda, farklı veritabanı bağlantılarını yöneten bir Multiton deseni C# dilinde basitçe gösterilmiştir:
 */
#endregion
#region Ornek
/*
 Bu örnekte, GetInstance metodu "PrimaryDB" anahtarı ile ilk kez çağrıldığında yeni bir DatabaseConnection nesnesi oluşturulur ve havuza eklenir. İkinci çağrıda ise havuzda bu anahtara sahip bir nesne olduğu için mevcut nesne geri döndürülür, böylece kaynakların yeniden oluşturulması önlenmiş olur.
 
 
 
 */

using System;
using System.Collections.Generic;
using System.Threading;

public class DatabaseConnection
{
    // 2. Statik ve thread-safe bir nesne havuzu (ConcurrentDictionary)
    private static readonly Dictionary<string, DatabaseConnection> _instances = new Dictionary<string, DatabaseConnection>();
    private static readonly object _lock = new object();

    public string ConnectionString { get; private set; }
    public string ConnectionName { get; private set; }

    // 1. Dışarıdan nesne oluşturmayı engellemek için private kurucu metot
    private DatabaseConnection(string connectionName)
    {
        this.ConnectionName = connectionName;
        // Burada gerçek bir veritabanı bağlantısı kurulur.
        this.ConnectionString = $"Host={connectionName};User=admin;...";
        Console.WriteLine($"Yeni bağlantı oluşturuldu: {ConnectionName}");
    }

    // 3. Anahtar ile nesne talep etmek için kullanılan statik metot
    public static DatabaseConnection GetInstance(string key)
    {
        // Çoklu iş parçacığı güvenliği için lock bloğu kullanılır.
        lock (_lock)
        {
            if (!_instances.ContainsKey(key))
            {
                _instances[key] = new DatabaseConnection(key);
            }
            return _instances[key];
        }
    }

    public void Connect()
    {
        Console.WriteLine($"{ConnectionName} üzerinden veritabanına bağlanıldı. ({ConnectionString})");
    }
}

// Kullanım
public class Program
{
    public static void Main(string[] args)
    {
        DatabaseConnection primaryDb = DatabaseConnection.GetInstance("PrimaryDB");
        primaryDb.Connect();

        DatabaseConnection reportingDb = DatabaseConnection.GetInstance("ReportingDB");
        reportingDb.Connect();

        // Aynı anahtar ile tekrar talep edildiğinde yeni nesne oluşturulmaz.
        DatabaseConnection samePrimaryDb = DatabaseConnection.GetInstance("PrimaryDB");
        samePrimaryDb.Connect();

        // Nesnelerin aynı olup olmadığını kontrol etme
        Console.WriteLine($"primaryDb ve samePrimaryDb aynı nesne mi? {Object.ReferenceEquals(primaryDb, samePrimaryDb)}"); // Çıktı: True
    }
}
#endregion

