using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthUI : MonoBehaviour
{
    public Image image;
    public bool isMana;
    private void Start()
    {
        if (!isMana) 
        {
            if (image)
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
        }
    }
    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }

}
