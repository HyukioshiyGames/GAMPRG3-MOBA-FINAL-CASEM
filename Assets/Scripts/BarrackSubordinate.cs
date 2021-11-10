using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrackSubordinate : MonoBehaviour
{
    public Barrack barrack;
    public GameSide gameSide;
    public GameObject radiantCrystal;
    public GameObject direCrystal;
    public enum BarrackType { Melee, Ranged};
    public BarrackType barrackType;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<GameSide>().SetSide(gameSide.GetSide());
        if (gameSide.GetSide() == GameSide.Side.Radiant)
            radiantCrystal.SetActive(true);
        else
            direCrystal.SetActive(true);
    }


    public void OnDestroyThisObject() 
    {
        if (barrackType == BarrackType.Melee)
            barrack.MeleeBarracksDestroyed();
        else
            barrack.RangedBarracksDestroyed();
        Destroy(this.gameObject);
    }
}
