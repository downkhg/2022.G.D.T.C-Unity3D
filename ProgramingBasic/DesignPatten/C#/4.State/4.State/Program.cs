using System;

namespace _4.State
{
    //인터페이스: 멤버함수 만 정의 가능하고 인스턴스가 불가능 클래스.
    interface IState
    {
        //public State()
        //{
        //    Console.WriteLine(string.Format("base:{0}:{1}", this.ToString(), ToString()));
        //}
        //~State()
        //{
        //    Console.WriteLine(string.Format("base:{0}:~{1}", this.ToString(), ToString()));
        //}
        public abstract void GoNext(Context context);// 인터페이스를 상속받은 객체는 반드시 함수를 오버라이딩해야한다.
    }

    class Title : IState
    {
        public Title()
        {
            Console.WriteLine(string.Format("{0}:{1}", this.ToString(), ToString()));
        }
        ~Title()
        {
            Console.WriteLine(string.Format("{0}:~{1}", this.ToString(), ToString()));
        }
        public void GoNext(Context context)
        {
            context.SetState(new Play());
        }
    }

    class Play : IState
    {
        public Play()
        {
            Console.WriteLine(string.Format("{0}:{1}", this.ToString(), ToString()));
        }
        ~Play()
        {
            Console.WriteLine(string.Format("{0}:~{1}", this.ToString(), ToString()));
        }
        public void GoNext(Context context)
        {
            context.SetState(new GameOver());
        }
    }

    class GameOver : IState
    {
        public GameOver()
        {
            Console.WriteLine(string.Format("{0}:{1}", this.ToString(), ToString()));
        }
        ~GameOver()
        {
            Console.WriteLine(string.Format("{0}:~{1}", this.ToString(), ToString()));
        }
        public void GoNext(Context context)
        {
            context.SetState(new Title());
        }
    }

    class Context
    {
        IState m_cState;

        public Context()
        {
            Console.WriteLine(string.Format("{0}:{1}", this.ToString(), ToString()));
        }
        ~Context()
        {
            m_cState = null;
            Console.WriteLine(string.Format("{0}:~{1}", this.ToString(), ToString()));
        }

        public void SetState(IState state)
        {
            m_cState = null;
            m_cState = state;
        }
        public void GoNext()
        {
            m_cState.GoNext(this);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Start - TotalMemory({0})", System.GC.GetTotalMemory(true));
            Context context = new Context();

            context.SetState(new Title());
            context.GoNext();
            context.GoNext();

            System.GC.Collect(0);
            Console.WriteLine("Main End - TotalMemory({0})", System.GC.GetTotalMemory(true));
        }
    }
}
