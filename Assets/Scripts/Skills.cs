using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Skills : MonoBehaviour
{
    public PlayerSkillController playerSkillController;
    public Animator animator;

    [Header("Wave of Terror")]
    public Image waveOfTerrorImage;
    public float waveOfTerrorCD;
    public bool waveOfTerrorOnCD;
    public bool waveOfTerrorCasted;
    public bool waveOfTerrorUsed;
    public KeyCode waveOfTerrorHotkey;
    public GameObject waveProjectile;
    public int waveOfTerrorDamage;
    public int waveRange;
    public float waveManaCost;
    public int waveOfTerrorSkillpoints;
    public float waveOfTerrorDuration;
    public float armorReducValue;
    public LevelIndicator waveLevelIndicator;

    [Header("Magic Missile")]
    public Image magicMissileImage;
    public float magicMissileCD;
    public bool magicMissileOnCD;
    public bool magicMissileCasted;
    public bool magicMissileUsed;
    public KeyCode magicMissileHotkey;
    public GameObject magicMissileProjectile;
    public int magicMissileDamage;
    public int magicMissileRange;
    public float magicMissileManaCost;
    private bool skillIsCasted;
    public int magicMissileSkillpoints;
    public float magicMissileStunDuration;
    public LevelIndicator magicMissileLevelIndicator;

    [Header("Vengeance Aura")]
    public float attackRangeBonus;
    public float attackDamageBonus;
    public int vengeanceAuraSkillpoints;
    public VengeanceAura vengeanceAura;
    public Image vengeanceAuraImage;
    public LevelIndicator auraLevelIndicator;

    [Header("Nether Swap")] 
    public Image netherSwapImage;
    public float netherSwapCD;
    public bool netherSwapOnCD;
    public bool netherSwapCasted;
    public bool netherSwapUsed;
    public KeyCode netherSwapHotkey;
    public GameObject netherSwapProjectile;
    public int netherSwapRange;
    public float netherSwapManaCost;
    public int netherSwapSkillpoints;
    public LevelIndicator netherSwapLevelIndicator;

    // Update is called once per frame
    void Update()
    {
        if(waveOfTerrorSkillpoints > 0)
            WaveOfTerror();
        if(magicMissileSkillpoints > 0)
            MagicMissile();
        if (vengeanceAuraSkillpoints > 0)
            VengeanceAura();
    }

    public void SetSkillCD(bool _skillUsed, bool _skillOnCD, float _skillCooldown,Image _skillImage) 
    {
        if (_skillUsed && !_skillOnCD)
        {
            _skillOnCD = true;
            _skillImage.fillAmount = 0;
        }

        if (_skillOnCD)
        {
            _skillImage.fillAmount += 1 / _skillCooldown * Time.deltaTime;

            if (_skillImage.fillAmount >= 1)
            {
                _skillImage.fillAmount = 1;
                _skillOnCD = false;
                _skillUsed = false;
            }
        }
    }
    public void WaveOfTerror() 
    {
        if (waveOfTerrorUsed && !waveOfTerrorOnCD) 
        {
            waveOfTerrorOnCD = true;
            waveOfTerrorImage.fillAmount = 0;
        }

        if (waveOfTerrorOnCD)
        {
            waveOfTerrorImage.fillAmount += 1 / waveOfTerrorCD * Time.deltaTime;

            if (waveOfTerrorImage.fillAmount >= 1) 
            {
                waveOfTerrorImage.fillAmount = 1;
                waveOfTerrorOnCD = false;
                waveOfTerrorUsed = false;
            }
        }
    }

    public void SelectWaveOfTerror() 
    {
        if (!waveOfTerrorOnCD && waveOfTerrorSkillpoints > 0)
        {
            waveOfTerrorCasted = true;
            playerSkillController.SetProjectileToCast(waveProjectile);
            playerSkillController.cursorController.SetTargetCursor();
            playerSkillController.cursorController.skillName = "WaveOfTerror";
        }
        else if (waveManaCost > playerSkillController.mana.GetMana())
        {
            print("Not Enough Mana");
        }
        else
        {
            print("On Cooldown");
        };
    }
    public void DeselectWaveOfTerror() 
    {
        waveOfTerrorCasted = false;
        playerSkillController.SetProjectileToCast(playerSkillController.normalProjectile);
        playerSkillController.cursorController.SetNormalCursor();
    }
    public void CastWaveOfTerror() 
    {
        animator.SetBool("SkillAttack", true);
        animator.Play("WaveOfTerror");

    }
    public void WavesOfTerror() 
    {
        waveOfTerrorUsed = true;
        waveOfTerrorCasted = false;
        playerSkillController.skillCasted = false;
        playerSkillController.ResetRange();
    }
    public void AddWaveOfTerror() 
    {
        if(waveOfTerrorSkillpoints == 0) 
        {
            waveOfTerrorImage.fillAmount = 1;
        }
        waveOfTerrorSkillpoints++;
        waveLevelIndicator.EnableIndicator(waveOfTerrorSkillpoints-1);
    }
    public void AddNetherSwap() 
    {
        if(netherSwapSkillpoints == 0) 
        {
            netherSwapImage.fillAmount = 1;
        }
        netherSwapSkillpoints++;
        netherSwapLevelIndicator.EnableIndicator(netherSwapSkillpoints - 1);
    }
    public void VengeanceAura() 
    {
        if(vengeanceAura.gameObject.activeSelf == true) 
        {
            vengeanceAura.attackDamageBonus = attackDamageBonus;
            vengeanceAura.attackRangeBonus = attackRangeBonus;
        }
    }
    public void AddVengeanceAura()
    {
        if(vengeanceAuraSkillpoints == 0) 
        {
            vengeanceAura.gameObject.SetActive(true);
            vengeanceAuraImage.fillAmount = 1;
            
        }
        vengeanceAuraSkillpoints++;
        auraLevelIndicator.EnableIndicator(vengeanceAuraSkillpoints-1);
    }
    public void AddMagicMissile() 
    {
        if(magicMissileSkillpoints == 0) 
        {
            magicMissileImage.fillAmount = 1;
        }
        magicMissileSkillpoints++;
        magicMissileLevelIndicator.EnableIndicator(magicMissileSkillpoints-1);
    }
    public void MagicMissile()
    {
        if (magicMissileUsed && !magicMissileOnCD)
        {
            magicMissileOnCD = true;
            magicMissileImage.fillAmount = 0;
        }

        if (magicMissileOnCD)
        {
            magicMissileImage.fillAmount += 1 / magicMissileCD * Time.deltaTime;

            if (magicMissileImage.fillAmount >= 1)
            {
                magicMissileImage.fillAmount = 1;
                magicMissileOnCD = false;
                magicMissileUsed = false;
            }
        }
    }
    public void NetherSwap()  
    {
        if (netherSwapUsed && !netherSwapOnCD)
        {
            netherSwapOnCD = true;
            netherSwapImage.fillAmount = 0;
        }

        if (netherSwapOnCD)
        {
            netherSwapImage.fillAmount += 1 / netherSwapCD * Time.deltaTime;

            if (netherSwapImage.fillAmount >= 1)
            {
                netherSwapImage.fillAmount = 1;
                netherSwapOnCD = false;
                netherSwapUsed = false;
            }
        }
    }
    public void SelectNetherSwap()
    {
        if (!netherSwapOnCD && netherSwapSkillpoints > 0 && netherSwapManaCost < playerSkillController.mana.GetMana())
        {
            netherSwapCasted = true;
            playerSkillController.SetProjectileToCast(netherSwapProjectile);
            playerSkillController.cursorController.SetTargetCursor();
        }
        else if (netherSwapManaCost > playerSkillController.mana.GetMana())
        {
            print("Not Enough Mana");
        }
        else
        {
            print("On Cooldown");
        }

    }
    public void SelectMagicMissile()
    {
        if (!magicMissileOnCD && magicMissileSkillpoints > 0 && magicMissileManaCost < playerSkillController.mana.GetMana())
        {
            magicMissileCasted = true;
            playerSkillController.SetProjectileToCast(magicMissileProjectile);
            playerSkillController.cursorController.SetTargetCursor();
        }
        else if(magicMissileManaCost > playerSkillController.mana.GetMana()) 
        {
            print("Not Enough Mana");
        }
        else 
        {
            print("On Cooldown");
        }
            
    }
    public void DeselectMagicMissile()
    {
        magicMissileCasted = false;
        playerSkillController.SetProjectileToCast(playerSkillController.normalProjectile);
        playerSkillController.cursorController.SetNormalCursor();
    }
    public void DeselectNetherSwap()
    {
        netherSwapCasted = false;
        playerSkillController.SetProjectileToCast(playerSkillController.normalProjectile);
        playerSkillController.cursorController.SetNormalCursor();
    }
    public void CastMagicMissile()
    {
        animator.SetBool("SkillAttack", true);
        animator.Play("Missile");
    }

    public void CastNetherSwap() 
    {
        animator.SetBool("SkillAttack", true);
        animator.Play("NetherSwap");
    }
    public void NetherSwapLaunch() 
    {
        netherSwapUsed = true;
        netherSwapCasted = false;
        playerSkillController.skillCasted = false;
        playerSkillController.ResetRange();
    }
    public void MagicMissileLaunch()
    {
        magicMissileUsed = true;
        magicMissileCasted = false;
        playerSkillController.skillCasted = false;
        playerSkillController.ResetRange();
    }
    public void CancelSkill() 
    {
        waveOfTerrorCasted = false;
        playerSkillController.skillCasted = false;
    }
    public void ResetAllSkills() 
    {
        waveOfTerrorCasted = false;
        waveOfTerrorOnCD = false;
        waveOfTerrorImage.fillAmount = 1;
        waveOfTerrorUsed = false;

        magicMissileCasted = false;
        magicMissileOnCD = false;
        magicMissileImage.fillAmount = 1;
        magicMissileUsed = false;

        netherSwapCasted = false;
        netherSwapOnCD = false;
        netherSwapImage.fillAmount = 1;
        netherSwapUsed = false;
    }
}
