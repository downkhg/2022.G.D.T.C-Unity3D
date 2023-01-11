using System;
using System.Threading;
using WinAPIDemoCS;
using System.Collections;
using System.Collections.Generic;

//WinAPI의 콜백과 메세지구조를 흉내내어 콘솔프로그래밍에서 스레드와 프로세스의 구조를 이해하기
//1. 콜백,메세지,스레드,프로스세스,큐
//2. 프로그램은 종료시까지 반복되야하므로, 루프를 이용하여 종료 입력 전까지 프로그램이 작동되어야한다.
//3. 메세지를 입력하여 적절한 명령을 수행해야하므로, enum 을 정의하고, 값에 따라  저장하는 enum의 값을 다르게 처리를 다르게 만든다.
//4. 입력을 대하는 대기시켯을때 메세지가 처리되지않고 대기된다.
//5. 스레드에서 필요한 클래스를 생성하고 등록하여 객체를 만들어사용한다. -> static class 인경우는 객체를 만들지않아도됨.
//6. 큐잉을 이용하여 메세지 저장
namespace WinAPIDemoCS
{
    static class WinAPI //쓰레드에 필요한 멤버를 구현한 클래스.
    {
        public enum WM_MSG { CREATE, COMMOND, PAINT, DESTROY, MAX };
        static Queue<WM_MSG> m_queMsg = new Queue<WM_MSG>();
        static WM_MSG m_eMsg;
        static bool m_isLoop = true;

        static public void EnqueMsg(WM_MSG msg)
        {
            m_queMsg.Enqueue(msg);
        }

        static public WM_MSG MSG { set => m_eMsg = value; get => m_eMsg; } //인덱서: 프라이빗멤버에 접근하는 세터와 게터를 간략하게 코드 작성이 가능함.
        static public bool Loop { get => m_isLoop; }

        //static클래스는 객체를 생성하지않으므로, 생성자가 의미가 없다.
        //public WinAPI(WM_MSG msg)
        //{
        //    m_eMsg = msg;
        //}

        static public void WndProc()
        {
            while (m_isLoop)
            {
                if(m_queMsg.Count > 0)
                    m_eMsg = m_queMsg.Dequeue();
                switch (m_eMsg)
                {
                    case WM_MSG.CREATE:
                        Console.WriteLine(m_eMsg + ": 초기화");
                        m_eMsg = WM_MSG.COMMOND;
                        break;
                    case WM_MSG.COMMOND:
                        Console.WriteLine(m_eMsg + ": 명령을 입력하세요!");
                        for (WM_MSG i = WM_MSG.CREATE; i < WM_MSG.MAX; i++)
                            Console.Write("{0}:{1} ", (int)i, i.ToString());
                        Console.WriteLine();
                        break;
                    case WM_MSG.PAINT:
                        Console.WriteLine(m_eMsg + ": 화면을 그립니다.");
                        break;
                    case WM_MSG.DESTROY:
                        Console.WriteLine(m_eMsg + ": 프로그램을 종료합니다.");
                        m_isLoop = false;
                        break;
                    default:
                        break;
                };
                Thread.Sleep(2000);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)//프로세스: 프로그램내에서 기본적인 흐름.
        {
            //WinAPI cWinAPI = new WinAPI(WinAPI.WM_MSG.CREATE); 
            WinAPI.MSG = WinAPI.WM_MSG.CREATE;
            ThreadStart threadStart = new ThreadStart(WinAPI.WndProc); //스레드에 필요한 함수를 등록하는 클래스.
            Thread cThread = new Thread(threadStart);//준비된 스레드시작객체를 등록
            cThread.Start(); //스레드 시작

            while (WinAPI.Loop)
            {
                string strMsg = Console.ReadLine();
                WinAPI.WM_MSG eMSG = (WinAPI.WM_MSG)int.Parse(strMsg);
                WinAPI.EnqueMsg(eMSG); //큐에 입력받은 메세지를 입력 
                // cWinAPI.MSG = eMSG; //메세지큐없이 메세지 처리 //해당 셋터를 변경하여 엔큐할수있지만 상식적인 api의 처리는 아님.
                cThread.Join(); //스레드 종료대기
            }
        }
    }
}
