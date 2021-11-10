using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
   
    public float Velocity = 2;
    public int tabSize = 100;
    //
    private Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    private float intensity = 0;

    public Transform player;
    public KeyCode selectPlayerControl;

    public Vector3 minBounds;
    public Vector3 maxBounds;
    public float playerOffsetZ;

    public HUDSelection hudSelection;
    public UnitStats unitStats;
    private void Start()
    {
        this.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z - playerOffsetZ);
        hudSelection.InitializeHUDContent(player.gameObject);
        unitStats.InitializeStats(player.gameObject);
    }
    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 dir = mouse - center;

        dir.z = dir.y * 2.5f;
        dir.y = 0;

        Vector3.Normalize(dir);

        if (Input.GetKeyDown(KeyCode.G))
            this.enabled = false;


        if (Screen.width - tabSize < mouse.x)
            intensity -= ((Screen.width - mouse.x) - tabSize);
        if (tabSize > mouse.x)
            intensity += (tabSize - mouse.x);
        if (Screen.height - tabSize < mouse.y)
            intensity -= ((Screen.height - mouse.y) - tabSize);
        if (tabSize > mouse.y)
            intensity += (tabSize - mouse.y);

        intensity /= tabSize * 10;
        transform.Translate(Velocity * dir * intensity * Time.deltaTime, Space.World);
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, maxBounds.x, minBounds.x),
        Mathf.Clamp(this.transform.position.y, maxBounds.y, minBounds.y), Mathf.Clamp(this.transform.position.z, maxBounds.z, minBounds.z));
        SelectPlayer();
    }

    public void SelectPlayer() 
    {
        if (Input.GetKeyDown(selectPlayerControl)) 
        {
            this.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z - playerOffsetZ);
            hudSelection.InitializeHUDContent(player.gameObject);
            unitStats.InitializeStats(player.gameObject);
        }
    }

    public void SelectPlayerWithoutKey() 
    {
        hudSelection.InitializeHUDContent(player.gameObject);
        unitStats.InitializeStats(player.gameObject);
    }
}
