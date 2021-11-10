using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterSpawner : MonoBehaviour
{
    public Barrack[] barracks;
    public GameObject[] normalWave;
    public GameObject[] seigeWave;

    public GameObject megaMelee;
    public GameObject megaRanged;
    public GameObject megaSeige;

    // Start is called before the first frame update
    void Start()
    {
        InitializeBarrackCreeps(normalWave);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeBarrackCreeps(GameObject [] _toSpawn) 
    {
        for (int i = 0; i < barracks.Length; i++)
            barracks[i].SetCreepsToSpawn(_toSpawn);
    }

    public void SpawnCreeps()
    {
        for (int i = 0; i < barracks.Length; i++) 
        {
            StartCoroutine(barracks[i].SpawnCreeps());
        }
    }

    public GameObject[] getSeigeWave()
    {
        return seigeWave;
    }
    public GameObject[] getNormalWave()
    {
        return normalWave;
    }
}
