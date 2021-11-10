using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeGrowth : MonoBehaviour
{
    public float attributePoints;

    public Attributes attributes;
    public float increaseStrength;
    public float increaseAgi;
    public float increaseInt;


    public void IncreaseAttribute()
    {
        attributes.strength += increaseStrength;
        attributes.agility += increaseAgi;
        attributes.intelligence += increaseInt;
    }

    public void AddAtributePoints()
    {
        attributePoints++;
    }
}
