using System;
namespace ProgramOOPDasar
{
    internal class Matriks2D
    {
        private int height;
        private int width;
        private int[,] data;
        public Matriks2D(int height, int width)
        {
            this.height = height;
            this.width = width;
            this.data = new int[height, width];
        }
        public Matriks2D(int[,] matriks)
        {
            this.height = matriks.GetLength(0);
            this.width = matriks.GetLength(1);
            this.data = matriks;
        }
        public int getHeight { get { return height; } }
        public int getWidth { get { return width; } }
        public void InputData()
        {
            int startCoordX = Console.CursorLeft;
            int startCoordY = Console.CursorTop;
            for (int i = 0; i < this.height; i++)
            {
                for (int j = 0; j < this.width; j++)
                {
                    Console.SetCursorPosition(startCoordX + (4 * j), startCoordY + (2 * i));
                    this.data[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }
        public void OutputData()
        {
            int startCoordX = Console.CursorLeft;
            int startCoordY = Console.CursorTop;
            for (int i = 0; i < this.height; i++)
            {
                for (int j = 0; j < this.width; j++)
                {
                    Console.SetCursorPosition(startCoordX + (4 * j), startCoordY + (2 * i));
                    Console.Write(this.data[i, j]);
                }
            }
        }
        public Matriks2D MatrixAdd(Matriks2D other)
        {
            if (this.height == other.height && this.width == other.width)
            {
                int[,] result = new int[this.height, other.width];
                for (int i = 0; i < this.height; i++)
                {
                    for (int j = 0; j < other.width; j++)
                    {
                        result[i, j] = this.data[i, j] + other.data[i, j];
                    }
                }
                return new Matriks2D(result);
            }
            else
            {
                throw new ArgumentException("Ukuran baris dan kolom kedua matriks operan untuk penjumlahan harus sama");
            }
        }
        public Matriks2D MatrixProduct(Matriks2D other)
        {
            if (this.width == other.height)
            {
                int[,] result = new int[this.height, other.width];
                for (int i = 0; i < this.height; i++)
                {
                    for (int j = 0, sum = 0; j < other.width; j++)
                    {
                        for (int k = 0; k < this.width; k++)
                        {
                            sum += this.data[i, k] * other.data[k, j];
                        }
                        result[i, j] = sum;
                        sum = 0;
                    }
                }
                return new Matriks2D(result);
            }
            else
            {
                throw new ArgumentException("Ukuran kolom matriks yang satu harus sama dengan ukuran baris matriks yang lain");
            }
        }
    }
}
