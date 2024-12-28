using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using ExercicioPratico;

Console.WriteLine($"{Cores.Branco} - {(int)Cores.Branco}");
Console.WriteLine($"{Cores.Vermelho} - {(int)Cores.Vermelho}");
Console.WriteLine($"{Cores.Preto} - {(int)Cores.Preto}");
Console.WriteLine($"{Cores.Cinza} - {(int)Cores.Cinza}");
Console.WriteLine($"{Cores.Prata} - {(int)Cores.Prata}");
Console.WriteLine($"{Cores.Azul} - {(int)Cores.Azul}");
Console.WriteLine("\nSelecione a Cor do carro");
int cor = Convert.ToInt32(Console.ReadLine());
//chevrolet

Console.WriteLine((Cores)cor);  // Exibe a cor corretamente, como "Cinza" se o valor for 4

cor = (int)(Cores)cor;
Carro chevrolet = new("Sedan", "Chevrolet", "Onix", 2016, 110, cor);
chevrolet.Acelerar(chevrolet.Marca);
chevrolet.ExibirInfo(chevrolet.Modelo, chevrolet.Montadora, chevrolet.Marca,
chevrolet.Potencia, chevrolet.Cor);


Console.WriteLine($"{chevrolet.Modelo} {chevrolet.Montadora} {chevrolet.Marca}" +
$" {chevrolet.Ano} {chevrolet.Potencia} CV");
Console.WriteLine("Aumentando a Potencia (por valor : + 3CV) : ");
var novaPotenciaChevrolet = chevrolet.AumentarPotencia(chevrolet.Potencia);
Console.Write("-> " + novaPotenciaChevrolet);
Console.WriteLine("\nO valor do campo Potencia não foi alterado : " + chevrolet.Potencia);

double novaPotencia = chevrolet.AumentarPotenciaVelocidade(chevrolet.Potencia, out double velocidade);
Console.WriteLine("-Nova Potencia : " + novaPotencia);
Console.WriteLine("-Nova Velocidade Máxima : " + velocidade);

Carro ford = new("SUV", "Ford", "EcoSport", 2018, 120, cor);
ford.Acelerar(ford.Marca);

Console.WriteLine($"{ford.Modelo} {ford.Montadora} {ford.Marca}" +
$" {ford.Ano} {ford.Potencia} CV");
var novaPotenciaFord = ford.AumentarPotencia(ref ford.Potencia);
Console.Write("-> " + novaPotenciaFord);
Console.WriteLine("\nO valor do campo Potencia foi alterado : " + ford.Potencia);

Console.WriteLine("\nUsando argumentos nomeados e parâmetros opcionais \n");
Console.WriteLine("Sem informar o parâmetro opcional Ano");
ford.ExibirInfo(Modelo: ford.Modelo, Montadora: ford.Montadora,
Marca: ford.Marca, Potencia: ford.Potencia);

Console.WriteLine("\nInformando o parâmetro opcional Ano");
ford.ExibirInfo(Modelo: ford.Modelo, Montadora: ford.Montadora,
Marca: ford.Marca, Potencia: ford.Potencia, Ano: ford.Ano);

Console.WriteLine("Chamando o método estático ObterValorIPVA : ");

Carro.ObterValorIpva();

Console.WriteLine("Valor do campo ValorIpva : " + Carro.ValorIpva + "%");

//struct
Cliente cliente = new("Juan", "juan@email.com", 19);
Cliente.ExibirInfo(email: cliente.Email, nome: cliente.Nome, idade: cliente.Idade);
Console.WriteLine("\nExibindo informação sem informar a idade");
Cliente.ExibirInfo(email: cliente.Email, nome: cliente.Nome);



Console.ReadKey();

public class Carro
{
    public string? Modelo;
    public string? Montadora;
    public string? Marca;

    private int ano;
    public int Ano
    {
        get { return ano; }
        set
        {
            if (value < 2000)
                ano = 2000;
            else if (value > 2022)
                ano = 2022;
            else
                ano = value;
        }
    }
    public int Potencia;
    public static double ValorIpva;
    //campo
    public int Cor;
    //construtor
    public Carro(string? Modelo, string? Montadora, string? Marca,
    int Ano, int Potencia, int cor)
    {
        this.Modelo = Modelo;
        this.Montadora = Montadora;
        this.Marca = Marca;
        this.Ano = Ano;
        this.Potencia = Potencia;
        Cor = cor;
    }


    public Carro(string? modelo, string? montadora)
    {
        Modelo = modelo;
        Montadora = montadora;
    }

    public void Acelerar(string marca)
    {
        Console.WriteLine("\nAcelerando o meu... " + marca);
    }

    public double VelocidadeMaxima(int potencia)
    {
        return potencia * 1.75;
    }

    public int AumentarPotencia(int potencia)
    {
        return potencia += 3;
    }

    public int AumentarPotencia(ref int potencia)
    {
        return potencia += 5;
    }
    public int AumentarPotenciaVelocidade(int potencia, out double velocidade)
    {
        potencia += 7;
        velocidade = potencia * 1.75;
        return potencia;
    }

    //método
    public void ExibirInfo(string? Modelo, string? Montadora, string? Marca,
    int Potencia, int Cor = 1, int Ano = 2022)
    {
        Console.WriteLine(Modelo);
        Console.WriteLine(Montadora);
        Console.WriteLine(Marca);
        Console.WriteLine(Potencia);
        Console.WriteLine(Ano);
        Console.WriteLine((Cores)Cor);
    }

    public static double ObterValorIpva()
    {
        return ValorIpva = 4;
    }

}

public struct Cliente
{
    public string Nome;
    public string Email;

    private int idade;
    public int Idade
    {
        get { return idade; }
        set
        {
            if (value < 18) // Corrigido para verificar o valor de entrada
            {
                idade = 18; // Limita a idade a 18
            }
            else
            {
                idade = value; // Caso contrário, atribui o valor normalmente
            }
        }
    }

    public Cliente(string Nome, string Email, int Idade)
    {
        this.Nome = Nome;
        this.Email = Email;
        this.Idade = Idade;
    }

    public static void ExibirInfo(string nome, string email, int idade = 18)
    {
        Console.WriteLine($"Nome: {nome} \nEmail: {email} \nIdade: {idade}");

    }
}
