using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CreepAnimator : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    public Animator animator;
    private float smoothTime = 0.1f;
    public Creep creep;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float movementSpeed = navMeshAgent.velocity.magnitude / navMeshAgent.speed;
        animator.SetFloat("MovementSpeed", movementSpeed, smoothTime, Time.deltaTime);
    }

    public void PlayBasicAttack() 
    {
        animator.SetBool("BasicAttack", true);
    }

    public void UnplayBasicAttack() 
    {
        animator.SetBool("BasicAttack", false);
        creep.currentTime = 0;
    }
}
