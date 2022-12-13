#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
using namespace std;
//������: �θ��� Ŭ���������Ϳ��� �ڽ��� ��ü�� ��������� ȣ���ϴ� ��.
//�������ε�: �����߿� �Լ��� ����� �����Ǵ� ��.
//�����Լ����̺�(�����Լ�,vptr):
namespace Observer
{
    struct Point
    {
        int x; int y;
        Point(int x = 0, int y = 0) { this->x = x; this->y = y; };
    };
    ///*
    //�߻�Ŭ����: ��ü�� �������������� �ν��Ͻ��� �����Ҽ� ���� Ŭ����.
    class Unit
    {
        Point point;
    public:
        //���������Լ�: ��ӹ��� Ŭ�������� �ݵ�� �����ؾ��ϴ� �Լ�.
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
            listUnit = vector<Unit*>(capacity); //����Ҽ��ִ� ũ�� �����ϱ�
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

    //Unit unit; //�߻�Ŭ������ �޸𸮸� �Ҵ��Ҽ� ����.
    //Marin& marin = * new Marin();
    //Medic& medic = * new Medic();
    Marin marin[2];
    Medic medic[2];

    commander.AddUnit(&marin[0]);
    commander.AddUnit(&medic[0]);
    //commander.AddUnit(unit); //�����̶�� ������ �����ϴ°�? //�߻�Ŭ������ ����� �̷��� ������ �������ִ�.
    commander.AddUnit(&marin[1]);
    commander.AddUnit(&medic[1]);

    commander.Attack(10, 10);
}
