using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Player : MonoBehaviour
{

    public Attributes attributes;
    public PlayerAnimator animator;
    public PlayerSkillController playerSkillController;
    public PlayerInventory inventory;
    public CameraControls cameraControls;
    public HUDSelection hudSelection;
    public UnitStats unitStats;
    public CursorController cursorController;
    

    public enum States { Idle, Chase, Attack, Die};
    public States currentState;

    [SerializeField] private GameSide gameSide;
    Vector3 worldPosition;
    Ray ray;
    public RaycastHit hitData;
    public NavMeshAgent navMeshAgent;

    private float rotateVelocity;
    [SerializeField] private float rotateSpeedMovement;

    public GameObject targetHovered;
    public GameObject allyHovered;

    public GameObject target;

    public Transform projectileSpawnpoint;

    public float currentTime;

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
        MovePlayer();

        switch (currentState) 
        {
            case States.Idle:
                //
                break;
            case States.Chase:
                Chase();
                break;
            case States.Attack:
                Attack();
                break;
            case States.Die:
                //
                break;
        }
    }

    public void MovePlayer() 
    {
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            navMeshAgent.SetDestination(this.transform.position);
            if (target)
            {
                target = null;
                
            }
            animator.UnplayBasicAttack();

            ChangeState(States.Idle);

        }
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        

        if (Physics.Raycast(ray, out hitData, 1000))
        {
            worldPosition = hitData.point;

            if (hitData.collider.gameObject.GetComponent<GameSide>())
            {
                if (hitData.collider.gameObject.GetComponent<GameSide>().GetSide() != gameSide.GetSide())
                {
                    targetHovered = hitData.collider.gameObject;
                    
                }
                else 
                {
                    allyHovered = hitData.collider.gameObject;
                }
                if (Input.GetMouseButtonDown(0)) 
                {
                    if (cursorController.currentCursor.sprite != cursorController.targetCursor) 
                    {
                        hudSelection.InitializeHUDContent(hitData.collider.gameObject);
                        unitStats.InitializeStats(hitData.collider.gameObject);
                    }
                }
            }
            else
            {
                targetHovered = null;
            }
            if (Input.GetMouseButtonDown(1))
            {
                cameraControls.SelectPlayerWithoutKey();
                if (currentState != States.Idle)
                {

                    if (target)
                        target = null;
                    if (navMeshAgent.isStopped == true)
                        navMeshAgent.isStopped = false;
                    animator.UnplayBasicAttack();
                    ChangeState(States.Idle);

                }

                navMeshAgent.SetDestination(worldPosition);
                Quaternion characterRotation = Quaternion.LookRotation(hitData.point - transform.position);
                float yRotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, characterRotation.eulerAngles.y,
                    ref rotateVelocity, rotateSpeedMovement * (Time.deltaTime) * 5);


                this.transform.eulerAngles = new Vector3(0, yRotation, 0);
                GameSpawner.instance.SpawnPointIndicator(hitData.point + Vector3.up);

            }    
        }
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
            playerSkillController.NormalAttack(projectileSpawnpoint,target,attributes.damage);
            
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

    public void GetGold(int _goldToAdd,Vector3 _coinSpawnPosition) 
    {
        inventory.AddGold(_goldToAdd,_coinSpawnPosition);
    }
}
