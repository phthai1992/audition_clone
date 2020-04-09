using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject prefabArrowSprite;
    private bool isRenderMove = false;
    private bool isPlayerMoveFinished = false;
    private int currentMove = 0;
    private List<int> playerMove;
    
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
        if(isRenderMove)
        {
            CheckInputMove();

            if(isPlayerMoveFinished)
            {
                // Show text result
                GameObject result = GameObject.Find("Result_Perfect");
                if(result != null)
                {
                    result.GetComponent<SpriteRenderer>().enabled = true;
                }
            }
        }
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
                Direction dir = (Direction)move[i];
                switch(dir)
                {
                    case Direction.Up:
                        SpawnArrowUp(position);
                        break;
                    case Direction.Down:
                        SpawnArrowDown(position);
                        break;
                    case Direction.Left:
                        SpawnArrowLeft(position);
                        break;
                    case Direction.Right:
                        SpawnArrowRight(position);
                        break;
                }
                isRenderMove = true;
                isPlayerMoveFinished = false;
                currentMove = 0;
                playerMove = new List<int>();
            }
        }
    }

    void CheckInputMove()
    {
        List<int> move = GenerateMove.instance.GetMove();
        if(currentMove < move.Count)
        {
            if(Input.GetKeyUp(KeyCode.UpArrow))
            {
                //Debug.Log("PressUp");
                playerMove.Add((int)Direction.Up);
                currentMove++;
            }
            else if(Input.GetKeyUp(KeyCode.DownArrow))
            {
                //Debug.Log("PressDown");
                playerMove.Add((int)Direction.Down);
                currentMove++;
            }
            else if(Input.GetKeyUp(KeyCode.LeftArrow))
            {
                //Debug.Log("PressLeft");
                playerMove.Add((int)Direction.Left);
                currentMove++;
            }
            else if(Input.GetKeyUp(KeyCode.RightArrow))
            {
                //Debug.Log("PressRight");
                playerMove.Add((int)Direction.Right);
                currentMove++;
            }
        }

        if(currentMove >= move.Count)
        {
            if(isPlayerMoveFinished == false)
            {
                int match = 0;
                string playerMoveList = "";
                for(int i = 0; i < playerMove.Count; i++)
                {
                    playerMoveList += " " + ConvertMoveFromInt(playerMove[i]);
                    if(playerMove[i] == move[i])
                    {
                        match++;
                    }
                }
                isPlayerMoveFinished = true;

                Debug.Log("PlayerMove: " + playerMoveList + " Result score: " + (((float)match / move.Count) * 100));
            }
        }
    }

    string ConvertMoveFromInt(int move)
    {
        Direction dir = (Direction)move;
        switch(dir)
        {
            case Direction.Up:
                return "Up";
            case Direction.Down:
                return "Down";
            case Direction.Left:
                return "Left";
            case Direction.Right:
                return "Right";
        }
        return "";
    }

    void SpawnArrowUp(Vector3 pos)
    {
        GameObject arrow = prefabArrowSprite.Spawn();
        if (arrow != null)
        {
            arrow.transform.position = pos;
            arrow.transform.transform.Rotate(new Vector3(0, 0, 90)); 
            arrow.SetActive(true);
        } 
    }
    void SpawnArrowDown(Vector3 pos)
    {
        GameObject arrow = prefabArrowSprite.Spawn();
        if (arrow != null)
        {
            arrow.transform.position = pos;
            arrow.transform.transform.Rotate(new Vector3(0, 0, -90)); 
            arrow.SetActive(true);
        } 
    }
    void SpawnArrowLeft(Vector3 pos)
    {
        GameObject arrow = prefabArrowSprite.Spawn();
        if (arrow != null)
        {
            arrow.transform.position = pos;
            arrow.transform.transform.Rotate(new Vector3(0, 0, 180));
            arrow.SetActive(true);
        } 
    }
    void SpawnArrowRight(Vector3 pos)
    {
        GameObject arrow = prefabArrowSprite.Spawn();
        if (arrow != null)
        {
            arrow.transform.position = pos;
            arrow.SetActive(true);
        } 
    }
}
