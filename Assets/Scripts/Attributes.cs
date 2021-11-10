using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    public enum PrimaryAttribute { None,Agility,Strength,Intelligence};
    public PrimaryAttribute unitPrimaryAttribute;

    public float attackTime;
    public float attackSpeed;
    public float attackRange;
    public float sightRange;
    public int health;
    public int damage;
    public int gold;
    public int structureLastHitBonus;
    public float strength;
    public float agility;
    public float intelligence;
    public float armor;
    public float magicResistance;
    public float movementSpeed;
    public float level;
    public float mana;
    public string name;
    public float experience;
    public float mrReduction;
    public float healthRegeneration;
    public float manaRegeneration;
    public float baseAttackTime;
    public float spellAmp;

    public float baseStrength;
    public float baseAgility;
    public float baseIntelligence;
   
    //attk speed 100 -200
    //agi 100
    //resulting  = 200
    // basee attack time - 1.7
    // Final attack interval 1.7 - 0.85
    // / 100
    // Start is called before the first frame update
    void Start()
    {
        baseStrength = strength;
        baseAgility = agility;
        baseIntelligence = intelligence;
    }


}
