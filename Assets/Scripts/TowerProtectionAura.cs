using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProtectionAura : MonoBehaviour
{
    public float towerArmorBonus;
    public GameSide gameSide;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GameSide>()) 
        {
            if (other.GetComponent<GameSide>().GetSide() == gameSide.GetSide())
            {
                other.GetComponent<Attributes>().armor += towerArmorBonus;

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<GameSide>())
        {
            if (other.GetComponent<GameSide>().GetSide() == gameSide.GetSide())
            {
                other.GetComponent<Attributes>().armor -= towerArmorBonus;
            }
        }
    }
}
