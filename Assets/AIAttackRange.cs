using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttackRange : MonoBehaviour
{
    public Attributes attributes;
    public SphereCollider sphereCollider;
    public AI player;

    private void Start()
    {
        SetRadius(attributes.attackRange);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player.target)
        {
            player.ChangeState(AI.States.Attack);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player.target)
        {
            player.ChangeState(AI.States.Chase);
        }
    }

    public void SetRadius(float _radius)
    {
        sphereCollider.radius = _radius / 100;
    }
}
