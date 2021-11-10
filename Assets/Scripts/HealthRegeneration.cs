using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegeneration : MonoBehaviour
{
    public Attributes attributes;
    public float healthRegenerationValue;
    public Health health;
    // Start is called before the first frame update
    void Start()
    {
        healthRegenerationValue = attributes.healthRegeneration;
    }

    // Update is called once per frame
    void Update()
    {
        if(health.GetHealth() < health.maxHealth) 
        {
            health.AddHealth(healthRegenerationValue * Time.deltaTime);
        }
    }
    public void AddHealthRegen(float _value)
    {
        healthRegenerationValue += _value;
    }
}
