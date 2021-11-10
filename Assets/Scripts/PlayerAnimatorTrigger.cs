using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorTrigger : MonoBehaviour
{
    private Player player;
    public Skills skills;
    public PlayerSkillController pSkillController;
    public Animator animator;
    public PlayerAnimator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Player>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DealNormalDamage()
    {
        player.CastNormalAttack();
    }

    public void SpawnWaveOfTerror()
    {
        skills.WavesOfTerror();
        pSkillController.WaveOfTerror(player.projectileSpawnpoint, player.target, skills.waveOfTerrorDamage);
        pSkillController.ResetRange();
    }
    public void SpawnMagicMissile()
    {
        skills.MagicMissileLaunch();
        pSkillController.MagicMissile(player.projectileSpawnpoint, player.target, skills.magicMissileDamage);
        pSkillController.ResetRange();
    }

    public void SpawnNetherSwap()
    {
        skills.NetherSwapLaunch();
        pSkillController.NetherSwap(player.projectileSpawnpoint, player.target, 0);
        pSkillController.ResetRange();
    }
    public void StopSkill()
    {
        animator.SetBool("SkillAttack", false);

    }

    public void UnplayBasicAttack() 
    {
        playerAnimator.UnplayBasicAttack();
    }


}
