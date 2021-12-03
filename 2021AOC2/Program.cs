using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021AOC2
{
    class Program
    {

        class Tengeralattjáró
        {
            protected int H;
            protected int D;
            public Tengeralattjáró(int h = 0, int d = 0)
            {
                this.H = h;
                this.D = d;
            }
            public virtual void Forward(int x) { }
            public virtual void Down(int x) { }
            public virtual void Up(int x){}
            public void Parancs_végrehajtása(string parancs)
            {
                string[] parancssplit = parancs.Split(' ');
                switch (parancssplit[0].ToLower())
                {
                    case "forward":
                        Forward(int.Parse(parancssplit[1]));
                        break;
                    case "down":
                        Down(int.Parse(parancssplit[1]));
                        break;
                    case "up":
                        Up(int.Parse(parancssplit[1]));
                        break;
                    default:
                        Console.Error.WriteLine("ezt nem tudom értelmezni :'(");
                        break;
                }
            }
            public void Parancslista_fájlból(string path)
            {
                string[] parancsok = System.IO.File.ReadAllLines(path);
                foreach (string parancs in parancsok)
                    Parancs_végrehajtása(parancs);
            }
            public override string ToString() => $"({H};{D}) szorzata: {H * D}";
        }

        class Tengeralattjáró1 : Tengeralattjáró
        {
            public override void Forward(int x) => H += x;
            public override void Down(int x) => D += x;
            public override void Up(int x) => D -= x;
        }


        class Tengeralattjáró2 :Tengeralattjáró
        {
            private int A;
            public Tengeralattjáró2(int h=0, int d=0, int a = 0): base(h,d)
            {
                this.A = a;
            }
            public override void Forward(int x)
            {
                H += x;
                D += A * x;
            }
            public override void Down(int x) => A += x;
            public override void Up(int x) => A -= x;
        }
        static void Main(string[] args)
        {
            Tengeralattjáró1 Tamara = new Tengeralattjáró1();
            Tengeralattjáró2 Tímea = new Tengeralattjáró2();


            List<Tengeralattjáró> tengeralattjárók = new List<Tengeralattjáró>();

            tengeralattjárók.Add(Tamara);
            tengeralattjárók.Add(Tímea);

            foreach (Tengeralattjáró tengeralattjáró in tengeralattjárók)
            {
                tengeralattjáró.Parancslista_fájlból("input.txt");
                Console.WriteLine(tengeralattjáró);
            }

            Console.ReadKey();
        }
    }
}
