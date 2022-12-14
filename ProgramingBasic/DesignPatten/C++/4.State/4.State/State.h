#pragma once

#include <iostream>

using namespace std;
//클래스선언: 이런 클래스를 사용하겟다고 이름만 정하는 것.
class IState;
class Title;
class GameOver;
class Play;
class Context;

//클래스의 정의: 선언된 클래스의 멤버를 선언한것.
__interface IState
{
    //int nData;
public:
    virtual void GoNext(Context* context) = 0;// 인터페이스를 상속받은 객체는 반드시 함수를 오버라이딩해야한다.
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