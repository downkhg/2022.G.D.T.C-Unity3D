#include <stdio.h>

class SingleObject
{
    static SingleObject* m_instance;
    int m_nData = 10;
public:
    SingleObject() { }

    static SingleObject* GetInstance()//함수호출시 내부에 자신의 객체를 할당하고, 이미 있다면 생성된 객체를 참조를 반환한다.
    {
        if (m_instance == NULL)
        {
            m_instance = new SingleObject();
            printf_s("new SingleObject!:%x\n", &m_instance);
        }
        else
            printf_s("m_instance:%x\n", m_instance);

        return m_instance;
    }
    void ShowMsg()
    {
        printf_s("instance[%x]:%x-%d\n", this, m_instance, m_nData);
    }
    void Release()
    {
        delete m_instance;
    }
};

SingleObject* SingleObject::m_instance = NULL;

void main()
{
    //객체의 생성자를 priavte하면 객체가 생성될수없음.
    SingleObject* singleObjectA = NULL;// = new SingleObject();

    singleObjectA = SingleObject::GetInstance();
    //C++의 경우 해당문제에 오류없이 넘어갈수도있어나 객체 멤버가 1개라도 존재하고 그멤버에 접근하는 순간 오류가 발생한다.
    //singleObjectA = singleObjectA->GetInstance(); //static멤버함수는 객체없이 빈포인터를 활용하여 호출하여도 정적멤버변수는 이미 존재하므로 호출은 가능하다.
    singleObjectA->ShowMsg();

    SingleObject* singleObjects[2];
    singleObjects[0] = SingleObject::GetInstance();
    singleObjects[1] = SingleObject::GetInstance();

    for(int i = 0; i < 2; i++)
    {
        singleObjects[i]->ShowMsg();
    }
    singleObjectA->Release();
}