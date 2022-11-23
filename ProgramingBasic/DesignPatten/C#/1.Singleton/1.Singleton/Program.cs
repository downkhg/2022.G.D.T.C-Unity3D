using System;

namespace _1.Singleton
{
    class SingleObject
    {
        static SingleObject m_instance;
        SingleObject() { }
        static public SingleObject GetInstance()//함수호출시 내부에 자신의 객체를 할당하고, 이미 있다면 생성된 객체를 참조를 반환한다.
        {
            if (m_instance == null)
            {
                m_instance = new SingleObject();
                Console.WriteLine("new SingleObject!:" + m_instance);
            }
            //else
            //    Console.WriteLine("m_instance:" + m_instance);

            return m_instance;
        }
        public void ShowMsg()
        {
            Console.WriteLine("instance[{0}]:{1}",m_instance.GetHashCode(), m_instance);
        }
        public void Release()
        {
            m_instance = null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //객체의 생성자를 priavte하면 객체가 생성될수없음.
            SingleObject singleObjectA = null;// = new SingleObject();

            singleObjectA = SingleObject.GetInstance();
            //singleObjectA.GetInstance(); //static멤버함수는 객체없이 클래스를 통해서만 호출가능하다.
            singleObjectA.ShowMsg();

            SingleObject[] singleObjects = new SingleObject[2];
            singleObjects[0] = SingleObject.GetInstance();
            singleObjects[1] = SingleObject.GetInstance();

            foreach(var item in singleObjects)
            {
                item.ShowMsg();
            }
        }
    }
}
