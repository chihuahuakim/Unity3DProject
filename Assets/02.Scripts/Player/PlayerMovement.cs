using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] Animator animator;
    [SerializeField] Transform tr;
    readonly string PosX = "PosX";
    readonly string PosY = "PosY";
    readonly int HashRun = Animator.StringToHash("isRunning"); 
    float moveSpeed = 4f;
    float rotSpeed = 600f;
    WaitForSeconds ws = new WaitForSeconds(0.5f);

    IEnumerator Start()
    {
        yield return ws;
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        tr= transform;  
    }
 
    void FixedUpdate()
    {
        if (playerInput != null && animator !=null)
        {
            MoveAndRotate();
            Run();
        }
    }

    private void MoveAndRotate()
    {
        Vector3 PlayerPos = (playerInput.h * Vector3.right) + (playerInput.v * Vector3.forward);
        tr.Translate(PlayerPos.normalized * moveSpeed * Time.deltaTime);
        tr.Rotate(Vector3.up * playerInput.r * Time.deltaTime * rotSpeed);
        animator.SetFloat(PosY, playerInput.h, 0.01f, Time.deltaTime);
        animator.SetFloat(PosX, playerInput.v, 0.01f, Time.deltaTime);
    }

    private void Run()
    {
        if (playerInput.sprint == true)
        {
            moveSpeed = 8f;
            animator.SetBool(HashRun, true);
        }
        else if (playerInput.sprint == false)
        {
            moveSpeed = 4f;
            animator.SetBool(HashRun, false);
        }
    }
}
