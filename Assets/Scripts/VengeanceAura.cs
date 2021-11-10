using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VengeanceAura : MonoBehaviour
{
    public float attackRangeBonus;
    public float attackDamageBonus;
 

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Creep>()) 
        {
            if (other.GetComponent<Creep>().creepType == Creep.CreepType.Ranged ||
            other.GetComponent<Creep>().creepType == Creep.CreepType.Seige ||
            other.GetComponent<Creep>().creepType == Creep.CreepType.SuperRange ||
            other.GetComponent<Creep>().creepType == Creep.CreepType.SuperSeige)
            {
                
                if (other.GetComponent<GameSide>()) 
                {
                    if (other.GetComponent<GameSide>().GetSide() == GetComponentInParent<GameSide>().GetSide())
                    {
                        other.GetComponent<Attributes>().attackRange += 50;
                        other.GetComponent<Attributes>().damage += 5;
                        GameSpawner.instance.SpawnDamageText(other.transform.position + Vector3.up, "Vengeance Aura", other.gameObject);

                    }
                }
            }
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Creep>())
        {
            if (other.GetComponent<Creep>().creepType == Creep.CreepType.Ranged ||
            other.GetComponent<Creep>().creepType == Creep.CreepType.Seige ||
            other.GetComponent<Creep>().creepType == Creep.CreepType.SuperRange ||
            other.GetComponent<Creep>().creepType == Creep.CreepType.SuperSeige)
            {
                if (other.GetComponent<GameSide>())
                {
                    if (other.GetComponent<GameSide>().GetSide() == this.GetComponentInParent<GameSide>().GetSide())
                    {
                        other.GetComponent<Attributes>().attackRange -= 50;
                        other.GetComponent<Attributes>().damage -= 5;
                        GameSpawner.instance.SpawnDamageText(other.transform.position + Vector3.up, "Aura Removed", other.gameObject);
                    }
                }
            }
        }
    }
}
