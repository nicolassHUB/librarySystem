using System;
using System.Collections.Generic;

class Livro
{
    private int ID;
    private string Titulo;
    private string Autor;
    private string _Ano;

    private string Ano
    {
        get { return _Ano; }
        set
        {
            if (value != null && value.Length > 4)
                _Ano = value.Substring(0, 4);
            else
                _Ano = value;
        }
    }

    private int Quantidade;

    // LISTA GLOBAL (precisava existir)
    public static List<Livro> livros = new List<Livro>();

    public Livro(int id, string titulo, string autor, string ano, int qtd)
    {
        this.ID = id + 1;
        this.Titulo = titulo;
        this.Autor = autor;
        this.Ano = ano;
        this.Quantidade = qtd;
    }

    public static void Cadastrar()
    {
        int opcao = 1;

        while (opcao == 1)
        {
            Console.WriteLine("==== CADASTRAR LIVRO ====");

            Console.Write("Digite o título: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite o autor: ");
            string autor = Console.ReadLine();

            Console.Write("Digite o ano: ");
            string ano = Console.ReadLine();

            Console.Write("Digite a quantidade: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            int id = livros.Count;

            Livro novoLivro = new Livro(id, titulo, autor, ano, quantidade);
            livros.Add(novoLivro);

            Console.WriteLine("\nLivro cadastrado com sucesso!");

            Console.WriteLine("\n(1) - Cadastrar outro");
            Console.WriteLine("(2) - Sair");

            opcao = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
        }
    }

    public static void Listar()
    {
        Console.WriteLine("==== LISTA DE LIVROS ====");

        for (int i = 0; i < livros.Count; i++)
        {
            Console.WriteLine((i + 1) + " - " +
                livros[i].Titulo + " | " +
                livros[i].Autor + " | " +
                livros[i].Ano + " | Qtd: " +
                livros[i].Quantidade);
        }
    }

    public static void Atualizar()
    {
        Console.WriteLine("==== ATUALIZAR ====");

        for (int i = 0; i < livros.Count; i++)
        {
            Console.WriteLine((i + 1) + " - " + livros[i].Titulo);
        }

        Console.WriteLine("Escolha um livro:");
        int escolha = Convert.ToInt32(Console.ReadLine());
        int index = escolha - 1;

        if (index >= 0 && index < livros.Count)
        {
            Console.WriteLine("(1) Título");
            Console.WriteLine("(2) Autor");
            Console.WriteLine("(3) Ano");
            Console.WriteLine("(4) Quantidade");

            int op = Convert.ToInt32(Console.ReadLine());

            if (op == 1)
            {
                Console.Write("Novo título: ");
                livros[index].Titulo = Console.ReadLine();
            }
            else if (op == 2)
            {
                Console.Write("Novo autor: ");
                livros[index].Autor = Console.ReadLine();
            }
            else if (op == 3)
            {
                Console.Write("Novo ano: ");
                livros[index].Ano = Console.ReadLine();
            }
            else if (op == 4)
            {
                Console.Write("Nova quantidade: ");
                livros[index].Quantidade = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Atualizado!");
        }
        else
        {
            Console.WriteLine("Inválido!");
        }
    }

    public static void RegistrarVenda(Usuario[] usuarios)
    {
        Console.WriteLine("==== REGISTRAR VENDA ====");

        Listar();

        Console.WriteLine("Escolha um livro:");
        int l = Convert.ToInt32(Console.ReadLine()) - 1;

        Console.WriteLine("Escolha um usuário:");
        for (int i = 0; i < usuarios.Length; i++)
        {
            Console.WriteLine((i + 1) + " - " + usuarios[i].Nome);
        }

        int u = Convert.ToInt32(Console.ReadLine()) - 1;

        Console.WriteLine("Quantidade:");
        int qtd = Convert.ToInt32(Console.ReadLine());

        if (l >= 0 && l < livros.Count && u >= 0 && u < usuarios.Length)
        {
            if (livros[l].Quantidade >= qtd)
            {
                livros[l].Quantidade -= qtd;
                usuarios[u].Livros_Emprestados += qtd;

                Console.WriteLine("Venda registrada!");
            }
            else
            {
                Console.WriteLine("Sem estoque!");
            }
        }
    }

    public static void ListarVenda(Usuario[] usuarios)
    {
        Console.WriteLine("==== LISTA DE VENDAS ====");

        for (int i = 0; i < usuarios.Length; i++)
        {
            Console.WriteLine(usuarios[i].Nome + " - Livros: " + usuarios[i].Livros_Emprestados);
        }
    }
}
class Usuario
{
    public int ID;
    public string Nome;
    public string CPF;
    public string Ano;
    public int Livros_Emprestados;
}
public class HelloWorld
{
public static void Main(string[] args)
{
    Usuario[] usuarios = new Usuario[2];

    usuarios[0] = new Usuario { Nome = "João", CPF = "123" };
    usuarios[1] = new Usuario { Nome = "Maria", CPF = "456" };

    int op = 0;

    while (op != 6)
    {
        Console.WriteLine("\n==== SISTEMA DE BIBLIOTECA ====");
        Console.WriteLine("1 - Cadastrar Livro");
        Console.WriteLine("2 - Listar Livros");
        Console.WriteLine("3 - Atualizar Livro");
        Console.WriteLine("4 - Registrar Venda");
        Console.WriteLine("5 - Listar Vendas");
        Console.WriteLine("6 - Sair");

        op = Convert.ToInt32(Console.ReadLine());

        if (op == 1) Livro.Cadastrar();
        else if (op == 2) Livro.Listar();
        else if (op == 3) Livro.Atualizar();
        else if (op == 4) Livro.RegistrarVenda(usuarios);
        else if (op == 5) Livro.ListarVenda(usuarios);
    }
}
}