using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject prefabArrowUp;
    public GameObject prefabArrowDown;
    public GameObject prefabArrowLeft;
    public GameObject prefabArrowRight;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameManager is START!");

        //GameObject player = GameObject.Find("Player2");
        //player.GetComponent<CharacterController>().Dance();

        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        GetMove();
        RenderMove();
    }

    public void GetMove()
    {
        GenerateMove.instance.RandomMove();
        List<int> move = GenerateMove.instance.GetMove();
        if(move.Count > 0)
        {
            string moveList = "";
            for(int i = 0; i < move.Count; i++)
                moveList += " " + ConvertMoveFromInt(move[i]);
            Debug.Log("GetMove: " + moveList);
        }
    }

    public void RenderMove()
    {
        List<int> move = GenerateMove.instance.GetMove();
        Transform positionMove = GameObject.Find("MoveBar").transform;
        if(move.Count > 0)
        {
            for(int i = 0; i < move.Count; i++)
            {
                float x = positionMove.position.x + 1*i - 1*(move.Count/2);
                float y = positionMove.position.y;
                float z = positionMove.position.z;
                Vector3 position = new Vector3(x, y, z);
                switch(move[i])
                {
                    case 1:
                        SpawnArrowUp(position);
                        break;
                    case 2:
                        SpawnArrowDown(position);
                        break;
                    case 3:
                        SpawnArrowLeft(position);
                        break;
                    case 4:
                        SpawnArrowRight(position);
                        break;
                }
                
            }
        }
    }

    string ConvertMoveFromInt(int move)
    {
        switch(move)
        {
            case 1:
                return "Up";
            case 2:
                return "Down";
            case 3:
                return "Left";
            case 4:
                return "Right";
        }
        return "";
    }

    void SpawnArrowUp(Vector3 pos)
    {
        GameObject arrow = prefabArrowUp.Spawn();
        if (arrow != null)
        {
            arrow.transform.position = pos;
            arrow.transform.transform.Rotate(new Vector3(0, 0, 90)); 
            arrow.SetActive(true);
        } 
    }
    void SpawnArrowDown(Vector3 pos)
    {
        GameObject arrow = prefabArrowDown.Spawn();
        if (arrow != null)
        {
            arrow.transform.position = pos;
            arrow.transform.transform.Rotate(new Vector3(0, 0, -90)); 
            arrow.SetActive(true);
        } 
    }
    void SpawnArrowLeft(Vector3 pos)
    {
        GameObject arrow = prefabArrowLeft.Spawn();
        if (arrow != null)
        {
            arrow.transform.position = pos;
            arrow.transform.transform.Rotate(new Vector3(0, 0, 180));
            arrow.SetActive(true);
        } 
    }
    void SpawnArrowRight(Vector3 pos)
    {
        GameObject arrow = prefabArrowRight.Spawn();
        if (arrow != null)
        {
            arrow.transform.position = pos;
            arrow.SetActive(true);
        } 
    }
}
