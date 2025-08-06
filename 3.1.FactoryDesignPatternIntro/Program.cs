#region Tanimlar giris..

/*
 
 Creational Design Pattern deyince,nesne üretim süreçlerinde davranışlarımızı modellendiren tasarım desenleridir.

Kısaca Factory Design Pattern,operasyon sureclerınde uretılecek nesnelerın turu sınıfı referansı yerıne sadece kendilerine odaklanıp ıslemlerımızı devam ettırmek ıstedıgımız durumlarda kullanılan bır stratejidir.

Anoloji olarak ,starbucks'da kahvenın turuyle ılgılenmezsın ne ıstedıgını soyler muhabbete devam edersin.


Factory Design Pattern: En Basit Haliyle Nedir?
Bu deseni aklınızda canlandırmak için bir pizza dükkanı düşünün.

Siz müşteri olarak kasaya gidip "Bir Margherita pizza istiyorum" dersiniz. Sizin için önemli olan, siparişinizin türünü (Margherita) söylemek ve sonunda bir pizza almaktır. Pizzanın hamurunun nasıl açıldığı, fırının kaç derecede çalıştığı veya üzerine hangi malzemelerin hangi sırayla konulduğu sizi ilgilendirmez.

İşte Factory Pattern tam olarak budur! Sizin kodunuz (müşteri), nesneye doğrudan "seni new ile yaratıyorum" demez. Bunun yerine bir Fabrika'ya gider ve "Bana şu tipten bir nesne ver" der. Fabrika, o nesneyi yaratmanın tüm karmaşık detaylarını (kurulum, başlangıç değerleri vs.) kendisi halleder ve size hazır, kullanılabilir bir nesne sunar.

Kısacası: Factory Pattern, nesne yaratma sorumluluğunu, nesneyi kullanacak olan koddan alıp, bu işe özel bir "Fabrika" sınıfına devreder.


Hangi Problemi Çözer?
Temel amacı, kodunuzun esnek ve genişletilebilir olmasını sağlamaktır.

Eğer fabrikanız olmasaydı, kodunuzun içinde şöyle satırlar olurdu:
 

if (odemeTipi == "KrediKarti") {
    KrediKarti odeme = new KrediKarti();
    odeme.IslemYap();
} else if (odemeTipi == "Havale") {
    Havale odeme = new Havale();
    odeme.IslemYap();
}

Sorun: Yarın sisteme "Kripto Para" ile ödeme eklemek isterseniz, bu if-else bloğunu bulup değiştirmeniz gerekir. Bu, "Open/Closed Prensibi"ne (Kod genişlemeye açık, değişime kapalı olmalı) aykırıdır.
Factory Pattern bu problemi çözer. Siz sadece fabrikanıza yeni bir ürün yapmayı öğretirsiniz, müşteri koduna ise hiç dokunmazsınız.
 
 */
#endregion

#region Örnek

/*
 C# ile Basit Bir Örnek
Senaryomuz, farklı ödeme yöntemleri oluşturan bir fabrika olsun.

1. Adım: Ortak Bir Arayüz (Product Interface)
Tüm ödeme yöntemlerimizin uyması gereken bir kontrat (şablon) belirliyoruz.
 */

// Ürün Arayüzü (Product)
// Bütün ödeme yöntemlerinin bu metodu olmalı.
public interface IOdemeYontemi
{
    void OdemeyiYap();
}

//2.Adım: Somut Sınıflar(Concrete Products)
//Bu arayüzü kullanan gerçek ödeme yöntemlerini oluşturuyoruz.

// Somut Ürün 1 (Concrete Product)
public class KrediKarti : IOdemeYontemi
{
    public void OdemeyiYap()
    {
        Console.WriteLine("Ödeme Kredi Kartı ile yapıldı.");
    }
}

// Somut Ürün 2 (Concrete Product)
public class Havale : IOdemeYontemi
{
    public void OdemeyiYap()
    {
        Console.WriteLine("Ödeme Havale/EFT ile yapıldı.");
    }
}

// Somut Ürün 3 (Concrete Product)
public class KriptoPara : IOdemeYontemi
{
    public void OdemeyiYap()
    {
        Console.WriteLine("Ödeme Kripto Para ile yapıldı.");
    }
}

// Somut Ürün 4 (Concrete Product)
public class PayPal : IOdemeYontemi
{
    public void OdemeyiYap()
    {
        Console.WriteLine("Ödeme Paypal ile yapıldı.");
    }
}

