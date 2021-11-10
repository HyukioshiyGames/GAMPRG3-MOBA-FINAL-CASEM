using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeCalculator : MonoBehaviour
{
    public Attributes attributes;
    public AttributeGrowth attributeGrowth;
    public Health health;
    public Mana mana;

    public Level level;
     

    public void CalculateStats()
    {
        attributeGrowth.AddAtributePoints();
        health.maxHealth += attributeGrowth.attributePoints * 20;
        attributes.healthRegeneration += attributeGrowth.attributePoints * 0.1f;
        if (attributes.unitPrimaryAttribute == Attributes.PrimaryAttribute.Strength)
            attributes.damage += (int)attributeGrowth.attributePoints * 1;

        attributes.armor += attributeGrowth.attributePoints * 0.16f;
        attributes.attackSpeed += attributeGrowth.attributePoints * 1;
        if (attributes.unitPrimaryAttribute == Attributes.PrimaryAttribute.Agility)
            attributes.damage += (int)attributeGrowth.attributePoints * 1;

        mana.maxMana += attributeGrowth.attributePoints * 12;
        attributes.manaRegeneration += attributeGrowth.attributePoints * 0.05f;
        if (attributes.unitPrimaryAttribute == Attributes.PrimaryAttribute.Intelligence)
            attributes.damage += (int)attributeGrowth.attributePoints * 1;
        level.currentSkillPoint--;

    }

}
