using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Creep : MonoBehaviour
{
    public enum CreepType { Melee,Ranged,SuperMelee,SuperRange,Seige,SuperSeige};
    public CreepType creepType;
    public enum States { Idle, Walk, Chase, Attack,Die};

    [SerializeField] private States currentState;

    public NavMeshAgent agent;
    public Attributes attributes;
    [SerializeField] private List<Transform> waypoints;
    private Vector3 lastWalkPositon;
    [SerializeField] Transform targetTransform;
    [SerializeField] GameObject targetEnemy;

    public float attackRange;
    public int tempDamage;
    public CreepAnimator creepAnimator;

    private float rotateVelocity;
    [SerializeField] private float rotateSpeedMovement;

    public GameObject rangedProjectile;
    public float currentTime;

    void Start()
    {
        currentState = States.Walk;
        SetMovementSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState) 
        {
            case States.Idle:
                //Do
                break;
            case States.Walk:
                Walk();
                break;
            case States.Chase:
                Chase();
                break;
            case States.Attack:
                Attack();
                break;
            case States.Die:
                Die();
                break;
        }
    }
    public void SetMovementSpeed() 
    {
        agent.speed = attributes.movementSpeed / 100;
    }
    public void InitializeWaypoints(List<Transform> _waypoints) 
    {
        waypoints = _waypoints;
    }

    private void Walk() 
    {
        if(targetTransform == null)
            targetTransform= GetNewTargetPosition();

        agent.SetDestination(targetTransform.position);
        if (Vector3.Distance(this.transform.position, targetTransform.position) <= agent.stoppingDistance) 
        {
            RemoveCurrentTargetFromWaypoint(targetTransform);
            targetTransform = null;
        }
    }

    Transform GetNewTargetPosition()
    {
        Transform targetPosition = waypoints.OrderBy(t => Vector3.Distance(this.transform.position,
            t.transform.position)).FirstOrDefault();


        return targetPosition;
    }

    private void RemoveCurrentTargetFromWaypoint(Transform _targetTransform) 
    {
        waypoints.Remove(_targetTransform);
    }
    public void ChangeState(States _nextState) 
    {
        currentState = _nextState;
    }
    private void Attack() 
    {
        if (!targetEnemy) 
        {
            agent.isStopped = false;

            ChangeState(States.Chase);
            creepAnimator.UnplayBasicAttack();
        }
        else 
        {
            agent.velocity = Vector3.zero;
            agent.isStopped = true;
            Quaternion characterRotation = Quaternion.LookRotation(targetEnemy.transform.position - transform.position);
            float yRotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, characterRotation.eulerAngles.y,
                ref rotateVelocity, rotateSpeedMovement * (Time.deltaTime) * 5);
            transform.eulerAngles = new Vector3(0, yRotation, 0);

            if(currentTime < attributes.baseAttackTime)
            {
                currentTime += Time.deltaTime;
            }
            else 
            {
                creepAnimator.PlayBasicAttack();
            }
        }
    }

    public void RangedAttack(Transform _spawnPoint, GameObject _target, int damage)
    {
        
        GameObject _normalProjectile = (GameObject)Instantiate
            (rangedProjectile, _spawnPoint.transform.position, Quaternion.identity);
        _normalProjectile.GetComponent<ProjectileMove>().targetEnemy = _target;
        _normalProjectile.GetComponent<ProjectileStats>().damage = attributes.damage;
        _normalProjectile.GetComponent<ProjectileStats>().attackType = "Physical";
        _normalProjectile.GetComponent<ProjectileMove>().caster = this.gameObject;


    }
    private void Chase() 
    {
        
        if (targetEnemy)
        {
            agent.SetDestination(targetEnemy.transform.position);
            if (Vector3.Distance(this.transform.position, targetEnemy.transform.position) < attackRange )
            {
                //ChangeState(States.Attack);
            }
            
        }
        else 
        {
            ChangeState(States.Walk);
        }
    }
    private void Die() 
    {
        Destroy(this.gameObject);
    }

    public void DealDamage() 
    {
        if(targetEnemy)
            targetEnemy.GetComponent<Health>().TakeDamage(attributes.damage,this.gameObject,null);
    }
    public GameObject GetTargetEnemy() 
    {
        return targetEnemy;
    }
    public CreepType GetCreepType() 
    {
        return creepType;
    }
    public void RemoveTarget(GameObject _target)
    {
        if (_target == targetEnemy)
        {
            targetEnemy = null;
            if (agent.isStopped)
                agent.isStopped = false;
        }
    }
    public void EnemyIsInRange(GameObject _target) 
    {
        targetEnemy = _target;
        ChangeState(States.Attack);
    }
    public void SetTargetEnemy(GameObject _target) 
    {
        if(targetEnemy == null) 
        {
            creepAnimator.UnplayBasicAttack();
            targetEnemy = _target;
            
            ChangeState(States.Chase);
        }
            
    }
}
