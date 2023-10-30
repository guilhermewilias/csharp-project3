using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Threading.Channels;

void screensoundLogo()
{
    Console.WriteLine(@"

░█████╗░░░░██╗░██╗░  ░░░░░░  ██████╗░██████╗░░█████╗░░░░░░██╗███████╗░█████╗░████████╗  ██████╗░
██╔══██╗██████████╗  ░░░░░░  ██╔══██╗██╔══██╗██╔══██╗░░░░░██║██╔════╝██╔══██╗╚══██╔══╝  ╚════██╗
██║░░╚═╝╚═██╔═██╔═╝  █████╗  ██████╔╝██████╔╝██║░░██║░░░░░██║█████╗░░██║░░╚═╝░░░██║░░░  ░█████╔╝
██║░░██╗██████████╗  ╚════╝  ██╔═══╝░██╔══██╗██║░░██║██╗░░██║██╔══╝░░██║░░██╗░░░██║░░░  ░╚═══██╗
╚█████╔╝╚██╔═██╔══╝  ░░░░░░  ██║░░░░░██║░░██║╚█████╔╝╚█████╔╝███████╗╚█████╔╝░░░██║░░░  ██████╔╝
░╚════╝░░╚═╝░╚═╝░░░  ░░░░░░  ╚═╝░░░░░╚═╝░░╚═╝░╚════╝░░╚════╝░╚══════╝░╚════╝░░░░╚═╝░░░  ╚═════╝░");
}


//List<string> historicoBandas = new List<string>(); //criação de lista para registro de bandas
Dictionary<string, List<int>> historicoBandas = new Dictionary<string, List<int>>(); //Faz a adição das bandas (string) e a avaliação (int)


void opcoesMenu() //Função que vai abrir o menu e passar as condições.
{
    Console.WriteLine("\n\nDigite número 1 para registrar uma banda");
    Console.WriteLine("Digite número 2 para mostrar todas as bandas");
    Console.WriteLine("Digite número 3 para avaliar uma banda");
    Console.WriteLine("Digite número 4 para exibir a média de avaliações de uma banda");
    Console.WriteLine("Digite número -1 para sair");

    Console.Write("\n\nDigite a opção desejada --> "); //console.write escreve apenas o texto, sem pular linha
    string opcaoUsuario = Console.ReadLine()!;
    int opcaoUsuarioNumber = int.Parse(opcaoUsuario); //convertendo a string opcaoUsuario para INT --> então, int.parse transforma string em int em uma nova variável 


    switch (opcaoUsuarioNumber)
    {
        case 1:
            regisrarBanda(); //chama a função registrar banda
            break;

        case 2:
            registroHistoricoBandas(); //chama a função de bandas registradas
            break;

        case 3:
            avaliacaoBanda(); //chama  a função de avaliar bandas
            break;

        case 4:
            mediaAvaliacao(); 
            break;

        case -1:
            WaitForExit(); 
            break;

        default:
            Console.WriteLine("Opção digitada inválida, voltando ao menu em 3,2,1...  ");
            Thread.Sleep(2000);
            Console.Clear();
            opcoesMenu();

            break;
    }

    void regisrarBanda()
    { //Função que registra as bandas :

        Console.Clear(); //limpa o console
        Console.WriteLine("A opção selecionada por você foi a opção : Registrar uma banda (1)");
        Console.Write("Digite o nome da banda que você deseja registrar --> ");
        string nomeBanda = Console.ReadLine()!;
        historicoBandas.Add(nomeBanda, new List<int>()); //aqui está passando a banda digitada para a lista de historico 
        Console.WriteLine($"Nome de banda registrado : {nomeBanda}"); //Interpolação (própia ide sugeriu)

        Console.WriteLine("\n\nTecle qualquer coisa para retornar ao menu");
        Console.ReadKey(); //Entende que q alguma tecla foi pressionada 
        Console.Clear(); //limpa o console
        opcoesMenu(); //volta  o menu principal
    }

    void registroHistoricoBandas()
    {
        Console.Clear();
        Console.WriteLine("Lista de todas as bandas registradas : ");

        /*
        for (int i = 0; i < historicoBandas.Count; i++)
        {
            Console.WriteLine($"\nBanda : {historicoBandas[i]}");
        }
        */

        foreach (string banda in historicoBandas.Keys)
        {
            Console.WriteLine($"Banda registrada : {banda}");
        }

        Console.WriteLine("\n\nTecle qualquer coisa para retornar ao menu");
        Console.ReadKey();
        Console.Clear(); //limpa o console
        opcoesMenu(); //volta ao menu principal
    }

    void avaliacaoBanda()
    {
        Console.Clear();

        Console.WriteLine("Avaliar uma banda : ");
        Console.WriteLine("Digite o nome da banda que você deseja avaliar --> ");
        string nomeDaBanda = Console.ReadLine()!; //Permite o usuário digitar o nome da banda - e cria uma var para hospedar.

        if (historicoBandas.ContainsKey(nomeDaBanda))
        {
            Console.WriteLine($"\nQue nota você gostaria de dar para a banda {nomeDaBanda}?");
            int notaAvaliacaoBanda = int.Parse(Console.ReadLine()!); //Converteu a nota armazenada em int para string para o console.readline conseguir funcionar
            historicoBandas[nomeDaBanda].Add(notaAvaliacaoBanda); //atribui uma nota para a banda

            Console.WriteLine($"\n\nA nota {notaAvaliacaoBanda} foi salva para a banda {nomeDaBanda}. ");

            Console.WriteLine("\n\nTecle qualquer coisa para retornar ao menu");
            Console.ReadKey(); //Entende que q alguma tecla foi pressionada
            Console.Clear(); //limpa o console
            opcoesMenu(); //volta ao menu principal
        }
        else
        {
            Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada/não foi registrada!");
            Console.WriteLine("\n\nTecle qualquer coisa para retornar ao menu");
            Console.ReadKey(); //Entende que q alguma tecla foi pressionada
            Console.Clear(); //limpa o console
            opcoesMenu(); //volta ao menu principal
        }
    }

    void mediaAvaliacao()
    {
        Console.Clear();


        Console.WriteLine("Exibir a media da banda : ");
        Console.WriteLine("Digite o nome da banda que você deseja ver a media --> ");
        string nomeDaBanda = Console.ReadLine()!;

        if (historicoBandas.ContainsKey(nomeDaBanda))
        {
            List<int> notasDaBanda = historicoBandas[nomeDaBanda];
            Console.WriteLine($"A media da banda {nomeDaBanda} é {notasDaBanda.Average()}"); //AVERAGE = FAZ MÉDIA!
            Console.WriteLine("\n\nTecle qualquer coisa para retornar ao menu");
            Console.ReadKey(); //Entende que q alguma tecla foi pressionada
            Console.Clear(); //limpa o console
            opcoesMenu(); //volta ao menu principal
        }
        else
        {
            Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada/não foi registrada!");
            Console.WriteLine("\n\nTecle qualquer coisa para retornar ao menu");
            Console.ReadKey(); //Entende que q alguma tecla foi pressionada
            Console.Clear(); //limpa o console
            opcoesMenu(); //volta ao menu principal
        }
    }
    /* object GetCurrentProcess(bool v)
    {
        throw new NotImplementedException();
    }*/


    void WaitForExit()
    {
        Console.Clear();
        Console.WriteLine("Você selecionou a opção de fechar o programa.... Fechando em 3,2,1...");

        // Console.WriteLine("\nTecle qualquer coisa para fechar o programa");
        Thread.Sleep(2000);
        var program = new Process()
        {
            StartInfo =
            {
                FileName = "Program",
                WorkingDirectory = @"C:\Users\guilherme.sousa\Desktop\ScreenSound03-projeto-inicial\ScreenSound\bin\Debug\net6.0",
                Arguments = "& exit"
            }
        };
        program.Start();
       

        /*var p = new Process()
        {
            StartInfo =
            {
                FileName = "Program",

                WorkingDirectory = @"C:\Users\guilherme.sousa\Desktop\ScreenSound03-projeto-inicial\ScreenSound\bin\Debug\net6.0",

                Arguments = "& exit"
            }
        };
        p.Start();*/
    }
}
screensoundLogo(); //Chama a função para exibir a mensagem de boas vindas.
opcoesMenu(); //Chama a opção que exibe o menu e suas condições.