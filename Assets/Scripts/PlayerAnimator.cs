using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    public Animator animator;
    public Player player;
    private float smoothTime = 0.1f;
    
    // Update is called once per frame
    void Update()
    {
        float movementSpeed = navMeshAgent.velocity.magnitude / navMeshAgent.speed;
        animator.SetFloat("MovementSpeed", movementSpeed,smoothTime, Time.deltaTime);
    }

    public void PlayBasicAttack() 
    {
        animator.SetBool("BasicAttack", true); 
    }
    public void UnplayBasicAttack() 
    {
        animator.SetBool("BasicAttack", false);
        player.currentTime = 0;
    }

    public void UnplaySkill()
    {
        animator.SetBool("SkillAttack", false);
        
    }

}
