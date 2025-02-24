﻿using System;
using System.Threading;

namespace Stopwatch
{
    class Program
    {
        static char type;
        static int originalTime;

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();

            Console.WriteLine("Quanto tempo deseja contar?");

            Console.WriteLine("Segundo(s) => 10s = 10 segundos");
            Console.WriteLine("Minuto(s) => 1m = 1 minuto");
            Console.WriteLine("0(zero) = Fechar cronômetro");

            string data = Console.ReadLine().ToLower();

            if (data == "0") Close();

            if (data.Length == 0 || (data.Length == 1 && data[0] != '0'))
            {
                Error("Valor inválido!");
            }

            type = char.Parse(data.Substring(data.Length - 1, 1));
            int time = int.Parse(data.Substring(0, data.Length - 1));
            originalTime = time;

            if (time <= 0)
            {
                Error("Valor inválido!");
            }

            if (type != 's' && type != 'm')
            {
                Error("Tipo inválido!");
            }

            Console.WriteLine("1\n1");

            int multiplier = type == 'm' ? 60 : 1;

            PreStart(time * multiplier);
        }

        static void PreStart(int time)
        {
            Console.Clear();
            Console.WriteLine("Ready...");
            Thread.Sleep(1000);
            Console.WriteLine("Set...");
            Thread.Sleep(1000);
            Console.WriteLine("Go!");
            Thread.Sleep(1000);
            Start(time);
        }

        static void Start(int time)
        {
            int currentTime = 0;

            while (currentTime != time)
            {
                Console.Clear();
                Console.WriteLine(++currentTime);
                Thread.Sleep(1000);
            }

            Console.Clear();
            string secOrmin = type == 's' ? "segundo(s)" : "minuto(s)";
            Console.WriteLine($"Pronto! Contei até {originalTime} {secOrmin}");
            Console.ReadKey();
            Thread.Sleep(2000);
            Menu();
        }

        static void Close()
        {
            Environment.Exit(0);
        }

        static void Error(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(2000);
            Menu();
        }
    }
}
