using System.Text.Json.Serialization;

namespace ApiCatalogo.Models
{
  public class Volume
  {
    public int VolumeId { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }

    [JsonIgnore]
    public ICollection<Produto>? Produtos { get; set; }
  }
}
