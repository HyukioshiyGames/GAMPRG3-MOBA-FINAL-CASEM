using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackRange : MonoBehaviour
{
    public Attributes attributes;
    public SphereCollider sphereCollider;
    public Player player;

    private void Start()
    {
        SetRadius(attributes.attackRange);
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player.target) 
        {
            player.ChangeState(Player.States.Attack);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player.target)
        {
            player.ChangeState(Player.States.Chase);
        }
    }

    public void SetRadius(float _radius) 
    {
        sphereCollider.radius = _radius / 100;
    }
}
