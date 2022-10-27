using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    public float Speed = 1;
    public float Site = 1;

    public Transform trTargetPoint;
    public Transform trResponPoint;
    public Transform trPatrolPoint;

    public bool isPatrol;
    public bool isMove;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, Site);

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(trResponPoint.position, Time.deltaTime);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(trPatrolPoint.position, Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Vector3 vPos = this.transform.position;
        Collider2D collider = Physics2D.OverlapCircle(vPos, Site, 1<<LayerMask.NameToLayer("Player"));

        if (isPatrol == false)
        {
            if (collider && collider.gameObject.tag == "Player")
            {
                Debug.Log("OverlapCircle:" + collider.gameObject.name);
                MoveProcess(collider.transform.position);
            }
            else
            {
                //Vector3 vTargetPos = trResponPoint.position;
                //Vector3 vDist = vTargetPos - vPos;//위치의 차이를 이용한 거리구하기
                //Vector3 vDir = vDist.normalized;//두물체사이의 방향(평준화-거리를뺀 이동량)
                //float fDist = vDist.magnitude; //두물체사이의 거리(스칼라-순수이동량)

                //if (fDist > Time.deltaTime)//한프레임의 이동거리보다 클때만 이동한다.
                //    transform.position += vDir * Speed * Time.deltaTime;
                if (MoveProcess(trResponPoint.position) == false)
                {
                    trTargetPoint = trPatrolPoint;
                    isPatrol = true;
                }
            }
        }
        else
        {
            if (collider == null)
                PatrolProcess();
            else
                isPatrol = false;
        }
    }

    public void PatrolProcess()
    {
        if (trTargetPoint)
        {
            bool isMove = MoveProcess(trTargetPoint.position);

            if (trTargetPoint.gameObject.name == trResponPoint.gameObject.name)
            {
                if (isMove == false)
                    trTargetPoint = trPatrolPoint;
            }
            else if (trTargetPoint.gameObject.name == trResponPoint.gameObject.name)
            {
                if (isMove == false)
                    trTargetPoint = trPatrolPoint;
            }
        }
    }

    public bool MoveProcess(Vector3 vTargetPos)
    {
        Vector3 vPos = this.transform.position;
        Vector3 vDist = vTargetPos - vPos;//위치의 차이를 이용한 거리구하기
        Vector3 vDir = vDist.normalized;//두물체사이의 방향(평준화-거리를뺀 이동량)
        float fDist = vDist.magnitude; //두물체사이의 거리(스칼라-순수이동량)

        if (fDist > Time.deltaTime)//한프레임의 이동거리보다 클때만 이동한다.
        {
            transform.position += vDir * Speed * Time.deltaTime;
            return true;
        }
        else
            return false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if(collision.gameObject.tag == "Player")
        //{
        //    Vector3 vPos = this.transform.position;
        //    Vector3 vTargetPos = collision.transform.position;
        //    Vector3 vDist = vTargetPos - vPos;//위치의 차이를 이용한 거리구하기
        //    Vector3 vDir = vDist.normalized;//두물체사이의 방향(평준화-거리를뺀 이동량)
        //    float fDist = vDist.magnitude; //두물체사이의 거리(스칼라-순수이동량)

        //    if(fDist > Time.deltaTime)//한프레임의 이동거리보다 클때만 이동한다.
        //        transform.position += vDir * Speed * Time.deltaTime;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
    }
}
