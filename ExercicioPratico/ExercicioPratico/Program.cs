﻿Carro chevrolet = new("Sedan", "Chevrolet", "Onix", 2016, 110);
chevrolet.Acelerar(chevrolet.Marca);


Console.WriteLine($"{chevrolet.Modelo} {chevrolet.Montadora} {chevrolet.Marca}" +
$" {chevrolet.Ano} {chevrolet.Potencia} CV");
Console.WriteLine("Aumentando a Potencia (por valor : + 3CV) : ");
var novaPotenciaChevrolet = chevrolet.AumentarPotencia(chevrolet.Potencia);
Console.Write("-> " + novaPotenciaChevrolet);
Console.WriteLine("\nO valor do campo Potencia não foi alterado : " + chevrolet.Potencia);


Carro ford = new("SUV", "Ford", "EcoSport", 2018, 120);
ford.Acelerar(ford.Marca);

Console.WriteLine($"{ford.Modelo} {ford.Montadora} {ford.Marca}" +
$" {ford.Ano} {ford.Potencia} CV");
var novaPotenciaFord = ford.AumentarPotencia(ref ford.Potencia);
Console.Write("-> " + novaPotenciaFord);
Console.WriteLine("\nO valor do campo Potencia foi alterado : " + ford.Potencia);

Console.ReadKey();

Console.ReadKey();

public class Carro
{
    public string? Modelo;
    public string? Montadora;
    public string? Marca;
    public int Ano;
    public int Potencia;

    public Carro(string? Modelo, string? Montadora, string? Marca, int Ano, int Potencia)
    {
        this.Modelo = Modelo;
        this.Montadora = Montadora;
        this.Marca = Marca;
        this.Ano = Ano;
        this.Potencia = Potencia;
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

}


