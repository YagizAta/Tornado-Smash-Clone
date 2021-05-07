using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Controller.instance.totalCubeDestroyed++;
        if (Controller.instance.totalCubeDestroyed==Controller.instance.totalCubeCount)
        {
            Controller.instance.finishedText.text = "Finished";
        }
        Destroy(other.gameObject);
    }
}
