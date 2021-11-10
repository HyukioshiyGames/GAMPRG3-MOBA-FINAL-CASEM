using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Attributes attributes;

    public float maxHealth;
    [SerializeField]
    private float currentHealth;
    public Slider healthSlide;
    // Start is called before the first frame update
    void Start()
    {
        InitializeHealth();
        if(!attributes)
            attributes = GetComponent<Attributes>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaxHealth(float _maxHealth) 
    {
        maxHealth = _maxHealth;
    }

    public void InitializeHealth() 
    {
        maxHealth = attributes.health;
        if(maxHealth != 0)
        {
            currentHealth = maxHealth;
            healthSlide.maxValue = currentHealth;
            healthSlide.value = currentHealth;
        }
    }

    float CalculatePhysicalDamage(int _damage) 
    {
        float damageMultiplier = 1 - ((0.052f * attributes.armor) / (0.9f + 0.048f * Mathf.Abs(attributes.armor)));
        float calculatedDamage = damageMultiplier * _damage;
        return calculatedDamage;
    }

    float CalculateMagicDamage(int _damage) 
    {
        float resistance = 1 * (1 - attributes.magicResistance);
        float reduction = 1 * (1 - attributes.mrReduction);
        float finalResistance = 1 - (resistance * reduction);
        //Translate magic to damage modifier 
        float magicResReductionDamage = _damage *( 1- attributes.magicResistance);
        float calculatedDamage = _damage - magicResReductionDamage;

        return calculatedDamage;
    }
    public void TakeDamage(int _damage, GameObject _killer,ProjectileStats _projectile) 
    {
        float damageTaken = 1 ;
        if(_projectile != null) 
        {
            if (_killer.GetComponent<Tower>() || _projectile.attackType == "Physical")
            {
                damageTaken = CalculatePhysicalDamage(_damage);
                currentHealth -= damageTaken;
            }
            else
            {
                if(_projectile.attackType == "Magic") 
                {
                    damageTaken = CalculateMagicDamage(_damage);
                    currentHealth -= damageTaken;
                   
                }
            }
        }
        else 
        {
            currentHealth -= CalculatePhysicalDamage(_damage);

        }

        healthSlide.value = currentHealth;
        SpawnDamageText((int)damageTaken);

        if (currentHealth <= 0) 
        {
            if (this.GetComponent<Creep>())
            {
                ObjectObserver.instance.RemoveCreepToList(this.gameObject);
            }
            if (_killer != null) 
            {
                if (this.gameObject.GetComponent<Tower>()) 
                {
                    TowerDestroyed(_killer);
                    this.gameObject.GetComponent<Tower>().TowerDestroyed();


                }
                else if (this.GetComponent<BarrackSubordinate>()) 
                {
                    BarrackDestroyed(_killer);
                }
                else if (this.gameObject.GetComponent<Ancient>()) 
                {
                    this.gameObject.GetComponent<Ancient>().DestroyThis();
                }
                else 
                {
                    if (_killer.GetComponent<Attributes>().name == "VengefulSpirit")
                    {
                        _killer.GetComponent<Player>().GetGold(GetComponent<Attributes>().gold, this.transform.position + Vector3.up * 1.5f);
                    }
                }
                
            }
            Destroy(this.gameObject);
            
        }
    }
    public void ResetHealth() 
    {
        currentHealth = maxHealth;
    }

    public void TowerDestroyed(GameObject _killer)
    {
        this.gameObject.GetComponent<Tower>().TowerDestroyed();
        GameManager.instance.TowerDestroyed(attributes.gold,this.gameObject.GetComponent<GameSide>());

        if (_killer.transform.name == "Player")
        {
            _killer.GetComponent<Player>().GetGold(GetComponent<Attributes>().structureLastHitBonus, this.transform.position + Vector3.up * 1.5f);
        }
        Destroy(this.gameObject);
    }
    public void ManualTowerDestroy()
    {
        this.gameObject.GetComponent<Tower>().TowerDestroyed();
        GameManager.instance.TowerDestroyed(attributes.gold, this.gameObject.GetComponent<GameSide>());
        
        Destroy(this.gameObject);
    }

    public void BarrackDestroyed(GameObject _killer) 
    {
        this.gameObject.GetComponent<BarrackSubordinate>().OnDestroyThisObject();
        GameManager.instance.TowerDestroyed(attributes.gold, this.gameObject.GetComponent<GameSide>());

        if (_killer.transform.name == "Player")
        {
            _killer.GetComponent<Player>().GetGold(GetComponent<Attributes>().structureLastHitBonus, this.transform.position + Vector3.up * 1.5f);
        }
        Destroy(this.gameObject);
    }

    public float GetHealth()
    {
        return currentHealth;
    }
    public void AddHealth(float _value)
    {
        currentHealth += _value;
        healthSlide.value = currentHealth; 

    }
    private void SpawnDamageText(int _damage) 
    {
        GameSpawner.instance.SpawnDamageText(this.gameObject.transform.position + Vector3.up * 2.5f ,"-" + _damage.ToString(),this.gameObject);
        
    }
}
