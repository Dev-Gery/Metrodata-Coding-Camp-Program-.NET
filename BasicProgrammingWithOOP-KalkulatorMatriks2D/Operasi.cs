using System;
namespace ProgramOOPDasar
{
    internal class Operasi
    {
        private Matriks2D operanPertama;
        private Matriks2D operanKedua;
        private Matriks2D hasil;
        private char simbolOperator;
        public Operasi(Matriks2D a, char o, Matriks2D b, Matriks2D c)
        {
            this.operanPertama = a;
            this.operanKedua = b;
            this.simbolOperator = o;
            this.hasil = c;
        }
        public void tampilkan()
        {
            int coordX, coordY;
            int m1Height = operanPertama.getHeight;
            int m2Height = operanKedua.getHeight;
            int m3Height = hasil.getHeight;
            coordX = Console.CursorLeft + 2;
            coordY = Console.CursorTop + (m2Height - 1);
            Console.SetCursorPosition(coordX, coordY);
            this.operanPertama.OutputData();
            coordX = Console.CursorLeft + 2;
            coordY = Console.CursorTop - (m1Height - 1);
            Console.SetCursorPosition(coordX, coordY);
            Console.Write(simbolOperator);
            coordX = Console.CursorLeft + 2;
            coordY = Console.CursorTop - (m2Height - 1);
            Console.SetCursorPosition(coordX, coordY);
            this.operanKedua.OutputData();
            coordX = Console.CursorLeft + 2;
            coordY = Console.CursorTop - (m2Height - 1);
            Console.SetCursorPosition(coordX, coordY);
            Console.Write("=");
            coordX = Console.CursorLeft + 2;
            coordY = Console.CursorTop - (m3Height - 1);
            Console.SetCursorPosition(coordX, coordY);
            this.hasil.OutputData();
            coordX = 0;
            coordY = Console.CursorTop + (m2Height);
            Console.SetCursorPosition(coordX, coordY);
        }
    }
}
