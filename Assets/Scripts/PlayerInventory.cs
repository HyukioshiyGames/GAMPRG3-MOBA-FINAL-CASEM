using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public GameSpawner gameSpawner;
    [SerializeField] private int playerGold;
    public Text playerGoldText;

    // Start is called before the first frame update
    void Start()
    {
        SetGoldText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddGold(int _goldToAdd,Vector3 _coinSpawnposition) 
    {
        playerGold += _goldToAdd;
        SetGoldText();
        gameSpawner.SpawnGoldCoins(_coinSpawnposition);
    }

    public int GetGold() 
    {
        return playerGold;
    }

    void SetGoldText()
    {
        playerGoldText.text = playerGold.ToString();
    }
}
