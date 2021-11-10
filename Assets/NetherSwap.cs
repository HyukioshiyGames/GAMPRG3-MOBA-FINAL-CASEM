using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetherSwap : MonoBehaviour
{
    public GameObject targetEnemy;
    public GameObject caster;

    Vector3 tempCasterPos;
    Vector3 lastTargetSeen;

    // Update is called once per frame
    void Update()
    {

        if (targetEnemy != null)
        {
            lastTargetSeen = targetEnemy.transform.position;
        }


        if (Vector3.Distance(this.transform.position, lastTargetSeen) <= 0.1f)
        {
            if (targetEnemy.GetComponent<Creep>()) 
            {
                targetEnemy.GetComponent<Creep>().creepAnimator.UnplayBasicAttack();
                targetEnemy.GetComponent<Creep>().ChangeState(Creep.States.Walk);

                tempCasterPos = caster.transform.position;
                caster.transform.position = targetEnemy.transform.position;
                targetEnemy.transform.position = tempCasterPos;
                print("Swapped");
                Destroy(this.gameObject);
            }
        }
    }
}
