using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToolTip : MonoBehaviour
{
    public UnitStats unitStats;

    public Text attackSpeed;
    public Text damage;
    public Text attackRange;
    public Text spellAmp;
    public Text manaRegen;

    public Text armor;
    public Text physicalResist;
    public Text magicResist;
    public Text statusResist;
    public Text evasion;
    public Text healthRegen;

    public Text baseSTR;
    public Text baseAGI;
    public Text baseINT;

    public Text strDetails;
    public Text intDetails;
    public Text agiDetails;

    public Text strGrowthDetails;
    public Text agiGrowthDetails;
    public Text intGrowthDetails;

    // Start is called before the first frame update
    private void Start()
    {
        this.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        unitStats = GameObject.FindObjectOfType<UnitStats>();
        InitializeToolTip();
        InitializeBaseValues();
    }

    void InitializeToolTip() 
    {
        attackRange.text = unitStats.attributes.attackRange.ToString();
        attackSpeed.text = unitStats.attributes.attackSpeed.ToString();
        damage.text = unitStats.attributes.damage.ToString();
        manaRegen.text = unitStats.attributes.manaRegeneration.ToString();
        armor.text = unitStats.attributes.armor.ToString();
        healthRegen.text = unitStats.attributes.healthRegeneration.ToString();

    }

    void InitializeBaseValues() 
    {
        baseSTR.text = unitStats.attributes.baseStrength.ToString();
        baseAGI.text = unitStats.attributes.baseAgility.ToString();
        baseINT.text = unitStats.attributes.baseIntelligence.ToString();

        strDetails.text = "= " + unitStats._health.maxHealth + " Health," +
            unitStats.attributes.healthRegeneration + " HP Regen and " + unitStats.attributes.magicResistance + " Magic Res";
        agiDetails.text = "= " + unitStats.attributes.damage + " damage (Primary Role Bonus) \n "
            + "= " + unitStats.attributes.armor + " Armor ," + unitStats.attributes.attackSpeed + " Attack Speed and " +
            unitStats.attributes.movementSpeed + " Movement Speed";
        intDetails.text = "= " +unitStats._mana.maxMana + " Mana," + unitStats.attributes.manaRegeneration
            + " Mana Regen and " + unitStats.attributes.spellAmp + "%" + "Spell Amp";

        strGrowthDetails.text = "(Gains " + unitStats.attriGrowth.increaseStrength +
            " Strength per Level)";
        agiGrowthDetails.text = "(Gains " + unitStats.attriGrowth.increaseAgi +
            " Agility per Level)";
        intGrowthDetails.text = "(Gains " + unitStats.attriGrowth.increaseInt +
            " Intelligence per Level)";
    }
}
