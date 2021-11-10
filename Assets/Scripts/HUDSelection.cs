using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDSelection : MonoBehaviour
{
    public UnitStats unitStats;
    public GameObject[] toSpawn;

    public GameObject playerModel;
    public GameObject meleeCreep;
    public GameObject rangedCreep;
    public GameObject tower;
    public GameObject barracks;

    public GameObject selectedObject;
    public GameObject currentActive;

    private void Start()
    {
        EnableModel(playerModel);
    }
    private void DisableCurrentActive() 
    {
        if(currentActive)
            currentActive.SetActive(false);

    }


    public void EnableModel(GameObject _model)
    {
        DisableCurrentActive();
        if (_model.activeSelf == false) 
        {
            currentActive = _model;
            currentActive.SetActive(true);
        }
    }
    private void InitializeGameSide(GameObject _targetObject,GameObject _referenceObject) 
    {
        _targetObject.GetComponent<GameSide>().SetSide(_referenceObject.GetComponent<GameSide>().GetSide());
    }
    public void InitializeHUDContent(GameObject _targetObject) 
    {
        unitStats.InitializeStats(_targetObject);
        if (_targetObject.GetComponent<Tower>())
        {
            InitializeGameSide(tower, _targetObject);
            EnableModel(tower);
        }

        else if (_targetObject.GetComponent<Player>()) 
        {
            EnableModel(playerModel);
        }
        else if (_targetObject.GetComponent<Creep>()) 
        {
            if (_targetObject.GetComponent<Creep>().creepType ==Creep.CreepType.Melee)
                EnableModel(meleeCreep);
            if (_targetObject.GetComponent<Creep>().creepType ==Creep.CreepType.Ranged)
                EnableModel(rangedCreep);

        }
        else if (_targetObject.GetComponent<BarrackSubordinate>()) 
        {
            InitializeGameSide(barracks, _targetObject);
            EnableModel(barracks);
        }


        
            

    }
}
