using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveOfTerror : MonoBehaviour
{
    public GameObject targetEnemy;
    public float duration;
    public float armorReducValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ArmorReduction>())
        {
            other.GetComponent<ArmorReduction>().counter = 0;
            other.GetComponent<ArmorReduction>().duration += duration;
            other.GetComponent<ArmorReduction>().isReducing = true;
            other.GetComponent<ArmorReduction>().ArmorReduc(armorReducValue);

        }
    }
}
