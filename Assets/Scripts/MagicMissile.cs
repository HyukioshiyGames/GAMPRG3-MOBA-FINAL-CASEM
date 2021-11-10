using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMissile : MonoBehaviour
{
    public GameObject targetEnemy;
    public float duration;
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
            if (targetEnemy.GetComponent<Stun>()) 
            {
                targetEnemy.GetComponent<Stun>().counter = 0;
                targetEnemy.GetComponent<Stun>().duration += duration;
                print("Stun Applied");
            }
        }
    }
}
