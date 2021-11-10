using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ancient : MonoBehaviour
{
    public GameObject direCrystal;
    public GameObject radiantCrystal;

    public List<GameObject> tierFourTowers;
    public bool ancientInvulnerable;
    // Start is called before the first frame update
    void Start()
    {
        InitializeAncient();
        ancientInvulnerable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (ancientInvulnerable)
            CheckLastTwoTowers();
    }

    void InitializeAncient() 
    {
        if (GetComponent<GameSide>().GetSide() == GameSide.Side.Radiant)
            radiantCrystal.SetActive(true);
        else
            direCrystal.SetActive(true);
    }
    public void DestroyThis()
    {
        GameManager.instance.OnGameEnd(this.gameObject.GetComponent<GameSide>());
        Destroy(this.gameObject);
        print("Called");
    }

    public void CheckLastTwoTowers() 
    {
        for (int i = 0; i < tierFourTowers.Count; i++)
            if (tierFourTowers[i] == null)
                tierFourTowers.Remove(tierFourTowers[i]);

        if (tierFourTowers.Count == 0) 
        {
            this.GetComponent<SphereCollider>().enabled = true;
            ancientInvulnerable = false;
        }
            
    }

}
