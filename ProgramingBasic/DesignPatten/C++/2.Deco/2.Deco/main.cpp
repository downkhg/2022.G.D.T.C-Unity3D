#include <stdio.h>
#include <typeinfo>

class Cookie
{
    int flour;
    int sugar;

public:
    Cookie(int _flour, int _sugar) //������: �޸𸮰� �����ɶ� ȣ���ϴ� �Լ�.
    {
        printf_s("%s:%s\n", typeid(*this).name(), typeid(*this).name());
        flour = _flour;
        sugar = _sugar;
    }

    ~Cookie()
    {
        printf_s("%s:~%s\n", typeid(*this).name(), typeid(*this).name());
    }
};

class MilkCookie : Cookie
{
    //int flour;
    //int sugar;
    int milk;

public:
    MilkCookie(int _flour, int _sugar, int _milk) : Cookie(_flour, _sugar)//������: �޸𸮰� �����ɶ� ȣ���ϴ� �Լ�.
    {
        printf_s("%s:%s\n", typeid(*this).name(), typeid(*this).name());
        //flour = _flour;
        //sugar = _sugar;
        milk = _milk;
    }

    ~MilkCookie()
    {
        printf_s("%s:~%s\n", typeid(*this).name(), typeid(*this).name());
    }
};

class ChocoCookie : Cookie
{
    //int flour;
    //int sugar;
    int choco;

public:
    ChocoCookie(int _flour, int _sugar, int _choco) : Cookie(_flour, _sugar) //������: �޸𸮰� �����ɶ� ȣ���ϴ� �Լ�.
    {
        printf_s("%s:%s\n", typeid(*this).name(), typeid(*this).name());
        //flour = _flour;
        //sugar = _sugar;
        choco = _choco;
    }

    ~ChocoCookie()
    {
        printf_s("%s:~%s\n", typeid(*this).name(), typeid(*this).name());
    }
};

class AmondChocoCooke : ChocoCookie
{
    int amond;
public:
    AmondChocoCooke(int _flour, int _sugar, int _choco, int _amond) :ChocoCookie(_flour, _sugar, _choco)
    {
        printf_s("%s:%s\n", typeid(*this).name(), typeid(*this).name());
    }

    ~AmondChocoCooke()
    {
        printf_s("%s:~%s\n", typeid(*this).name(), typeid(*this).name());
    }
};

class MilkChocoCooke
{
    //MilkCookie milkChocoCooke;
    MilkCookie* pMilkCooke;
    int choco;

public: 
    MilkChocoCooke(int _flour, int _sugar, int _milk, int _choco)
    {
        printf_s("%s:%s\n", typeid(*this).name(), typeid(*this).name());
        pMilkCooke = new MilkCookie(_flour, _sugar, _milk);
        choco = _choco;
    }

    ~MilkChocoCooke()
    {
        printf_s("%s:%s\n", typeid(*this).name(), typeid(*this).name());
    }
};
//��������: ���α׷� ����ÿ� �����ǰ� ���α׷� ����ÿ� �����ȴ�.
Cookie g_cookie = Cookie(100,20);

void main()
{
    printf_s("##### Program.Main Start #####\n");
    printf_s("##### Static Allocate #####\n");
    //�����Ҵ�
    Cookie cookie = Cookie(100, 10);
    MilkCookie milkCookie = MilkCookie(100, 10, 10);
    ChocoCookie chocoCookie = ChocoCookie(100, 10, 30);
    AmondChocoCooke amondChocoCooke = AmondChocoCooke(100, 10, 30, 10);
    MilkChocoCooke milkChocoCooke = MilkChocoCooke(100, 10, 10, 10);
    printf_s("##### Dynamic Allocate #####\n");
    //�����Ҵ�
    Cookie* pCookie = new Cookie(100, 10);
    MilkCookie* pMilkCookie = new MilkCookie(100, 10, 10);
    ChocoCookie* pChocoCookie = new ChocoCookie(100, 10, 30);
    AmondChocoCooke* pAmondChocoCooke = new AmondChocoCooke(100, 10, 30, 10);
    MilkChocoCooke* pMilkChocoCooke = new MilkChocoCooke(100, 10, 10, 10);
    printf_s("##### Dynamic Allocate Free #####\n");
    delete pCookie;
    delete pMilkCookie;
    delete pChocoCookie;
    delete pAmondChocoCooke;
    delete pMilkChocoCooke;
    printf_s("##### Program.Main End #####\n");
    printf_s("##### Static Allocate Free #####\n");
}