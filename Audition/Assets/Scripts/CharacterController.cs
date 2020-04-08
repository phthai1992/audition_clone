using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //0: idle  (loop)
    //1: dance (non loop) -> call AnimationController.OnStateExit to back to value 0
    //2: walk  (loop)
    private int state; 

    // Start is called before the first frame update
    void Awake()
    {
        // Do smt
    }

    // Update is called once per frame
    void Update()
    {
        // Do smt
    }

    public void Idle()
    {
        Debug.Log("CharacterController: Idle");
        state = 0;
        SetAnimation(state);
    }

    public void Dance()
    {
        Debug.Log("CharacterController: Dance");
        state = 1;
        SetAnimation(state);
    }

    public void Walk()
    {
        Debug.Log("CharacterController: Walk");
        state = 2;
        SetAnimation(state);
    }

    public void SetAnimation(int state)
    {
        this.GetComponent<Animator>().SetInteger("state", state);
    }
}
