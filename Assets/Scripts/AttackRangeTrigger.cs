using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeTrigger : MonoBehaviour
{
    [SerializeField] private Creep creep;
    [SerializeField] private Tower tower;

    [SerializeField] private GameSide gameSide;
    public Attributes attributes;

    private void Start()
    {
        this.GetComponent<SphereCollider>().radius = attributes.attackRange / 100;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<GameSide>())
        {
            if (other.GetComponent<GameSide>().GetSide() != gameSide.GetSide() && other.GetComponent<Health>() != null)
            {
                if (creep != null)
                {
                    creep.EnemyIsInRange(other.gameObject);
                
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<GameSide>())
        {
            if (other.GetComponent<GameSide>().GetSide() != gameSide.GetSide() && other.GetComponent<Health>() != null)
            {
                if (creep != null)
                {
                    creep.RemoveTarget(other.gameObject);
                    creep.SetTargetEnemy(other.gameObject);


                }
            }
        }

    }
}
