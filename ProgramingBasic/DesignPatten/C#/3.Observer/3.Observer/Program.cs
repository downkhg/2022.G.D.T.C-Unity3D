using System;
using System.Collections.Generic;

namespace _3.Observer
{
    struct Point
    {
        int x; int y;
        public Point(int x = 0, int y = 0) { this.x = x; this.y = y; }
    }
    ///*
    //추상클래스: 객체는 생성가능하지만 인스턴스를 생성할수 없는 클래스.
    abstract class Unit
    {
        Point point;
        public virtual void Move(int x, int y)
        {
            point = new Point(x, y);
            Console.WriteLine(string.Format("{0}:Move({1},{2})", this.ToString(), x, y));
        }
   

        public virtual void Attack(int x, int y)
        {
            point = new Point(x, y);
            Console.WriteLine(string.Format("{0}:Attack({1},{2})", this.ToString(), x, y));
        }
    }
    //*/

    //abstract class Unit
    //{
    //    Point point;
    //    public virtual void Move(int x, int y)
    //    {
    //        point = new Point(x, y);
    //        Console.WriteLine(string.Format("{0}:Move({1},{2})", this.ToString(), x, y));
    //    }

    //    public virtual void Attack(int x, int y)
    //    {
    //        point = new Point(x, y);
    //        Console.WriteLine(string.Format("{0}:Attack({1},{2})", this.ToString(), x, y));
    //    }
    //}

    class Marin : Unit
    {
        public override void Move(int x, int y)
        { 
            base.Move(x, y);
        }

        public override void Attack(int x, int y)
        {
            base.Attack(x, y);
        }
    }

    class Medic : Unit
    {
        public override void Move(int x, int y)
        {
            base.Move(x, y);
        }

        public override void Attack(int x, int y)
        {
            Move(x, y);
        }
    }


    class Commander
    {
        List<Unit> listUnit = new List<Unit>();

        public Commander(int capacity = 12)
        {
            listUnit = new List<Unit>(capacity); //사용할수있는 크기 지정하기
            Console.WriteLine(string.Format("{0}:{1}({2})", this.ToString(),this.ToString(),listUnit.Capacity));
        }

        public void AddUnit(Unit unit)
        {
            if (listUnit.Capacity > listUnit.Count)
                Console.WriteLine("List is Realloc");
            listUnit.Add(unit);
        }

        public void RemoveUnit(Unit unit)
        {
            listUnit.Remove(unit);
        }

        public void Move(int x, int y)
        {
            foreach(var unit in listUnit)
            {
                unit.Move(x, y);
            }
        }

        public void Attack(int x,int y)
        {
            foreach (var unit in listUnit)
            {
                unit.Attack(x, y);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Commander commander = new Commander(1);

            commander.AddUnit(new Marin());
            commander.AddUnit(new Medic());
            //commander.AddUnit(new Unit()); //유닛이라는 유닛이 존재하는가? //추상클래스로 만들면 이러한 오류를 막을수있다.

            commander.Attack(10, 10);
        }
    }
}
