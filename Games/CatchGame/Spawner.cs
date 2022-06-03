using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject goodFish;
    public GameObject badFish;

    public float xBounds, yBound;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(1,3));
        if(Random.value<=.6f)
        {
            Instantiate(goodFish, 
                        new Vector2(Random.Range(-xBounds,xBounds),yBound),
                        Quaternion.identity,GameObject.FindGameObjectWithTag("GameCatch").GetComponent<Transform>());
        }
        else
        {
            Instantiate(badFish, 
                        new Vector2(Random.Range(-xBounds,xBounds),yBound),
                        Quaternion.identity,GameObject.FindGameObjectWithTag("GameCatch").GetComponent<Transform>());
        }
        StartCoroutine(Spawn());
    }
}
