using System.Numerics;
using System.Runtime.InteropServices.JavaScript;
using System.Xml;

namespace Gui;

public class Matrix {
    public List<List<int>> data;

    public int height {
        get {
            return data.Count;
        }
    }
    public int width {
        get {
            return data[0].Count;
        }
    }
    
    public Matrix() {
        this.data = new List<List<int>>();
    }

    private List<List<int>> NewList(
        int width,
        int height
    ) {
        List<List<int>> l = new List<List<int>>();
        for (int i = 0; i < height; i++) {
            l.Add(new List<int>(new int[width]));
        }

        return l;
    }
    
    public Matrix(
        int width,
        int height
    ) {
        this.data = NewList(
            width, 
            height
        );
    }

    public Matrix(
        List<List<int>> data
    ) {
        int a = data[0].Count;
        foreach (List<int> list in data) {
            if (list.Count != a) {
                throw new Exception("Bad matrix");
            }
        }
        this.data = data;
    }


    public Matrix(
        List<int> vec
    ) {
        this.data = new List<List<int>>();
        data.Add(vec);
    }

    public void Add(
        Matrix matrix
    ) {
        if (
            data.Count != matrix.data.Count &&
            data[0].Count != matrix.data[0].Count
        ) {
            throw new Exception("Cannot add matrices");
        }
        for (int i = 0; i < data.Count; i++) {
            if (data[i].Count != matrix.data[i].Count) {
                throw new Exception("Cannot add matrices");
            }
        }

        for (int y = 0; y < this.height; y++) {
            for (int x = 0; x < this.width; x++) {
                this.data[y][x] += matrix.data[y][x];
            }
        }
    }

    public void Subtract(
        Matrix matrix
    ) {
        if ( data.Count != matrix.data.Count ) {
            throw new Exception("Cannot subtract matrices");
        }
        for (int i = 0; i < data.Count; i++) {
            if (data[i].Count != matrix.data[i].Count) {
                throw new Exception("Cannot subtract matrices");
            }
        }

        for (int y = 0; y < data.Count; y++) {
            for (int x = 0; x < data.Count; x++) {
                this.data[y][x] -= matrix.data[y][x];
            }
        }
    }

    public void Multiply(
        Matrix matrix
    ) {
        if (this.width != matrix.height) {
            throw new Exception("Cannot multiply");
        }

        List<List<int>> l = NewList(matrix.width, this.height);

        for (int y = 0; y < l.Count; y++) {
            for (int x = 0; x < l[0].Count; x++) {

                l[y][x] = 0;

                for (int i = 0; i < this.width; i++) {
                    l[y][x] += data[y][i] * matrix.data[i][x];
                    Console.Write($"{data[y][i] * matrix.data[i][x]} + ");
                }
                Console.WriteLine($"= {l[y][x]}");
                

            }
        }

        this.data = l;
    }

    public void Transpose() {
        List<List<int>> l = new List<List<int>>();
        for (int i = 0; i < this.width; i++) {
            l.Add(new List<int>(new int[this.height]));
        }

        for (int y = 0; y < this.height; y++) {
            for (int x = 0; x < this.width; x++) {
                l[x][y] = this.data[y][x];
            }
        }

        this.data = l;
    }

    public void Print() {
        foreach (List<int> line in this.data) {
            Console.Write("| ");
            foreach (int i in line) {
                Console.Write($"{i} ");
            }
            Console.Write("|\n");
        }
        Console.WriteLine();
    }
    public void Print(
        List<int> list
    ) {
        int j = 0;
        foreach (List<int> line in this.data) {
            Console.Write("| ");
            foreach (int i in line) {
                Console.Write($"{i} ");
            }
            Console.Write($"| {list[j]}\n");
            j++;
        }
        Console.WriteLine();
    }

    public static int NajmniejszaWspolnaWielokrotnosc(int a, int b)
    {
        if (a == 0 || b == 0) throw new Exception("Zero input!");
        return Math.Abs(a * b) / NajwiekszyWspolnyDzielnik(a, b);
    }

    public static int NajwiekszyWspolnyDzielnik(int a, int b)
    {
        if (a == 0 || b == 0)
            return 1;

        if (a < 0) a *= -1;
        if (b < 0) b *= -1; // bug fix: było "a" zamiast "b"

        List<int> dzielnikia = new List<int>();
        List<int> dzielnikib = new List<int>();

        int i = 2;
        while (i <= a)
        {
            if (a % i == 0) { dzielnikia.Add(i); a /= i; }
            else i++;
        }

        i = 2;
        while (i <= b)
        {
            if (b % i == 0) { dzielnikib.Add(i); b /= i; }
            else i++;
        }

        int nwd = 1;
        while (dzielnikia.Count > 0 && dzielnikib.Count > 0)
        {
            if (dzielnikia[0] == dzielnikib[0]) {
                nwd *= dzielnikia[0];
                dzielnikia.RemoveAt(0);
                dzielnikib.RemoveAt(0);
            }
            else if (dzielnikia[0] < dzielnikib[0])
                dzielnikia.RemoveAt(0);
            else
                dzielnikib.RemoveAt(0);
        }

        return nwd;
    }

