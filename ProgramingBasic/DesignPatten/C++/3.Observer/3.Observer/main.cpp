#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
using namespace std;
//다형성: 부모의 클래스포인터에서 자식의 객체의 멤버변수를 호출하는 것.
//동적바인딩: 실행중에 함수의 기능이 결정되는 것.
//가상함수테이블(가상함수,vptr):
namespace Observer
{
    struct Point
    {
        int x; int y;
        Point(int x = 0, int y = 0) { this->x = x; this->y = y; };
    };
    ///*
    //추상클래스: 객체는 생성가능하지만 인스턴스를 생성할수 없는 클래스.
    class Unit
    {
        Point point;
    public:
        //순수가상함수: 상속받은 클래스에서 반드시 정의해야하는 함수.
        virtual void Move(int x, int y) = 0
        {
            point = Point(x, y);
            printf_s("%s:Move(%d,%d)\n", this->ToString(), x, y);
        }

        virtual void Attack(int x, int y) = 0
        {
            point = Point(x, y);
            printf_s("%s:Attack(%d,%d)\n", this->ToString(), x, y);
        }

        const char* ToString()
        {
            return typeid(*this).name();
        }
    };

    class Marin : public Unit
    {
    public:
        void Move(int x, int y) override
        {
            Unit::Move(x, y);
        }

        void Attack(int x, int y) override
        {
            Unit::Attack(x, y);
        }
    };

    class Medic : public Unit
    {
    public:
        void Move(int x, int y) override
        {
            Unit::Move(x, y);
        }

        void Attack(int x, int y) override
        {
            Move(x, y);
        }
    };


    class Commander
    {
        vector<Unit*> listUnit;

    public:
        Commander(int capacity = 12)
        {
            listUnit = vector<Unit*>(capacity); //사용할수있는 크기 지정하기
            printf_s("%s:%s(%d)\n", this->ToString(), this->ToString(), listUnit.capacity());
        }

        void AddUnit(Unit* unit)
        {
            static int nIdx = 0;
            printf_s("%s:AddUnit(%d/%d)-", this->ToString(), listUnit.capacity(), listUnit.size());
            if (nIdx >= listUnit.capacity())
            {
                listUnit.push_back(unit);
                printf_s("List is Realloc(%d)\n", listUnit.capacity());
            }
            else
            {
                printf_s("[%d]\n", nIdx);
                listUnit[nIdx] = unit;
                nIdx++;
            }
        }

        void RemoveUnit(Unit* unit)
        {
            remove(listUnit.begin(), listUnit.end(), unit);
        }

        void Move(int x, int y)
        {
            //vector<Unit*>::iterator it = listUnit.begin();
            for (auto it = listUnit.begin(); it != listUnit.end(); it++)
                (*it)->Move(x, y);
        }

        void Attack(int x, int y)
        {
            for (auto it = listUnit.begin(); it != listUnit.end(); it++)
                (*it)->Attack(x, y);
        }

        const char* ToString()
        {
            return typeid(*this).name();
        }
    };
}

using namespace Observer;

void main()
{
    Commander commander = Commander(2);

    //Unit unit; //추상클래스는 메모리를 할당할수 없다.
    //Marin& marin = * new Marin();
    //Medic& medic = * new Medic();
    Marin marin[2];
    Medic medic[2];

    commander.AddUnit(&marin[0]);
    commander.AddUnit(&medic[0]);
    //commander.AddUnit(unit); //유닛이라는 유닛이 존재하는가? //추상클래스로 만들면 이러한 오류를 막을수있다.
    commander.AddUnit(&marin[1]);
    commander.AddUnit(&medic[1]);

    commander.Attack(10, 10);
}
