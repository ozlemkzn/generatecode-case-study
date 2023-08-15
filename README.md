# Unique Code Generator

Bu proje, güvenilir rastgele kodlar üretmek için kullanılan bir C# konsol uygulamasını içerir. Çalışan işlemleri paralel olarak kontrol etmek ve istenen adet kod üretimini gerçekleştirmek için `CancellationTokenSource` ve `Parallel.ForEach` kullanılır.

## Nasıl Kullanılır

1. Projeyi klonlayın veya ZIP olarak indirin.

2. Proje klasörüne gidin ve `.sln` dosyasını Visual Studio veya başka bir C# derleyici ile açın.

3. `Program.cs` dosyasını açarak ana kodu inceleyin. 

4. Çalıştırmak istediğiniz kod adedini ayarlayın.

5. Uygulamayı derleyin ve çalıştırın.

## Kodun İşleyişi

Ana kod parçacığı, istenen adette benzersiz kod üretmek ve sonuçları ekrana yazdırmak için `GenerateCodes` fonksiyonunu çağırır.

`GenerateCodes` fonksiyonu, `Parallel.ForEach` kullanarak işlemleri paralel olarak gerçekleştirir. Bu, kod üretim işlemini hızlandırabilir. Ayrıca, `CancellationToken` kullanarak işlemleri izlemek ve gerektiğinde iptal etmek mümkündür.

Üretilen kodlar, `codes` koleksiyonunda tutulur ve sonunda ekrana yazdırılır.

## Örnek Kod Üretimi

Kod üretimi, `GenerateUniqueCode` fonksiyonu aracılığıyla gerçekleştirilir. Bu fonksiyon, rastgele karakterler kullanarak tahmin edilmesi zor kodlar üretir.

# JSON Veri Analizi

Bu proje, JSON formatındaki verileri analiz eden bir uygulamayı içerir. Veriler response.json dosyasından okunur, sıralanır ve gruplandırılarak çıktı üretilir.

## Nasıl Kullanılır

1. `response.json` dosyasını projenizin `Json` klasörüne ekleyin. Bu dosya içinde analiz edilecek veriler bulunmalıdır.

2. `Program.cs` dosyasındaki `Main` fonksiyonunda, verilerin analiz edilmesi için gerekli işlemler bulunmaktadır. Bu işlemleri inceleyerek örneklerinizi projeye adapte edebilirsiniz.

## Proje Detayları

- Veriler `response.json` dosyasından okunur ve belirli bir koordinat farkı eşik değerine göre sıralanır.

- Aynı koordinat yüksekliğine sahip olan veriler gruplandırılır ve bu gruplamaların içindeki description'lar min x değerine göre sıralanarak ekrana yazdırılır.

## Gereksinimler

- Bu proje [Json.NET](https://www.newtonsoft.com/json) kütüphanesini kullanmaktadır. Bu nedenle projeyi çalıştırmadan önce bu kütüphaneyi yüklemeniz gerekebilir.

## Lisans

Bu proje MIT lisansı altında dağıtılmaktadır. Daha fazla bilgi için MIT-LICENSE.txt dosyasını inceleyebilirsiniz.