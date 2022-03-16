using System;
using System.Collections.Generic;

namespace ProgramOOPDasar
{
    internal class KalkulatorMatriks2D
    {
        static List<Operasi> riwayatOperasi = new List<Operasi>();
        static void Main(string[] args)
        {
            SelamatDatang();
            string pilihan;
            do
            {
                pilihan = PemilihanMenu();
                Pemrosesan(pilihan);
            } while (pilihan != "4");
        }
        static void SelamatDatang()
        {
            Console.WriteLine("Selamat datang di kalkulator matriks 2D sederhana.");
            for (int i = 0; i <= 49; i++) { Console.Write("-"); }
            Console.WriteLine();
        }
        static string PemilihanMenu()
        {
            Console.Write("Pilih operasi yang tersedia atau 'Keluar' untuk berhenti: ");
            Console.WriteLine("\n(1) Penjumlahan\n(2) Perkalian\n(3) Riwayat Operasi\n(4) Keluar");
            Console.Write("Input: ");
            string pilihan = Console.ReadLine();
            return pilihan;
        }
        static void Pemrosesan(string pilihan)
        {
            if (pilihan == "1" || pilihan == "2")
            {
                Boolean addition = false, multiplication = false;
                char simbolOperator;
                int m1, n1, m2, n2;
                do
                {
                    if (pilihan == "1")
                    {
                        Console.WriteLine("\nUkuran baris(m) dan kolom(n) kedua matriks operan A dan B harus sama persis: A[m,n] dan B[m,n]");
                        addition = true;
                    }
                    else
                    {
                        Console.WriteLine("\nUkuran kolom matriks A harusn sama dengan ukuran baris matriks B: A [..., n] dan B[n, ...]");
                        multiplication = true;
                    }
                    Console.WriteLine("Tentukan ukuran matriks A:");
                    Console.Write("\tBaris: "); m1 = int.Parse(Console.ReadLine());
                    Console.Write("\tKolom: "); n1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Tentukan ukuran matriks B:");
                    Console.Write("\tBaris: "); m2 = int.Parse(Console.ReadLine());
                    Console.Write("\tKolom: "); n2 = int.Parse(Console.ReadLine());
                } while ((addition && (m1 != m2 || n1 != n2)) || (multiplication && (n1 != m2)));
                Console.WriteLine("Masukkan nilai-nilai matriks A dan B:");
                Console.WriteLine();
                Matriks2D matriksA = new Matriks2D(m1, n1);
                Matriks2D matriksB = new Matriks2D(m2, n2);
                Matriks2D matriksHasil;
                int coordX;
                int coordY;
                coordX = Console.CursorLeft;
                coordY = Console.CursorTop + (m1 - 1);
                Console.SetCursorPosition(coordX, coordY);
                Console.Write("A = ");
                coordX = Console.CursorLeft + 5;
                coordY = Console.CursorTop - (m1 - 1);
                Console.SetCursorPosition(coordX, coordY);
                matriksA.InputData();
                Console.WriteLine("\n");
                coordX = Console.CursorLeft;
                coordY = Console.CursorTop + (m2 - 1);
                Console.SetCursorPosition(coordX, coordY);
                Console.Write("B = ");
                coordX = Console.CursorLeft + 5;
                coordY = Console.CursorTop - (m2 - 1);
                Console.SetCursorPosition(coordX, coordY);
                matriksB.InputData();
                Console.WriteLine();
                if (pilihan == "1")
                {
                    matriksHasil = matriksA.MatrixAdd(matriksB);
                    simbolOperator = '+';
                }
                else
                {
                    matriksHasil = matriksA.MatrixProduct(matriksB);
                    simbolOperator = 'x';
                }
                int h = matriksHasil.getHeight;
                coordX = Console.CursorLeft;
                coordY = Console.CursorTop + (h);
                Console.SetCursorPosition(coordX, coordY);
                Console.Write($"A {simbolOperator} B = ");
                coordX = Console.CursorLeft + 1;
                coordY = Console.CursorTop - (h - 1);
                Console.SetCursorPosition(coordX, coordY);
                matriksHasil.OutputData();
                riwayatOperasi.Add(new Operasi(matriksA, simbolOperator, matriksB, matriksHasil));
            }
            else if (pilihan == "3")
            {
                for (int i = 0; i < riwayatOperasi.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.");
                    riwayatOperasi[i].tampilkan();
                    Console.WriteLine();
                }
            }
            else if (pilihan == "4")
            {
                for (int i = 0; i <= 26; i++) { Console.Write("-"); }
                Console.WriteLine("\nBaiklah, Selamat Tinggal :)");
                return;
            }
            else
            {
                Console.Write("Maaf, pilihan anda tidak valid.");
            }
            Console.WriteLine("\n");
        }
    }
}