using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnitStats : MonoBehaviour
{
    public Attributes attributes;
    public AttributeGrowth attriGrowth;
    public Level _level;
    public Health _health;
    public Mana _mana;
    public ManaRegneration _manaRegen;
    public HealthRegeneration _healthRegen;

    public Text health;
    public Text mana;
    public Text strength;
    public Text agility;
    public Text intelligence;
    public Text damage;
    public Text armor;
    public Text magicResistance;
    public Text movementSpeed;
    public Text level;
    public Text unitName;

    public Text manaRegenValue;
    public Text healthRegenValue;

    private GameObject targetObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InitializeStats(targetObject);
    }

    public void InitializeStats(GameObject _targetObject) 
    {
        if (targetObject)
        {
            _health = targetObject.GetComponent<Health>();
            health.text = (int)_health.GetHealth() + " / " + _health.maxHealth;
            if (targetObject.GetComponent<Mana>())
            {
                _mana = targetObject.GetComponent<Mana>();
                mana.text = (int)_mana.GetMana() + " / " + _mana.maxMana;
            }
            if (targetObject.GetComponent<ManaRegneration>())
            {
                _manaRegen = targetObject.GetComponent<ManaRegneration>();
                manaRegenValue.text = "+" + _manaRegen.manaRegenerationValue.ToString();
            }
            if (targetObject.GetComponent<HealthRegeneration>())
            {
                _healthRegen = targetObject.GetComponent<HealthRegeneration>();
                healthRegenValue.text = "+" + _healthRegen.healthRegenerationValue.ToString();
            }

        }
        targetObject = _targetObject;
        
        Attributes targetAttributes = _targetObject.GetComponent<Attributes>();
        _level = _targetObject.GetComponent<Level>();
        attriGrowth = _targetObject.GetComponent<AttributeGrowth>();
        attributes = targetAttributes;
        if (_targetObject.GetComponent<Attributes>().name != "Vengeful Spirit")
        {
            unitName.text = _targetObject.GetComponent<GameSide>().GetSide().ToString() + " " + targetAttributes.name;
        }
        else 
        {
            unitName.text = targetAttributes.name;
        }
       
       
        strength.text = targetAttributes.strength.ToString();
        agility.text = targetAttributes.agility.ToString();
        intelligence.text = targetAttributes.intelligence.ToString();
        damage.text = targetAttributes.damage.ToString();
        armor.text = targetAttributes.armor.ToString();
        magicResistance.text = targetAttributes.magicResistance.ToString();
        movementSpeed.text = targetAttributes.movementSpeed.ToString();
        
        if(_level != null)
            level.text = _level.currentLevel.ToString();


    }
}
