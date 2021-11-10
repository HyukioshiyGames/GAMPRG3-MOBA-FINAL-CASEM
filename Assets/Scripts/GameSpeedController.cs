using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeedController : MonoBehaviour
{
    public GameTime gameTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetToNormal()
    {
        gameTime.ToggleSpeedTime(1);
    }
    public void SpeedTimesTwo()
    {
        gameTime.ToggleSpeedTime(2);
    }
    public void SpeedDividedByTwo()
    {
        gameTime.ToggleSpeedTime(.5f);
    }
}
