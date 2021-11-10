using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ToolTipTrigger : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public GameObject toolTip;
    public UnitStats unitStats;

    private void Start()
    {
        unitStats = FindObjectOfType<UnitStats>();
    }
    private void OnMouseOver()
    {
        toolTip.SetActive(true);
    }

    private void OnMouseExit()
    {
        toolTip.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(unitStats.unitName.text == "Vengeful Spirit")
            toolTip.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(toolTip.activeSelf)
            toolTip.SetActive(false);
    }
}
