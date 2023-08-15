using System.Text.Json.Serialization;

namespace ReceiptScanningProgram.Models
{
    public class BoundingPoly
    {
        [JsonPropertyName("vertices")]
        public List<Vertex> Vertices { get; set; }
    }

    public class Vertex
    {
        [JsonPropertyName("x")]
        public int X { get; set; }
        [JsonPropertyName("y")]
        public int Y { get; set; }
    }

    public class TextInfo
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("boundingPoly")]
        public BoundingPoly BoundingPoly { get; set; }
    }
}
