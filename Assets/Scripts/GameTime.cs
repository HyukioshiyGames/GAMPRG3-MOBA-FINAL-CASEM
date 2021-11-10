using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    public enum Type { Day, Night}
    public Type cycleType;
    [SerializeField] private MasterSpawner masterSpawner;

    public Color32 nightColor;
    public Color32 dayColor;
    public GameObject directionalLight;

    public float timeMultiplier;
    private float timeBase = 1;
    private float timeSpeed;

    private float minute;
    private float second;

    public float secondsPerMinute;

    public Text textMinute;
    public Text textSecond;

    public float creepTimeSpawnInterval;
    public float dayNightInterval;

    public int waveCount;
    bool spawned;

    public bool isCountdown;
    // Start is called before the first frame update
    void Start()
    {
        cycleType = Type.Day;
        dayColor = directionalLight.GetComponent<Light>().color;
        second = 30;
        isCountdown = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ToggleSpeedTime(4);
        if (Input.GetKeyDown(KeyCode.V))
            ToggleSpeedTime(1);
        TimeGame();
    }

    public void ToggleSpeedTime(float _multiplier) 
    {
        Time.timeScale = _multiplier;
    }

    
    public void TimeGame() 
    {
        if (isCountdown) 
        {
            if (second > 0)
                second -= Time.deltaTime;
            else
                isCountdown = false;
        }
        else 
        {
            if (second < secondsPerMinute)
            {
                second += Time.deltaTime;

                if ((int)second % creepTimeSpawnInterval == 0)
                {
                    if (!spawned)
                    {
                        if(waveCount % 5 == 0 && waveCount != 0) 
                        {
                            masterSpawner.InitializeBarrackCreeps(masterSpawner.seigeWave);
                            print("Seige");
                        }
                        else 
                        {
                            masterSpawner.InitializeBarrackCreeps(masterSpawner.normalWave);
                        }
                        masterSpawner.SpawnCreeps();
                        waveCount++;
                        spawned = true;
                    }
                }
                else
                {
                    if (spawned)
                        spawned = false;
                }
            }
            else
            {
                minute++;
                second = 0;
                if (minute % creepTimeSpawnInterval == 0 && second == 0)
                {

                }
                if (minute % dayNightInterval == 0 && second == 0)
                {
                    CheckDayOrNight();
                }
            }
        }

        textMinute.text = Mathf.Round(minute) + "";
        textSecond.text = Mathf.Round(second) + "";
    }

    private void CheckDayOrNight()
    {
        if (cycleType == Type.Day) 
        {
            cycleType = Type.Night;
            directionalLight.GetComponent<Light>().color = nightColor;
        }

        else 
        {
            cycleType = Type.Day;
            directionalLight.GetComponent<Light>().color = dayColor;
        }
           
    }
}
