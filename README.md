# Taş Kağıt Makas Online

Taş Kağıt Makas oyununun, .NET Socket teknolojisi ile Multiplayer hale getirilmiş versiyonu.

For Test Client: [Click Here!](https://www.mediafire.com/file/4gczid1e2zo0kc3/TasKagitMakasClient.zip)

Compiled With: **Visual Studio 2019 Community**

**Oyunun Yapısı**

- Oyun, 1 VS 1 oynanabilen bir yapıya sahiptir. 
- Kolay anlaşılabilen ve kullanıcı dostu bir arayüze sahiptir.

**İstemci Senaryosu**

- İstemci ilk açılışta, sunucu ile bağlantı kurmayı dener. Bu işlem, bağlantı problemleri oluştuğunda 20 saniye kadar sürebilir. Bağlantı denemeleri devam ettiği sürece aşağıdaki ekran kullanıcıya gösterilir.

![](https://raw.githubusercontent.com/horriblebyte/TasKagitMakasOnline/master/Introduction/1.gif)

- Bu süre sonunda eğer bağlantı gerçekleşmezse, istemci; sunucuya bağlanamadığının bilgisini verir ve kendini kapatır.

![](https://raw.githubusercontent.com/horriblebyte/TasKagitMakasOnline/master/Introduction/2.PNG)

- Sunucuyla başarılı bir bağlantı kurulduğu anlaşıldığında, istemci sunucudan bir oda kodu talep eder ve oda kodunu aldığında ekrana yazarak kullanıcıyı bilgilendirir. Bu ekranda kullanıcı kendi oda kodunu paylaşarak bir arkadaşını kendi odasına davet edebilir ya da arkadaşının paylaşmış olduğu oda kodunu alarak onun odasına katılabilir.

![](https://raw.githubusercontent.com/horriblebyte/TasKagitMakasOnline/master/Introduction/3.PNG)

- Kullanıcı herhangi bir odaya katıldığında ya da kendi odasına farklı bir kullanıcı katıldığında, sunucu odadaki tüm istemcilere oyun başladı paketini gönderir ve odadaki istemcilerde oyun ekranı gösterilir. Bu ekranda bir hamle seçimi yapılması gerekir.

![](https://raw.githubusercontent.com/horriblebyte/TasKagitMakasOnline/master/Introduction/4.PNG)

- Hamle seçimi yapıldıktan sonra eğer rakip halâ hamle seçimi yapmamışsa, rakibin beklendiğini temsil eden ekran kullanıcıya gösterilir.

![](https://raw.githubusercontent.com/horriblebyte/TasKagitMakasOnline/master/Introduction/5.gif)

- Rakip seçim yaptıktan sonra oyunun final ekranı açılır. Final ekranda kullanıcı, kimin kazanıp kaybettiğini, rakibinin hamlesini ve skorunu öğrenebilir. 

- Kazandığında aşağıdaki ekran gösterilir.

![](https://raw.githubusercontent.com/horriblebyte/TasKagitMakasOnline/master/Introduction/6.PNG)

- Kaybettiğinde aşağıdaki ekran gösterilir.

![](https://raw.githubusercontent.com/horriblebyte/TasKagitMakasOnline/master/Introduction/7.PNG)

- Durum berabere olduğunda aşağıdaki ekran gösterilir.

![](https://raw.githubusercontent.com/horriblebyte/TasKagitMakasOnline/master/Introduction/8.PNG)

- Oyun esnasında rakip oyuncu oyundan ayrıldığında, odadaki oyuncuya aşağıdaki bilgilendirme mesajı gösterilir.

![](https://raw.githubusercontent.com/horriblebyte/TasKagitMakasOnline/master/Introduction/9.PNG)

- Oyun esnasında bağlantıda herhangi bir problem olduğunda aşağıdaki bilgilendirme mesajı gösterilir ve istemci kendini kapatır.

![](https://raw.githubusercontent.com/horriblebyte/TasKagitMakasOnline/master/Introduction/10.PNG)

- Uygulama kapatılmaya çalışıldığında aşağıdaki diyalog penceresi gösterilir. Evet cevabı verilirse istemci kendini kapatır. 

![](https://raw.githubusercontent.com/horriblebyte/TasKagitMakasOnline/master/Introduction/11.PNG)

- Uygulamanın konseptine uygun olması düşüncesiyle bu tarz mesajlar standart MessageBox ile değil, DialogBox görevi gören bir Form aracılığıyla gösterilmiştir.

Okuduğunuz için teşekkürler.
