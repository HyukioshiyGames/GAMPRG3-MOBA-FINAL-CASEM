using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillpointController : MonoBehaviour
{
    public Skills skills;
    public Level level;

    public Button [] addSkillButtons;
   

    // Update is called once per frame
    void Update()
    {
        if (level.currentSkillPoint > 0)
            EnableAllButtons();
        else
            DisableAllButtons();
    }

    public void EnableAllButtons()
    {
        if (skills.magicMissileSkillpoints < 4)
            addSkillButtons[0].gameObject.SetActive(true);
        else
            addSkillButtons[0].gameObject.SetActive(false);
        if (skills.waveOfTerrorSkillpoints < 4)
            addSkillButtons[1].gameObject.SetActive(true);
        else
            addSkillButtons[1].gameObject.SetActive(false);
        if (skills.vengeanceAuraSkillpoints < 4)
            addSkillButtons[2].gameObject.SetActive(true);
        else
            addSkillButtons[2].gameObject.SetActive(false); 
        if (skills.netherSwapSkillpoints < 3)
            addSkillButtons[3].gameObject.SetActive(true);
        else
            addSkillButtons[3].gameObject.SetActive(false);

        addSkillButtons[4].gameObject.SetActive(true);



    }

    public void DisableAllButtons()
    {
        for (int i = 0; i < addSkillButtons.Length; i++)
        {
            if(addSkillButtons[i].gameObject.activeSelf)
                addSkillButtons[i].gameObject.SetActive(false);
        }
    }
    public void AddWaveSkillpoint()
    {
        skills.AddWaveOfTerror();
        level.currentSkillPoint--;
    }
    public void AddMissileSkillpoint()
    {
        skills.AddMagicMissile();
        level.currentSkillPoint--;
    }
    public void AddVengeanceAura()
    {
        skills.AddVengeanceAura();
        level.currentSkillPoint--;
    }

    public void AddNetherSwap() 
    {
        skills.AddNetherSwap();
        level.currentSkillPoint--;
    }
}
