using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseGame : MonoBehaviour
{
    GameObject game_;
    public void StartSudoku()
    {
        game_=Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Sudoku_Panel"),GameObject.Find("Games").GetComponent<Transform>());
    }

    public void Finish()
    {
        Destroy(game_);
    }

    public void StartCatch()
    {
        game_=Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Catch_Panel"),GameObject.Find("Games").GetComponent<Transform>());
    }
}
