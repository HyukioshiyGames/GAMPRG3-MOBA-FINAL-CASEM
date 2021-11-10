using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaRegneration : MonoBehaviour
{
    public Attributes attributes;
    public float manaRegenerationValue;
    public Mana mana;

    private void Start()
    {
        manaRegenerationValue = attributes.manaRegeneration;
    }
    // Update is called once per frame
    void Update()
    {
        mana.AddMana(manaRegenerationValue * Time.deltaTime);
    }
    public void AddManaRegen(float _value) 
    {
        manaRegenerationValue += _value;
    }
}
