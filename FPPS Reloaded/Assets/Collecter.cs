using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collecter : MonoBehaviour
{
    public int collectionValue = 1;
    public int collected = 0;
    public int maxCollectedValue = 100;

    public int endGameSceneNumber;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectable")
        {
            Collect(collectionValue, endGameSceneNumber);
            Destroy(other.gameObject);
        }

        if (other.tag == "Big Chunk")
        {
            Collect(10000, endGameSceneNumber);
            Destroy(other.gameObject);
        }
    }

    void Collect(int value, int _whatLevelNext)
    {
        collected += value;

        if (collected >= maxCollectedValue)
        {
            GameEndScene(_whatLevelNext);
        }
    }

    private void GameEndScene(int _SceneNumber)
    {
        SceneManager.LoadScene(_SceneNumber);
    }
}
