using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    ProjectileStats projectileStats;

    public float projectileSpeed;
    public GameObject targetEnemy;

    public GameObject caster;
    Vector3 lastTargetSeen;

    private void Start()
    {
        projectileStats = GetComponent<ProjectileStats>();
    }
    private void Update()
    {
        if (targetEnemy != null) 
        {
            lastTargetSeen = targetEnemy.transform.position;
        }
            

        if (Vector3.Distance(this.transform.position, lastTargetSeen) > 0.1f)
        {
            //this.transform.position = Vector3.Lerp(this.transform.position, lastTargetSeen,
            //projectileSpeed * Time.deltaTime);
            this.transform.position = Vector3.MoveTowards(this.transform.position, lastTargetSeen,
                projectileSpeed * Time.deltaTime);
        }
        else 
        {
            if (targetEnemy)
                DealDamage();
            else
                Destroy(this.gameObject);
        }
    }

    private void DealDamage() 
    {
        if (targetEnemy.GetComponent<Health>())
        {
            targetEnemy.GetComponent<Health>().TakeDamage(projectileStats.damage, caster,GetComponent<ProjectileStats>());
        }
        Destroy(this.gameObject);
    }
}
