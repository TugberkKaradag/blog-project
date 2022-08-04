
BLOG PROJESİ - 5432 

*  Blank Solution olarak projemizi oluştuduk , oluşturacağımız her bir farkl katmanı farklı prje tipi olarak ekleyip devam edeceğiz.

*  Solution altına ilk etapta sınıfları oluşturacağımız MODEL katmanını (class library) ekleyeceğiz.

*  MODELS => Entities klasörü açılır. Abstract ve Concrete klasörleri altına uygulamada kullanacağımız sınıflar eklenir.

*  MODELS => Enums kalsörü => uygulamada kullnılacak enum yapıları ayrıca depolanır.

*  MODELS => EntityTypeConfiguration klasörü => uyguamada kullanılan sınıfların veritabanındaki ilişkileri/tabloları için gerekli konfigurasyonlar yapılır.

NOT => Configuration için efcore.sqlServer paketi gerekli olacak.
       Mapleme işlemlerinde IDENTITY kütühanesinden destek alacağımız için mic.extension.identity.strores paketine ihtiyacımız olarak.
       IFormFile propertysi için efcore.http.features paketi gerekli.

*  *  *  *  *  *  *  *  *  * 

2.DATA ACCESS LAYER ( DAL )

olarak adlandıracağımız veriye erişim katmanında bizi veriTabanına bağlayacak olan Context sınıfımıızı ve Repolarımızı yazacğız. Bu yüzden Class Library olarak bu katmanı açmamız yeterli olacaktır.

*  Solution altına Class Library Prpjesi ekledikten sonra

* DAL => Context klasörü altına ProjecCotext sınıfını oluşturuyoruz.
* DAL => Repository klasörü => Abstract - Concrete - Interfaces olmak üzere repolarımı da parçalayacağım.

 NOT => Gerekiyorsa ki gerekecektir MODEL katmanı ihtiyaç anında referans verilebilir.
       Gerekli olan mic.efcore tools/sqlServer/aspnetcore.identity paketleri ihtiyaç anında yüklenebilir.
       Bu projede context sınıfı İdentityDbContextten kalıtım alacağı için DbSetlerde belirttiğimiz sınıflardan çok daha fazlası veritabanı tarafında oluşacaktır.

*  *  *  *  *  *  *  *  *  *

3.Kullanıcı ile iletişime geçeceğimiz web katmanı için (Uİ katmanı da denir) ASPNET CORE WEB APP (Model -View - Controller) projemizi açtık.

Göç başlatacağız bunun için önce appsettingJsona connectionStrigimizi yazalım ve StartUpda söyleyelim.

Göç aşamasında package manager console da : default proje: contextin olduğu proje + dizinde web katmanı seçili olmalı.

Göç için efcore.design ve tools paketini kullanıyoruz.

add-migration isim ve update-database yapılır.

* Areas klasörünü açalım. => add- area - mvc area - isim verilir ve alan açılmış olur.
StartUp içindeki endPoint düzenlenmeli.
NOT !!!  => AREA içinde açılan Controllera muhakkak [Area("isim")] attribute eklenmeli yoksa çalışmaz.

* Projede identity kütüphanesi kullanıdığı starUpda söylenmeli.

* İlk etapta kullanıcı kayıt etmek ve devamında içeri giriş yapailmesi için area ya ulaşmadan globadeki mvc yi kullanacağız. Sonrasında login işlemleri başarılı olan kullanıcıyı area içine almış olacağız.

* Controllerlarda kullandığımız repoların soyut hallerini constructorda çağııldığında concrete hallerinin gelmesi için startUp içinde gömülü metotlardan faydalanarak IOC prensibini yerine getirmiş olacağız.

* İhtiyacımız olduğunda Mapper kütüphanesi için => AutoMapper + AutoMapper.Mic.DI ( startUpda mapper kütühanesi metotları kullanıraka yaptırılan mapleme işlemleri için bir sınıf açıp bunu startUpda söyleyeceğiz.)

* Kullanıcı fotoğraf yükleeme işlemleri için => SixLabors.ImageSharp + SixLabors.ImageSharp.web