using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelIndicator : MonoBehaviour
{
    public GameObject[] indicators;
    

    public void EnableIndicator(int _index)
    {
        indicators[_index].SetActive(true);
    }
}
