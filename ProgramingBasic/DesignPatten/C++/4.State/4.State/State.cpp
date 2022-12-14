#include "State.h"
#include<iostream>
#include <stdlib.h>
//Ŭ������ ����Լ��� ����: Ŭ������::�Լ���(�Ű�����...)�� ���� ������ Ŭ������ ���Ե� ����Լ��� ������.
GameOver::GameOver()
{
    printf_s("%s:%s\n", this->ToString(), ToString());
}
GameOver::~GameOver()
{
    printf_s("%s:~%s\n", this->ToString(), ToString());
}
void GameOver::GoNext(Context* context)
{
    context->SetState(new Title());
}
const char* GameOver::ToString()
{
    return typeid(*this).name();
}

Play::Play()
{
    printf_s("%s:%s\n", this->ToString(), ToString());
}

Play::~Play()
{
    printf_s("%s:~%s\n", this->ToString(), ToString());
}
void Play::GoNext(Context* context)
{
    context->SetState(new GameOver());
}
const char* Play::ToString()
{
    return typeid(*this).name();
}

Title::Title()
{
    printf_s("%s:%s\n", this->ToString(), ToString());
}
Title::~Title()
{
    printf_s("%s:~%s\n", this->ToString(), ToString());
}
void Title::GoNext(Context* context)
{
    context->SetState(new Play());
}

const char* Title::ToString()
{
    return typeid(*this).name();
}

Context::Context()
{
    printf_s("%s:%s\n", this->ToString(), ToString());
}
Context::~Context()
{
    m_pState = nullptr;
    printf_s("%s:~%s\n", this->ToString(), ToString());
}
void Context::SetState(IState* state)
{
    m_pState = nullptr;
    m_pState = state;
}
void Context::GoNext()
{
    m_pState->GoNext(this);
}
const char* Context::ToString()
{
    return typeid(*this).name();
}
