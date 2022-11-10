using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Responner resoponnerPlayer;
    public List<Responner> responnerMonsters;

    public enum E_MONSTER{ OPPOSUM, EAGLE, FROG }

    public Responner GetRespnner(E_MONSTER monsterIdx)
    {
        return responnerMonsters[(int)monsterIdx];
    }

    public Transform trPatrolPoint;

    public void ProcessSetPatrol()
    {
        Responner responEagle = GetRespnner(E_MONSTER.EAGLE);

        if(responEagle && responEagle.objTarget)
        {
            Eagle eagle = responEagle.objTarget.GetComponent<Eagle>();

            if (eagle && eagle.trPatrolPoint == null)
            {
                eagle.trPatrolPoint = trPatrolPoint;
                eagle.trResponPoint = responEagle.transform;
                //eagle.SetState(Eagle.E_AI_STATUS.RETURN);
                Debug.Log("SetPatrol");
            }
        } 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessSetPatrol();
    }
}
