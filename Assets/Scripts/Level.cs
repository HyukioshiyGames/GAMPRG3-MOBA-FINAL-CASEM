using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public float[] expRequired;
    public float currentExp;

    public int currentLevel = 0;
    public int currentSkillPoint = 0;

    public AttributeGrowth attributeGrowth;

    // Start is called before the first frame update
    void Start()
    {
        LevelUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            LevelUp();
    }
    public void LevelUp() 
    {
        currentLevel++;
        currentSkillPoint++;

        if(attributeGrowth)
            attributeGrowth.IncreaseAttribute();

    }
    
}
