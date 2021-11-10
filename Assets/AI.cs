using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
public class AI : MonoBehaviour
{

    public Attributes attributes;
    public PlayerAnimator animator;
    public PlayerSkillController playerSkillController;
    public PlayerInventory inventory;

    [SerializeField] private List<Transform> waypoints;
    public enum States { Idle,Walk, Chase, Attack, Die };
    public States currentState;

    [SerializeField] private GameSide gameSide;

    public NavMeshAgent navMeshAgent;

    private float rotateVelocity;
    [SerializeField] private float rotateSpeedMovement;

    public GameObject target;

    public Transform projectileSpawnpoint;

    public float currentTime;
    [SerializeField] Transform targetTransform;
    // Start is called before the first frame update
    void Start()
    {
        currentState = States.Idle;
        gameSide.SetSide(gameSide.GetSide());
        SetMovementSpeed();
    }

    public void SetMovementSpeed()
    {
        navMeshAgent.speed = attributes.movementSpeed / 100;
    }
    // Update is called once per frame
    void Update()
    {

        switch (currentState)
        {
            case States.Idle:
                //
                break;
            case States.Chase:
                Chase();
                break;
            case States.Walk:
                Walk();
                break;
            case States.Attack:
                Attack();
                break;
            case States.Die:
                //
                break;
        }
    }
    private void Walk()
    {
        if (targetTransform == null)
            targetTransform = GetNewTargetPosition();

        navMeshAgent.SetDestination(targetTransform.position);
        if (Vector3.Distance(this.transform.position, targetTransform.position) <= navMeshAgent.stoppingDistance)
        {
            RemoveCurrentTargetFromWaypoint(targetTransform);
            targetTransform = null;
        }
    }
    private void RemoveCurrentTargetFromWaypoint(Transform _targetTransform)
    {
        waypoints.Remove(_targetTransform);
    }
    Transform GetNewTargetPosition()
    {
        Transform targetPosition = waypoints.OrderBy(t => Vector3.Distance(this.transform.position,
            t.transform.position)).FirstOrDefault();


        return targetPosition;
    }
    private void Chase()
    {
        if (target)
        {
            navMeshAgent.SetDestination(target.transform.position);

        }
        else
        {
            ChangeState(States.Idle);
        }
    }

    private void Attack()
    {
        if (!target)
        {
            navMeshAgent.isStopped = false;
            ChangeState(States.Chase);
            animator.UnplayBasicAttack();
        }
        else
        {
            Quaternion characterRotation = Quaternion.LookRotation(target.transform.position - transform.position);
            float yRotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, characterRotation.eulerAngles.y,
                ref rotateVelocity, rotateSpeedMovement * (Time.deltaTime) * 5);
            transform.eulerAngles = new Vector3(0, yRotation, 0);

            navMeshAgent.isStopped = true;
            if (!playerSkillController.skillCasted)
            {
                //animator.PlayBasicAttack();
                if (currentTime < attributes.baseAttackTime)
                {
                    currentTime += Time.deltaTime;
                }
                else
                {
                    animator.PlayBasicAttack();
                }
            }

            else
            {
                playerSkillController.CheckSkillUsed();
            }

        }
    }

    public void CastNormalAttack()
    {
        if (target)
            playerSkillController.NormalAttack(projectileSpawnpoint, target, attributes.damage);

    }
    public void SetTarget(GameObject _targetHovered)
    {
        target = _targetHovered;
        ChangeState(States.Chase);
    }

    public void ChangeState(States _nextState)
    {
        currentState = _nextState;
    }

    public void GetGold(int _goldToAdd, Vector3 _coinSpawnPosition)
    {
        inventory.AddGold(_goldToAdd, _coinSpawnPosition);
    }
}
