using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Deco
{
    class Cookie
    {
        int flour;
        int sugar;

        public Cookie(int _flour, int _sugar) //생성자: 메모리가 생성될때 호출하는 함수.
        {
            Console.WriteLine(string.Format("{0}:{1}", this.ToString(), this.ToString()));
            flour = _flour;
            sugar = _sugar;
        }

        ~Cookie()
        {
            Console.WriteLine(string.Format("{0}:~{1}",this.ToString(), this.ToString()));
        }
    }

    class MilkCookie : Cookie
    {
        //int flour;
        //int sugar;
        int milk;

        public MilkCookie(int _flour, int _sugar, int _milk) : base(_flour, _sugar)//생성자: 메모리가 생성될때 호출하는 함수.
        {
            Console.WriteLine(string.Format("{0}:{1}", this.ToString(), this.ToString()));
            //flour = _flour;
            //sugar = _sugar;
            milk = _milk;
        }

        ~MilkCookie()
        {
            Console.WriteLine(string.Format("{0}:~{1}", this.ToString(), this.ToString()));
        }
    }

    class ChocoCookie: Cookie
    {
        //int flour;
        //int sugar;
        int choco;

        public ChocoCookie(int _flour, int _sugar, int _choco) : base(_flour, _sugar) //생성자: 메모리가 생성될때 호출하는 함수.
        {
            Console.WriteLine(string.Format("{0}:{1}", this.ToString(), this.ToString()));
            //flour = _flour;
            //sugar = _sugar;
            choco = _choco;
        }

        ~ChocoCookie()
        {
            Console.WriteLine(string.Format("{0}:~{1}", this.ToString(), this.ToString()));
        }
    }

    class AmondChocoCooke : ChocoCookie
    {
        int amond;

        public AmondChocoCooke(int _flour, int _sugar, int _choco, int _amond):base(_flour, _sugar, _choco)
        {
            Console.WriteLine(string.Format("{0}:{1}", this.ToString(), this.ToString()));
        }

        ~AmondChocoCooke()
        {
            Console.WriteLine(string.Format("{0}:~{1}", this.ToString(), this.ToString()));
        }
    }

    class MilkChocoCooke
    {
        MilkCookie milkChocoCooke;
        int choco;

        public MilkChocoCooke(int _flour, int _sugar, int _milk, int _choco)
        {
            Console.WriteLine(string.Format("{0}:{1}", this.ToString(), this.ToString()));
            milkChocoCooke = new MilkCookie(_flour, _sugar, _milk);
            choco = _choco;
        }

        ~MilkChocoCooke()
        {
            Console.WriteLine(string.Format("{0}:~{1}", this.ToString(), this.ToString()));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program.Main Start");
            Cookie cookie = new Cookie(100,10);
            MilkCookie milkCookie = new MilkCookie(100,10,10);
            ChocoCookie chocoCookie = new ChocoCookie(100, 10, 30);
            AmondChocoCooke amondChocoCooke = new AmondChocoCooke(100, 10, 30, 10);
            MilkChocoCooke milkChocoCooke = new MilkChocoCooke(100, 10, 10, 10);
            Console.WriteLine("Program.Main End");
        }
    }
}