    public static int NajwiekszyWspolnyDzielnik(List<int> list) {
        int nwd = list[0];
        for (int i = 0; i < list.Count && nwd == 0; i++) {
            nwd = list[i];
        }

        if (nwd == 0) {
            nwd = 1;
        }
        
        foreach (int i in list) {
            if (i == 0) continue;
            nwd = NajwiekszyWspolnyDzielnik(nwd, i);
        }
        return nwd;
    }

    public void GaussUp() {
        for (int x = 0; x < this.width; x++) {
            for (int y = x+1; y < this.height; y++) {
                int nww = NajmniejszaWspolnaWielokrotnosc(data[x][x], data[y][x]);

                int mul1 = nww / data[x][x];
                int mul2 = nww / data[y][x];

                for (int i = 0; i < this.width; i++) {
                    data[x][i] *= mul1;
                    data[y][i] *= mul2;
                }

                for (int i = 0; i < this.width; i++) {
                    data[y][i] -= data[x][i];
                }

                
                for (int i = 0; i < y+1; i++) {
                    int nwd = NajwiekszyWspolnyDzielnik(data[i].GetRange(0, data.Count));
                    for (int j = 0; j < width; j++) {
                        data[i][j] /= nwd;
                    }
                }

            }
        }
    }
    
    public void GaussUp(
        List<int> list
    ) {
        if (list.Count != data.Count) return;
        
        for (int x = 0; x < this.width; x++) {

            for (int y = x + 1; y < this.height && data[x][x] == 0; y++) {
                List<int> t = data[x];
                data[x] = data[y];
                data[y] = t;

                int i = list[x];
                list[x] = list[y];
                list[y] = i;
            }
            
            for (int y = x+1; y < this.height; y++) {
                if (data[y][x] == 0) continue;
                int nww = NajmniejszaWspolnaWielokrotnosc(data[x][x], data[y][x]);

                int mul1 = nww / data[x][x];
                int mul2 = nww / data[y][x];

                for (int i = 0; i < this.width; i++) {
                    data[x][i] *= mul1;
                    data[y][i] *= mul2;
                }

                list[x] *= mul1;
                list[y] *= mul2;

                for (int i = 0; i < this.width; i++) {
                    data[y][i] -= data[x][i];
                }

                list[y] -= list[x];

                
                for (int i = 0; i < y+1; i++) {
                    List<int> l = data[i].GetRange(0, data.Count);
                    l.Add(list[i]);
                    int nwd = NajwiekszyWspolnyDzielnik(l);
                    for (int j = 0; j < width; j++) {
                        data[i][j] /= nwd;
                    }
                    list[i] /= nwd;
                }

            }
        }
    }
    
    public void GaussLow(
        List<int> list
    ) {
        if (list.Count != data.Count) return;
        
        for (int x = this.width-1; x >= 0; x--) {
            
            for (int y = x - 1; y >= 0 && data[x][x] == 0; y--) {
                List<int> t = data[x];
                data[x] = data[y];
                data[y] = t;

                int i = list[x];
                list[x] = list[y];
                list[y] = i;
            }
            
            for (int y = x-1; y >= 0; y--) {
                
                if (data[y][x] == 0) continue;
                
                int nww = NajmniejszaWspolnaWielokrotnosc(data[x][x], data[y][x]);

                int mul1 = nww / data[x][x];
                int mul2 = nww / data[y][x];

                for (int i = 0; i < this.width; i++) {
                    data[x][i] *= mul1;
                    data[y][i] *= mul2;
                }

                list[x] *= mul1;
                list[y] *= mul2;

                for (int i = 0; i < this.width; i++) {
                    data[y][i] -= data[x][i];
                }

                list[y] -= list[x];

                
                for (int i = 0; i < y+1; i++) {
                    List<int> l = data[i].GetRange(0, data.Count);
                    l.Add(list[i]);
                    int nwd = NajwiekszyWspolnyDzielnik(l);
                    for (int j = 0; j < width; j++) {
                        data[i][j] /= nwd;
                    }
                    list[i] /= nwd;
                }

            }
        }       
    }

    public void Solve(
        List<int> list
    ) {
        this.GaussUp(list);
        this.GaussLow(list);

        for (int i = 0; i < this.width; i++) {
            int nwd = NajwiekszyWspolnyDzielnik(list[i], data[i][i]);
            list[i] /= nwd;
            data[i][i] /= nwd;
        }
    }
    
}