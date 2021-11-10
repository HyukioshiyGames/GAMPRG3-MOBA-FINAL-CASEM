using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject [] players;

    public static GameManager instance;

    public Animator gameEndAnimator;
    public Text winningSide;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TowerDestroyed(int _bounty,GameSide _gameSide) 
    {
        for (int i = 0; i < players.Length; i++) 
        {
            if(players[i].GetComponent<GameSide>().GetSide() != _gameSide.GetSide()) 
            {
                players[i].GetComponent<PlayerInventory>().AddGold(_bounty, players[i].transform.position + Vector3.up * 1.5f);
            }
        }
    }

    public void OnGameEnd(GameSide _gameSide) 
    {
        ObjectObserver.instance.StopAllCreeps();
        if (_gameSide.GetSide() == GameSide.Side.Radiant)
            winningSide.text = GameSide.Side.Dire.ToString() + " Victory";
        else
            winningSide.text = GameSide.Side.Radiant.ToString() + " Victory";

        gameEndAnimator.SetBool("onGameEnded", true);

        
        
    }
}
