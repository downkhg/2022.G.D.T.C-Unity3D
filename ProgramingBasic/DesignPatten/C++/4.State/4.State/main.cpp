#include <iostream>
#include "State.h"

using namespace std;

void main()
{
    printf_s("Main Start\n");
    //컨텍스트객체를 정적할당
    Context context;
    //스테이트객체의 경우 다형성이 성립해야하므로 반드시 동적할당이여야한다.
    //동적바인딩: 함수의 기능이 프로그램 실행중일때 결정되는것.

    //가상함수포인터(v-ptr): 포인터에 동적할당된 대상의 자식객체의 오버라이딩 함수가 호출됨.
    //함수포인터: 함수의 주소값을 저장하는 변수. 리턴값과 매개변수의 수와 타입이 같아이야함.
    //함수에 포인터가 가르키는 주소값을 변경하여 호출되는 함수를 변경할수 있다.
    context.SetState(new Title());
    context.GoNext();
    context.GoNext();
    //컨택스트 객체를 동적할 당하려면 다음과 같이 사용해야한다.
    Context* pContext = new Context();

    pContext->SetState(new Title());
    pContext->GoNext();
    pContext->GoNext();

    delete pContext;
    printf_s("Main End\n");
}