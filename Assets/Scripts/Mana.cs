using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public Attributes attributes;

    public float maxMana;
    [SerializeField]
    private float currentMana;
    public Slider manaSlider;
    // Start is called before the first frame update
    void Start()
    {
        InitializeMana();
        if (!attributes)
            attributes = GetComponent<Attributes>();
    }


    public void SetmaxMana(float _maxMana)
    {
        maxMana = _maxMana;
    }

    public void InitializeMana()
    {
        maxMana = attributes.mana;
        if (maxMana != 0)
        {
            currentMana = maxMana;
            manaSlider.maxValue = currentMana;
            manaSlider.value = currentMana;
        }
    }

    public void DeductMana(float _manaCost)
    {
        currentMana -= _manaCost;
        manaSlider.value = currentMana;
    }

    public void AddMana(float _value) 
    {
        currentMana += _value;
        manaSlider.value = currentMana;
    }

    public void ResetMana() 
    {
        currentMana = maxMana;
        manaSlider.value = currentMana;
    }
    public float GetMana() 
    {
        return currentMana;
    }

   
}
