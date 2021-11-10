using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : MonoBehaviour
{
    public Creep creep;
    public float counter;
    public float duration;

    // Start is called before the first frame update
    void Start()
    {
        creep = this.GetComponent<Creep>();
    }

    // Update is called once per frame
    void Update()
    {
        if(counter < duration) 
        {
            counter += Time.deltaTime;
            StunEffect();
        }
        else 
        {
            RemoveStun();
        }
    }

    private void StunEffect() 
    { 
        if(creep != null)
        {
            creep.creepAnimator.UnplayBasicAttack();
            creep.agent.isStopped = true;
            creep.enabled = false;

            GameSpawner.instance.SpawnDamageText(creep.transform.position + Vector3.up, "Stunned",this.transform.gameObject);
        }
    }

    private void RemoveStun() 
    {
        if (creep != null)
        {
            creep.agent.isStopped = false;
            creep.enabled = true;
        }
    }
}
