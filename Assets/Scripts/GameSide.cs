using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSide : MonoBehaviour
{
    public enum Side { Radiant, Dire }


    [SerializeField] private Side characterSide;

   
    public void SetSide(Side _toSide)
    {
        characterSide = _toSide;
        if (characterSide == Side.Radiant)
            this.transform.tag = "Radiant";
        else
            this.transform.tag = "Dire";
    }

    public Side GetSide() 
    {
        return characterSide;
    }
}
