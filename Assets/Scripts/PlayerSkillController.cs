using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillController : MonoBehaviour
{
    Player player;
    Attributes attributes;
    public Mana mana;
    [Header("Normal Attack")]
    public bool normalAttackCasted;
    public KeyCode normalAttackHotkey;

    public Skills skillsUI;

    public CursorController cursorController;
    public GameObject projectileToCast;
    public GameObject normalProjectile;

    public bool skillCasted;
    public float baseAttackRange;

    public PlayerAttackRange attackRange;
    // Start is called before the first frame update
    void Start()
    {
        attributes = GetComponent<Attributes>();
        mana = GetComponent<Mana>();
        player = GetComponent<Player>();

        baseAttackRange = attributes.attackRange;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(skillsUI.waveOfTerrorHotkey)) 
        {
            DeselectOthers();
            skillsUI.SelectWaveOfTerror();
            skillCasted = true;
            attackRange.SetRadius(skillsUI.waveRange);
            cursorController.skillPressed = true;
        }
        if (Input.GetKeyDown(skillsUI.magicMissileHotkey))
        {
            DeselectOthers();
            skillsUI.SelectMagicMissile();
            skillCasted = true;
            attackRange.SetRadius(skillsUI.magicMissileRange);
            cursorController.skillPressed = true;
        }
        if (Input.GetKeyDown(skillsUI.netherSwapHotkey))
        {
            DeselectOthers();
            skillsUI.SelectNetherSwap();
            skillCasted = true;
            attackRange.SetRadius(skillsUI.netherSwapRange);
            cursorController.skillPressed = true;
        }

        if (Input.GetKeyDown(normalAttackHotkey)) 
        {
            DeselectOthers();
            cursorController.SetTargetCursor();
            skillCasted = false;
            cursorController.skillPressed = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            skillsUI.CancelSkill();
            ResetRange();
            cursorController.skillPressed = false;
            cursorController.SetNormalCursor();
        }
    }
    private void DeselectOthers() 
    {
        skillsUI.DeselectMagicMissile();
        skillsUI.DeselectWaveOfTerror();
        skillCasted = false;
    }
    public void ResetRange() 
    {
        attackRange.SetRadius(baseAttackRange);
    }
    public void SetProjectileToCast(GameObject _projectileToCast) 
    {
        projectileToCast = _projectileToCast;
    }

    public void WaveOfTerror(Transform _spawnPoint, GameObject _target, int damage)
    {
        GameObject _normalProjectile = (GameObject)Instantiate
            (projectileToCast, _spawnPoint.transform.position, Quaternion.identity);
        _normalProjectile.GetComponent<ProjectileMove>().targetEnemy = _target;
        _normalProjectile.GetComponent<ProjectileStats>().damage = damage;
        _normalProjectile.GetComponent<ProjectileMove>().caster = this.gameObject;
        _normalProjectile.GetComponent<ProjectileStats>().attackType = "Magic";
        _normalProjectile.GetComponent<WaveOfTerror>().duration = skillsUI.waveOfTerrorDuration;
        _normalProjectile.GetComponent<WaveOfTerror>().armorReducValue = skillsUI.armorReducValue;
        

        mana.DeductMana(skillsUI.waveManaCost);
        
    }

    public void MagicMissile(Transform _spawnPoint, GameObject _target, int damage)
    {
        GameObject _normalProjectile = (GameObject)Instantiate
            (projectileToCast, _spawnPoint.transform.position, Quaternion.identity);
        _normalProjectile.GetComponent<ProjectileMove>().targetEnemy = _target;
        _normalProjectile.GetComponent<ProjectileStats>().damage = damage;
        _normalProjectile.GetComponent<ProjectileStats>().attackType = "Magic";
        _normalProjectile.GetComponent<ProjectileMove>().caster = this.gameObject;
        _normalProjectile.GetComponent<MagicMissile>().targetEnemy = _target;
        _normalProjectile.GetComponent<MagicMissile>().duration = skillsUI.magicMissileStunDuration;
        mana.DeductMana(skillsUI.magicMissileManaCost);
    }
    public void NetherSwap(Transform _spawnPoint, GameObject _target, int damage)
    {
        GameObject _normalProjectile = (GameObject)Instantiate
            (projectileToCast, _spawnPoint.transform.position, Quaternion.identity);
        _normalProjectile.GetComponent<ProjectileMove>().targetEnemy = _target;
        _normalProjectile.GetComponent<ProjectileStats>().damage = damage;
        _normalProjectile.GetComponent<ProjectileStats>().attackType = "Magic";
        _normalProjectile.GetComponent<ProjectileMove>().caster = this.gameObject;
        _normalProjectile.GetComponent<NetherSwap>().targetEnemy = _target;
        _normalProjectile.GetComponent<NetherSwap>().caster = player.gameObject;
        mana.DeductMana(skillsUI.netherSwapManaCost);
    }
    public void NormalAttack(Transform _spawnPoint,GameObject _target,int damage) 
    {
        projectileToCast = normalProjectile;
        GameObject _normalProjectile = (GameObject)Instantiate
            (projectileToCast, _spawnPoint.transform.position, Quaternion.identity);
        _normalProjectile.GetComponent<ProjectileMove>().targetEnemy = _target;
        _normalProjectile.GetComponent<ProjectileStats>().damage = damage;
        _normalProjectile.GetComponent<ProjectileStats>().attackType = "Physical";
        _normalProjectile.GetComponent<ProjectileMove>().caster = this.gameObject;

    }

    public void CheckSkillUsed() 
    {
        if (skillsUI.waveOfTerrorCasted)
        {
            skillsUI.CastWaveOfTerror();

        }

        else if (skillsUI.magicMissileCasted) 
        {
            skillsUI.CastMagicMissile();
        }
        else if (skillsUI.netherSwapCasted) 
        {
            skillsUI.CastNetherSwap();
        }
            
    }

}
