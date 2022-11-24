#include <stdio.h>

class SingleObject
{
    static SingleObject* m_instance;
    int m_nData = 10;
//public:
    SingleObject() { } //생성자가 priavte면 객체의 멤버함수만 메모리를 생성 할 수 있다.
public:
    ~SingleObject() { Release(); }//싱글톤 객체가 소멸시에 동적할당된 메모리를 해제함
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
//클래스의 객체의 멤버변수는 모든 함수에서 접근가능해야하므로.
//모든 함수에서접근하려면 프로그램에 종료시까지 메모리가 유지되어야한다.
//그러므로 전역변수처럼 선언을 해서 사용해야한다.
SingleObject* SingleObject::m_instance = NULL;

void main()
{
    //객체의 생성자를 priavte하면 객체가 생성될수없음.
    SingleObject* singleObjectA = NULL;// = new SingleObject();

    singleObjectA = SingleObject::GetInstance();
    //C++의 경우 해당문제에 오류없이 넘어갈수도있어나 객체 멤버가 1개라도 존재하고 그멤버에 접근하는 순간 오류가 발생한다.
    //singleObjectA = singleObjectA->GetInstance(); //static멤버함수는 객체없이 빈포인터를 활용하여 호출하여도 정적멤버변수는 이미 존재하므로 호출은 가능하다.
    singleObjectA->ShowMsg();
    //(*singleObjectA).ShowMsg();

    SingleObject* singleObjects[2];
    singleObjects[0] = SingleObject::GetInstance();
    singleObjects[1] = SingleObject::GetInstance();

    for(int i = 0; i < 2; i++)
    {
        singleObjects[i]->ShowMsg();
    }
    singleObjectA->Release();
}

void SubMain()
{
    SingleObject* pSingeObject = SingleObject::GetInstance();
    //singleObjectA->Release();
}