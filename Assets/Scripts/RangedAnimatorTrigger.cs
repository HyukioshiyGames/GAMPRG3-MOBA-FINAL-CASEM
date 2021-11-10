using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAnimatorTrigger : MonoBehaviour
{
    private Creep creep;
    public Attributes attributes;

    public CreepAnimator creepAnimator;
    public Transform projectileSpawnpoint;
    // Start is called before the first frame update
    void Start()
    {
        creep = GetComponentInParent<Creep>();
    }

    public void SpawnRangedProjectile()
    {
        creep.RangedAttack(projectileSpawnpoint,creep.GetTargetEnemy(),attributes.damage);
    }

    public void UnplayAttack()
    {
        creepAnimator.UnplayBasicAttack();
    }
}
