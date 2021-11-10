using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Debugger : MonoBehaviour
{
    public Text debuggerText;
    public Animator animator;

    bool isOpened;
    // Start is called before the first frame update
    void Start()
    {
        isOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetDebuggerToBack() 
    {
        debuggerText.text = "Close";
    }

    private void SetDebuggerToOpen() 
    {
        debuggerText.text = "Open";
    }

    private void OpenDebugger() 
    {
        animator.SetBool("isOpened", true);
    }
    private void CloseDebugger() 
    {
        animator.SetBool("isOpened", false);
    }

    public void OpenCloseDebugger() 
    {
        if (!isOpened) 
        {
            OpenDebugger();
            SetDebuggerToBack();
            isOpened = true;
        }
        else 
        {
            CloseDebugger();
            SetDebuggerToOpen();
            isOpened = false;
        }
            
    }
}
