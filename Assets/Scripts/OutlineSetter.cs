using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineSetter : MonoBehaviour
{
    public Outline [] outline;
    public Color outLineColor;
    // Start is called before the first frame update
    void Start()
    {
        string playerSide = GameObject.Find("Player").GetComponent<GameSide>().GetSide().ToString();

        if (this.GetComponentInParent<GameSide>().GetSide().ToString() != playerSide)
        {
            SetColor(Color.red);
        }
        else
        {
            SetColor(Color.green);
        }
    }

    private void SetColor(Color _color) 
    {
        for(int i = 0; i < outline.Length; i++) 
        {
            outline[i].OutlineColor = _color;
        }
    }

    public void EnableOutline() 
    {
        for (int i = 0; i < outline.Length; i++)
        {
            outline[i].enabled = true;
        }
    }

    public void DisableOutline() 
    {
        for (int i = 0; i < outline.Length; i++)
        {
            outline[i].enabled = false;
        }
    }

    public void OnMouseOver()
    {
        EnableOutline();
    }

    public void OnMouseExit()
    {
        DisableOutline();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
