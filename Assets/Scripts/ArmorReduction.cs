using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorReduction : MonoBehaviour
{
    Attributes attributes;
    public float counter;
    public float duration;

    public bool isReducing;
    float baseArmor;
    // Start is called before the first frame update
    void Start()
    {
        attributes = GetComponent<Attributes>();
    }

    void Update()
    {
        if (isReducing) 
        {
            if (counter < duration)
            {
                counter += Time.deltaTime;
            }
            else
            {
                ArmorReturn();
                isReducing = false;
            }
        }
    }

    public void ArmorReduc(float _reducValue)
    {
        if (attributes != null)
        {
            baseArmor = attributes.armor;
            attributes.armor -= _reducValue;
            GameSpawner.instance.SpawnDamageText(attributes.transform.position + Vector3.up, "Armor Reduced", this.transform.gameObject);
        }
    }

    private void ArmorReturn()
    {
        if (attributes != null)
        {
            attributes.armor = baseArmor;
        }
    }
}
