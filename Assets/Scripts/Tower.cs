using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Attributes attributes;

    public enum States { Idle, Attacking , Destroyed}
    [SerializeField] private States currentState;

    [SerializeField] private GameObject targetEnemy;
    public GameObject towerProjectile;

    [SerializeField] private float counter;
    public Transform projectileSpawnpoint;

    [SerializeField] private int towerDamage;

    public GameObject radiantCrystal;
    public GameObject direCrystal;

    [SerializeField] private GameSide gameSide;

    public GameObject [] nextTowers;
    private void OnEnable()
    {
        InitializeTower();
    }
    // Update is called once per frame
    void Update()
    {
        switch (currentState) 
        {
            case States.Idle:
                Idle();
                break;
            case States.Attacking:
                Attack();
                break;
            case States.Destroyed:
                break;
        }
    }

    private void Idle() 
    { 

    }
    private void Attack() 
    {
        if (!targetEnemy)
        {
           // StopAllCoroutines();
            ChangeState(States.Idle);
        }
        else 
        {
            if (counter < attributes.baseAttackTime)
            {
                counter += Time.deltaTime;
            }
            else 
            {
                SpawnProjectile();
                counter = 0;
            }
        }
    }
    public void SetTargetEnemy(GameObject _target)
    {
        if (!targetEnemy) 
        {
            targetEnemy = _target;
            counter = 0;
            ChangeState(States.Attacking);
        }

    }

    private void SpawnProjectile() 
    {
        GameObject projectilePrefab = (GameObject)Instantiate(towerProjectile, projectileSpawnpoint.position, Quaternion.identity);
        projectilePrefab.GetComponent<ProjectileMove>().targetEnemy = targetEnemy;
        projectilePrefab.GetComponent<ProjectileStats>().damage = towerDamage;
        projectilePrefab.GetComponent<ProjectileMove>().caster = this.gameObject;
    }

    public void RemoveTarget(GameObject _target)
    {
        if (_target == targetEnemy) 
        {
            targetEnemy = null;
        }
    }
    private void ChangeState(States _nextState)
    {
        currentState = _nextState;
    }

    private void InitializeTower() 
    {
        if (gameSide.GetSide().ToString() == "Radiant")
        {
            direCrystal.SetActive(false);
            radiantCrystal.SetActive(true);
        }

        else 
        {
            radiantCrystal.SetActive(false);
            direCrystal.SetActive(true);
        }
        this.transform.tag = gameSide.GetSide().ToString();

    }

    public void TowerDestroyed() 
    {
        for (int i = 0; i < nextTowers.Length; i++)
        {
            nextTowers[i].GetComponent<SphereCollider>().enabled = true;
        }
    }
}
