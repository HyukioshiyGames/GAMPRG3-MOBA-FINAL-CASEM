using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepHUD : MonoBehaviour
{

    public GameSide gameSide;

    public enum CreepType 
    {
        Melee,Ranged,Seige,SuperMelee,SuperRanged,SuperSeige
    }

    public CreepType creepType;

    public CreepType returnType()
    {
        return creepType;
    }
}
