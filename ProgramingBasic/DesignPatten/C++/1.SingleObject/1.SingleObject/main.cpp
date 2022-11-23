#include <stdio.h>

class SingleObject
{
    static SingleObject* m_instance;
    int m_nData = 10;
public:
    SingleObject() { }

    static SingleObject* GetInstance()//�Լ�ȣ��� ���ο� �ڽ��� ��ü�� �Ҵ��ϰ�, �̹� �ִٸ� ������ ��ü�� ������ ��ȯ�Ѵ�.
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
    //��ü�� �����ڸ� priavte�ϸ� ��ü�� �����ɼ�����.
    SingleObject* singleObjectA = NULL;// = new SingleObject();

    singleObjectA = SingleObject::GetInstance();
    //C++�� ��� �ش繮���� �������� �Ѿ�����־ ��ü ����� 1���� �����ϰ� �׸���� �����ϴ� ���� ������ �߻��Ѵ�.
    //singleObjectA = singleObjectA->GetInstance(); //static����Լ��� ��ü���� �������͸� Ȱ���Ͽ� ȣ���Ͽ��� ������������� �̹� �����ϹǷ� ȣ���� �����ϴ�.
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