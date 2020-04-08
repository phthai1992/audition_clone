using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMove : MonoBehaviour
{
    public static GenerateMove instance;

    public List<int> move;

    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("GenerateMove::Awake");
        instance = this;

        move = new List<int>();
        move.Add(1); //Up
        move.Add(2); //Down
        move.Add(3); //Left
        move.Add(4); //Right
    }

    public List<int> GetMove()
    {
        Debug.Log("GenerateMove::GetMove");
        return move;
    }

    public void RandomMove()
    {
        Debug.Log("GenerateMove::RandomMove");
        move.Clear();
        move.Add(Random.Range(1,5));
        move.Add(Random.Range(1,5));
        move.Add(Random.Range(1,5));
        move.Add(Random.Range(1,5));
        move.Add(Random.Range(1,5));
    }
}
