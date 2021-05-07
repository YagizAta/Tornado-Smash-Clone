using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float lerpValue;
    public LayerMask layer;

    private Camera cam;
    
    void Start()
    {
        cam = Camera.main;
    }


    private void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, 360 * Time.deltaTime);

    }


    public void Movement()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;

        Ray ray = cam.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit,1000,layer))
        {
            transform.position = Vector3.Lerp(transform.position, hit.point, lerpValue);
        }

       



    }





}
