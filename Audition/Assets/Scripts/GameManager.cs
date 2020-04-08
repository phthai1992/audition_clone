using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameManager is START!");

        GameObject player = GameObject.Find("Player2");
        player.GetComponent<CharacterController>().Dance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
