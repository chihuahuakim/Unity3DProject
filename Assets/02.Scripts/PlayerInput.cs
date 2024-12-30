using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] public string strHor = "Horizontal";
    [SerializeField] public string strVer = "Vertical";
    [SerializeField] string MouseX = "Mouse X";
    [SerializeField] string fireBtn = "Fire1";
    [SerializeField] string reloadBtn = "Reload";
    public float h = 0, v = 0, r = 0;
    public bool fire { get; private set; }
    public bool reload { get; private set; }
    public bool sprint { get; private set; }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance != null && GameManager.instance.isGameover)
        {
            h = 0f;
            v = 0f;
            reload = false;
            fire = false;
            sprint = false;
            return;
        }

        h = Input.GetAxis(strHor);
        v = Input.GetAxis(strVer);
        r = Input.GetAxisRaw(MouseX);
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
            sprint = true;
        else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.W))
            sprint = false;
        reload = Input.GetButtonDown(reloadBtn);
        fire = Input.GetButtonDown(fireBtn);
    }
}
