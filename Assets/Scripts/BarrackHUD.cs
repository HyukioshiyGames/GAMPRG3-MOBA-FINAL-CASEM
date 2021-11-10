using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrackHUD : MonoBehaviour
{
    public GameSide gameSide;

    public GameObject radiantCrystal;
    public GameObject direCrystal;
    private void OnEnable()
    {
        InitializeTower();
    }
    private void InitializeTower()
    {
        if (gameSide.GetSide().ToString() == "Radiant")
        {
            direCrystal.SetActive(false);
            radiantCrystal.SetActive(true);
        }

        else
        {
            radiantCrystal.SetActive(false);
            direCrystal.SetActive(true);
        }

    }
}
