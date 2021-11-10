using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MinimapColor : MonoBehaviour
{
    public SpriteRenderer image;
    // Start is called before the first frame update
    void Start()
    {
        string playerSide = GameObject.Find("Player").GetComponent<GameSide>().GetSide().ToString();

        if (this.GetComponentInParent<GameSide>().GetSide().ToString() != playerSide)
        {
            image.color = Color.red;
        }
        else
        {
            image.color = Color.green;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
