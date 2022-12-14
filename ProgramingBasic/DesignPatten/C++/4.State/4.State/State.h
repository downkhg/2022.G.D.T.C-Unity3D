#pragma once

#include <iostream>

using namespace std;
//Ŭ��������: �̷� Ŭ������ ����ϰٴٰ� �̸��� ���ϴ� ��.
class IState;
class Title;
class GameOver;
class Play;
class Context;

//Ŭ������ ����: ����� Ŭ������ ����� �����Ѱ�.
__interface IState
{
    //int nData;
public:
    virtual void GoNext(Context* context) = 0;// �������̽��� ��ӹ��� ��ü�� �ݵ�� �Լ��� �������̵��ؾ��Ѵ�.
};

class GameOver : public IState
{
public:
    GameOver();
    ~GameOver();
    void GoNext(Context* context) override;
    const char* ToString();
};

class Play : public IState
{
public:
    Play();
    ~Play();
    void GoNext(Context* context) override;
    const char* ToString();
};

class Title : public IState
{
public:
    Title();
    ~Title();
    void GoNext(Context* context) override;

    const char* ToString();
};

class Context
{
    IState* m_pState;

public:
    Context();
    ~Context();
    void SetState(IState* state);
    void GoNext();
    const char* ToString();
};