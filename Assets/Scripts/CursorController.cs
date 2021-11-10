using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CursorController : MonoBehaviour
{
    public GameObject point;
    public Sprite normalCursor;
    public Sprite targetCursor;

    public Image currentCursor;

    public Player player;
    public PlayerSkillController skillController;

    public bool skillPressed;
    public string skillName;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        SetNormalCursor();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Input.mousePosition;

        
        if (currentCursor.sprite == targetCursor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (skillPressed) 
                {
                    if (skillName != "WaveOfTerror") 
                    {
                        if (!player.targetHovered.GetComponent<Tower>() &&
                        !player.targetHovered.GetComponent<BarrackSubordinate>() &&
                        !player.targetHovered.GetComponent<Ancient>())
                        {
                            player.SetTarget(player.targetHovered);
                            SetNormalCursor();
                        }
                        else
                        {
                            SetNormalCursor();
                        }
                    }
                    else
                    {
                        SpawnPointForSkill(player.hitData.point);
                        SetNormalCursor();
                    }
                }
                else
                {
                    player.SetTarget(player.targetHovered);
                    SetNormalCursor();
                    skillName = "";
                }
            }
            else if (Input.GetMouseButtonDown(1)) 
            {
                SetNormalCursor();
                skillPressed = false;
                skillName = "";
            }
        }

    }
    public void SpawnPointForSkill(Vector3 _pos) 
    {
        GameObject _point = (GameObject)Instantiate(point, _pos, Quaternion.identity);
        player.SetTarget(_point);
    }
    public void SetTargetCursor() 
    {
        currentCursor.sprite = targetCursor;
    }

    public void SetNormalCursor() 
    {
        currentCursor.sprite = normalCursor;
    }
}
