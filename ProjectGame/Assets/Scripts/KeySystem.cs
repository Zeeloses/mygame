using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Position
{
    int x;
    int y;
    public Position(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}

public class KeySystem : MonoBehaviour
{
    public int keyNum;
    public GameObject keySample;
    public GameObject boxSample;
    public GameObject bombSample;
    public int keyBox;


    public void random(int limit)
    {
        keyNum = 0;
        for (int i = 0; i < limit; i++)
        {
            int typeOfRandom = UnityEngine.Random.Range(1, 10);

            int randY = -16 ;
             int randX = -40;
            while (((randX >= -40) && (randX <= -36)) && ((randY >= -16) && (randY <= -14)))
            {
             randY = UnityEngine.Random.Range(-18, -11);
             randX = UnityEngine.Random.Range(-38, -31);
              }
            Vector3 randPos = new Vector3(randX, randY, 0);
            if (typeOfRandom <= 2)
            {
                keyNum++;
                Instantiate(keySample, randPos, transform.rotation);
            }
            else if (typeOfRandom <= 4)
            {
                Instantiate(boxSample, randPos, transform.rotation);
            }
            else if (typeOfRandom <= 7)
            {
                keyNum++;
                Instantiate(keySample, randPos, transform.rotation);
                Instantiate(boxSample, randPos, transform.rotation);
            }
            else
            {
                Instantiate(bombSample, randPos, transform.rotation);
                Instantiate(boxSample, randPos, transform.rotation);
            }
        }
    }
}
