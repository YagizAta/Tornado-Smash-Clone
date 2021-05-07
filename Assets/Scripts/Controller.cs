using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public static Controller instance;

    public int totalCubeDestroyed;
    public int totalCubeCount;
    public Text finishedText;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        totalCubeDestroyed++;
        if (totalCubeDestroyed==totalCubeCount)
        {
            finishedText.text = "Finished";

        }
        Destroy(other.gameObject);
        
    }
}
