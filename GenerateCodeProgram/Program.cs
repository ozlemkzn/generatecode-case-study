// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        using (CancellationTokenSource cancellationTokenSource = new())
        {
            // İstenilen adet kod üretmek için GenerateCodes metodu çağrılır
            List<string> codes = GenerateCodes(1000, cancellationTokenSource.Token);

            // Oluşturulan kodlar ekrana yazdırılır
            foreach (string code in codes)
            {
                Console.WriteLine(code);
            }
        }
    }

    static List<string> GenerateCodes(int count, CancellationToken cancellationToken)
    {
        object syncRoot = new();
        HashSet<string> codes = new();

        //Paralel İşleme Eğer üreteceğiniz kod miktarı yüksekse ve işlemci çekirdekleri fazlaysa,
        //Parallel.ForEach veya Parallel.For kullanarak işlemleri paralel olarak gerçekleştirilir.
        //Bu, işlemi hızlandırabilir.
        Parallel.ForEach(Enumerable.Range(0, count), (i, loopState) =>
        {
            if (cancellationToken.IsCancellationRequested)
            {
                loopState.Break(); // Döngüyü sonlandır
                return;
            }

            string newCode = GenerateUniqueCode();

            lock (syncRoot)
            {
                if (codes.Add(newCode))  // Eğer eklemeyi başarırsa, zaten listede yok demektir.
                {
                    // Burada codes.Count'i kontrol ederek istediğiniz adet kod üretildiğinde döngüden çıkabilirsiniz.
                    if (codes.Count >= count)
                    {
                        loopState.Break(); // İstenen adet kod üretilir, döngüyü sonlandırır
                        return;
                    }
                }
            }
        });

        return codes.ToList(); // HashSet'i List'e çevirerek geri dönebiliriz.
    }

    /// <summary>
    /// Güvenilir bir rastgelelik sağlamak için kriptografik bir rastgele sayı üreteci kullanılabilir. 
    /// Bu, tahmin edilmesi çok daha zor bir kod üretimini sağlar
    /// </summary>
    /// <returns></returns>
    static string GenerateUniqueCode()
    {
        const string characterSet = "ACDEFGHKLMNPRTXYZ234579";
        using (RNGCryptoServiceProvider cryptoProvider = new())
        {
            byte[] data = new byte[8];
            cryptoProvider.GetBytes(data);
            StringBuilder result = new(8);

            foreach (byte b in data)
            {
                result.Append(characterSet[b % (characterSet.Length)]);
            }

            return result.ToString();
        }
    }

}
