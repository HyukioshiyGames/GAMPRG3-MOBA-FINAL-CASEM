using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrack : MonoBehaviour
{
    MasterSpawner masterSpawner;
    [SerializeField] private GameSide gameSide;
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private Transform waypointParent;
    [SerializeField] private Transform spawnpoint;

    public GameObject radiantCrystal;
    public GameObject direCrystal;

    public Barrack enemyTargetBarrack;

    public GameObject [] creepsToSpawn;

    public GameObject meleeBarracks;
    public GameObject rangedBarracks;

    public bool isMegaMelee;
    public bool isMegaRanged;
    public bool isMegaSeige;

    private float creepSpawnInterval = 0.4f;
    private void Awake()
    {
        if(!masterSpawner)
            masterSpawner = FindObjectOfType<MasterSpawner>();
        GetTransformChild();
        

        isMegaMelee = false;
        isMegaRanged = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(SpawnCreeps());
        }
    }

    public void SetCreepWaypoints(GameObject _creepObject)
    {
        Creep _targetCreep;
        _targetCreep = _creepObject.GetComponent<Creep>();
        _targetCreep.InitializeWaypoints(waypoints);
    }

    private void SpawnCreep(int _index) 
    {
        GameObject toSpawnCreep;
        toSpawnCreep = creepsToSpawn[_index];
        if (isMegaMelee)
        {
            if(toSpawnCreep.GetComponent<Creep>().GetCreepType() == Creep.CreepType.Melee) 
            {
                toSpawnCreep = masterSpawner.megaMelee;
            }
        }
        if (isMegaRanged) 
        {
            if (toSpawnCreep.GetComponent<Creep>().GetCreepType() == Creep.CreepType.Ranged)
            {
                toSpawnCreep = masterSpawner.megaRanged;
            }
            if (toSpawnCreep.GetComponent<Creep>().GetCreepType() == Creep.CreepType.Seige)
            {
                toSpawnCreep = masterSpawner.megaSeige;
            }
        }
        GameObject spawnedCreep = (GameObject)Instantiate(toSpawnCreep, spawnpoint.transform.position, Quaternion.identity);
        spawnedCreep.GetComponent<GameSide>().SetSide(gameSide.GetSide());
        SetCreepWaypoints(spawnedCreep);
        ObjectObserver.instance.AddCreepToList(spawnedCreep);
    }

    private void GetTransformChild()
    {
        for(int i = 0; i < waypointParent.childCount; i++)
        {
            waypoints.Add(waypointParent.GetChild(i).transform);
        }
    }

    public IEnumerator SpawnCreeps() 
    {
        int spawnCounter = 0;
        while(spawnCounter < creepsToSpawn.Length) 
        {
            SpawnCreep(spawnCounter);
            spawnCounter++;
            yield return new WaitForSeconds(creepSpawnInterval);
            
        }
    }
    public void SetCreepsToSpawn(GameObject [] _toSpawn) 
    {
        creepsToSpawn = _toSpawn;
    }

    public void MeleeBarracksDestroyed() 
    {
        meleeBarracks = null;
        enemyTargetBarrack.isMegaMelee = true;
        GameSpawner.instance.SpawnMegaCreepsText(enemyTargetBarrack.name + " Mega Melee Creeps Activated");
    }
    public void RangedBarracksDestroyed() 
    {
        rangedBarracks = null;
        enemyTargetBarrack.isMegaRanged = true;
        enemyTargetBarrack.isMegaSeige = true;
        GameSpawner.instance.SpawnMegaCreepsText(enemyTargetBarrack.name + " Mega Ranged Creeps Activated");
    }
}
