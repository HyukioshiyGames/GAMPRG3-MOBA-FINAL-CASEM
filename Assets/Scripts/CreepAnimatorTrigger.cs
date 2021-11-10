using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepAnimatorTrigger : MonoBehaviour
{
    private Creep creep;
    public CreepAnimator creepAnimator;
    // Start is called before the first frame update
    void Start()
    {
        creep = GetComponentInParent<Creep>();
    }

    public void DealMeleeDamage()
    {
        creep.DealDamage();
    }

    public void UnplayAttack()
    {
        creepAnimator.UnplayBasicAttack();
    }
}
