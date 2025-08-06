#region Tanımlar -Açıklamalar
/*
 Uygulama bazında bir sınıfın sadece tek bir instance'ını kullanmamızı sağlayan tasarım desenidir.

Singletonu patternı tercıh etmemızın sebebı yazılımcının ıradesıyle ılgılı sınıftan bır nesne olusturulmasını engellemektir.


Lehte ve Aleyhte yönleri:
-Lehte:Bir sınıfın yalnızca tek bır ornegı oldugundan emın olabılırsınız
-Ilgılı sınıfın singleton ınstanceına uygulama capında erısım noktası kazanmıs olursunuz
-Singleton nesnesini yalnızca ılk talep edıldıgınde uretılır sonrakı surecte uretılmıs olan bu nesne kullanılmaya devsam edilir.


Aleyhte:Bu pattern aynı anda ıkı sorunu cozdugu ıcın tek sorumluluk ılkesını ıhlal eder.Hem nesne uretır hem de nesneye erısım noktası kazandırır.
-!!!! Bu pattern asenkron sureclerde bırden fazla ınstance olusturabılme ıhtımalıne sahıptır.Bundan dolayı ozel bır ıslem gerektırmektedır
--Constructor erısılemez olacagından dolayı unit testlerde sıkıntı yaşanabilir.


 
 */
#endregion



#region Example  1.Yöntem Singleton  Design Pattern

////constructoru public yaparsak, dışarıdan newleyebiliriz.
////new Example();
////new Example();
////new Example();
////new Example();
////new Example();

////birkez oluşturulur ve tekrar tekrar kullanılır.
//Example ex = Example.GetInstance;
//Example ex2 = Example.GetInstance;
//Example ex3 = Example.GetInstance;
//Example e4 = Example.GetInstance;



//class Example
//{

//    private Example()//constructoru private yaparak dışarıdan erişimi engelliyoruz.tekrar tekrar newlenememsi için bu 1.adım
//    {
//        Console.WriteLine($"{nameof(Example)} nesnesi oluşturuldu");
//    }

//    static Example _instance; //2.adım: private static bir field tanımlıyoruz. Bu field singleton instance'ı tutacak.
//    public static Example GetInstance { get 
//        {

//            if (_instance == null) //3.adım: Eğer instance null ise, yeni bir örnek oluştur.
//            {
//                _instance = new Example();
//            }
//            return _instance; //4.adım: Singleton instance'ı döndür.
//        } }
//}


#endregion