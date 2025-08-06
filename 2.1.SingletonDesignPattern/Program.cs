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