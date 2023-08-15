// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using ReceiptScanningProgram.Models;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        int differenceCoordinate = 100;
        //veriler response.json dosyasından okunur.
        var filePath = Path.Combine(AppContext.BaseDirectory, "Json", "response.json");
        string jsonData = File.ReadAllText(filePath);

        List<TextInfo> textInfoList = JsonConvert.DeserializeObject<List<TextInfo>>(jsonData);

        //textInfoList.Remove(textInfoList[0]);

        //her veri min y, min x koordinatına göre sıralanır
        var sortedTextInfoList = textInfoList
            .Where(t => t.BoundingPoly.Vertices.LastOrDefault().Y - t.BoundingPoly.Vertices[0].Y <= differenceCoordinate)
            .OrderBy(info => info.BoundingPoly.Vertices.Min(vertex => vertex.Y))
            .ThenBy(info => info.BoundingPoly.Vertices.Min(vertex => vertex.X)).ToList();

        // Descriptionları koordinatlara göre gruplandırmak için dictionary kullanılır
        Dictionary<int, List<TextInfo>> groupedDescriptions = new();

        // Koordinat farkı eşik değeri
        int coordinateThreshold = 10;
        int j = 0, currentY = 0;
        List<TextInfo> list = new();

        for (int i = 0; i < sortedTextInfoList.Count; i++)
        {
            if (sortedTextInfoList[i].BoundingPoly.Vertices[0].Y - currentY > coordinateThreshold)
            {
                if (i != 0) groupedDescriptions.Add(j, list);

                j++;
                list = new List<TextInfo>();
            }

            list.Add(sortedTextInfoList[i]);
            if (sortedTextInfoList.Count - 1 == i) groupedDescriptions.Add(j, list);

            currentY = sortedTextInfoList[i].BoundingPoly.Vertices.Min(t => t.Y);
        }

        //gruplanan descriptionlar min x değeri bulunarak sıralanır ve ekrana yazdırılır
        foreach (var item in groupedDescriptions)
        {
            string description = string.Join(" ", item.Value.OrderBy(t => t.BoundingPoly.Vertices.Min(x => x.X))
                .Select(t => t.Description).ToList());

            Console.WriteLine(description);
        }
    }
}