//3.Adım: Fabrika Sınıfı(Factory)
//İşte sihrin gerçekleştiği yer! Gelen talebe göre doğru nesneyi yaratan sınıf.

// Hangi tipte ödeme yapılacağını belirtmek için bir enum kullanalım.
public enum OdemeTipi
{
    KrediKarti,
    Havale,
    KriptoPara,
    PayPal
}

// Fabrika Sınıfı (Creator/Factory)
public class OdemeYontemiFactory
{
    public IOdemeYontemi CreateOdemeYontemi(OdemeTipi tip)
    {
        switch (tip)
        {
            case OdemeTipi.KrediKarti:
                return new KrediKarti();
            case OdemeTipi.Havale:
                return new Havale();
            case OdemeTipi.KriptoPara:
                return new KriptoPara();
            case OdemeTipi.PayPal:
                return new PayPal();
            default:
                throw new NotSupportedException($"{tip} desteklenen bir ödeme yöntemi değildir.");
        }
    }
}


//4.Adım: Müşteri Kodunun Kullanımı (Client)
//Artık ana kodumuz new KrediKarti() gibi ifadelerle kirlenmeyecek. Sadece fabrikadan nesne isteyecek.


public class Program
{
    public static void Main(string[] args)
    {
        // Fabrikamızı oluşturuyoruz.
        OdemeYontemiFactory factory = new OdemeYontemiFactory();

        // Müşteri kredi kartı ile ödeme yapmak istiyor.
        // Hangi sınıfın yaratıldığını bilmiyor, sadece bir "IOdemeYontemi" istiyor.
        IOdemeYontemi odemeYontemi1 = factory.CreateOdemeYontemi(OdemeTipi.KrediKarti);
        odemeYontemi1.OdemeyiYap(); // Çıktı: Ödeme Kredi Kartı ile yapıldı.

        // Başka bir müşteri havale yapmak istiyor.
        IOdemeYontemi odemeYontemi2 = factory.CreateOdemeYontemi(OdemeTipi.Havale);
        odemeYontemi2.OdemeyiYap(); // Çıktı: Ödeme Havale/EFT ile yapıldı.

        IOdemeYontemi odemeYontemi4 = factory.CreateOdemeYontemi(OdemeTipi.PayPal);
        odemeYontemi4.OdemeyiYap();

        // Yarın sisteme yeni bir ödeme yöntemi eklediğimizde burayı DEĞİŞTİRMEYECEĞİZ!
    }
}


/*
 Bu Desenin Faydaları
Esneklik: Sisteme yeni bir ödeme yöntemi (PayPal diyelim) eklemek istediğinizde, Program.cs'e dokunmazsınız. Sadece PayPal sınıfını ve enum'a yeni bir değer ekleyip, fabrikanın switch bloğunu güncellemeniz yeterlidir.

Merkezi Kontrol: Nesne oluşturma mantığı tek bir yerde (OdemeYontemiFactory) toplanır. Bu, yönetimi ve hata ayıklamayı kolaylaştırır.

Bağımlılıkları Azaltma (Decoupling): Müşteri kodu (Program.cs), somut sınıflara (KrediKarti, Havale) değil, sadece arayüze (IOdemeYontemi) bağımlıdır. Bu, kodun daha temiz ve modüler olmasını sağlar.

Mülakat İçin İpuçları
Problemi Anlatarak Başlayın: "Factory Pattern, nesne yaratma mantığını ana koddan ayırarak, kodun new anahtar kelimesi gibi somut sınıf bağımlılıklarından kurtulmasını sağlar. Bu da bize esneklik kazandırır."

Analojiyi Kullanın: Pizza dükkanı veya araba fabrikası gibi basit bir analoji, konuyu ne kadar iyi anladığınızı gösterir.

Temel Faydasını Vurgulayın: "En büyük faydası, Open/Closed Prensibi'ni desteklemesidir. Kodumuz yeni ödeme yöntemleri eklemeye (genişlemeye) açık, ancak mevcut müşteri kodunu değiştirmeye (değişime) kapalı hale gelir."

Kodu Anlatırken: "Burada bir IOdemeYontemi arayüzümüz var. Müşteri kodu sadece bu arayüzü tanır. Fabrika sınıfı ise, gelen parametreye göre bu arayüzü implemente eden KrediKarti veya Havale gibi somut sınıflardan birini yaratıp müşteriye döner."

Bu bilgilerle mülakatta Factory Pattern sorusunu rahatlıkla cevaplayabilirsiniz. Başarılar
 
 */
#endregion