using ScreenSound.modelos;

namespace screensound.modelos;
internal class Banda
{
    private List<Album> albuns = new List<Album>();
    private List<avaliacao> notas = new List<avaliacao>();

    public Banda(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; }
    public double Media => notas.Average(a => a.Nota);
    public List<Album> Albuns => albuns;

    public void AdicionarAlbum(Album album) 
    { 
        albuns.Add(album);
    }

    public void AdicionarNota(avaliacao nota)
    {
        notas.Add(nota);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"Discografia da banda {Nome}");
        foreach (Album album in albuns)
        {
            Console.WriteLine($"Álbum: {album.Nome} ({album.DuracaoTotal})");
        }
    }
}