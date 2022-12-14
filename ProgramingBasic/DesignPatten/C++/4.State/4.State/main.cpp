#include <iostream>
#include "State.h"

using namespace std;

void main()
{
    printf_s("Main Start\n");
    //���ؽ�Ʈ��ü�� �����Ҵ�
    Context context;
    //������Ʈ��ü�� ��� �������� �����ؾ��ϹǷ� �ݵ�� �����Ҵ��̿����Ѵ�.
    //�������ε�: �Լ��� ����� ���α׷� �������϶� �����Ǵ°�.

    //�����Լ�������(v-ptr): �����Ϳ� �����Ҵ�� ����� �ڽİ�ü�� �������̵� �Լ��� ȣ���.
    //�Լ�������: �Լ��� �ּҰ��� �����ϴ� ����. ���ϰ��� �Ű������� ���� Ÿ���� �����̾���.
    //�Լ��� �����Ͱ� ����Ű�� �ּҰ��� �����Ͽ� ȣ��Ǵ� �Լ��� �����Ҽ� �ִ�.
    context.SetState(new Title());
    context.GoNext();
    context.GoNext();
    //���ý�Ʈ ��ü�� ������ ���Ϸ��� ������ ���� ����ؾ��Ѵ�.
    Context* pContext = new Context();

    pContext->SetState(new Title());
    pContext->GoNext();
    pContext->GoNext();

    delete pContext;
    printf_s("Main End\n");
}