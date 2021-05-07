using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TornadoEffect : MonoBehaviour
{
    public float radius = 5;
    public float rotateSpeed = 360;
    public float minimumScale = .1f;
    public float scaleDecreaseSpeed = 0.025f;
    public float tornadoHeight = 6;
    public float horizontalPullSpeed = 0.05f;
    public float verticalPullSpeed = .01f;
      
    private Collider[] colliders;

    private List<Collider> pastColliders;
    void FixedUpdate()
    {
        colliders = Physics.OverlapSphere(transform.position, radius, LayerMask.GetMask("Ignore Raycast"));
        if (pastColliders == null) SavePastColliders(); 
         
        foreach (var collider in colliders) 
        {
            Rigidbody rb;
            if (pastColliders == null) SavePastColliders();   
            else if (!pastColliders.Contains(collider)) 
            {
                if (collider.gameObject.TryGetComponent<Rigidbody>(out rb))
                {
                    rb.useGravity = false;
                }
            }

            var position = transform.position + Vector3.Normalize(new Vector3(collider.transform.position.x - (transform.position.x + 1f), 0, collider.transform.position.z - (transform.position.z + 1f))) * .1f;
            collider.transform.position = Vector3.Lerp(collider.transform.position, new Vector3(position.x, collider.transform.position.y, position.z), horizontalPullSpeed);
            collider.transform.position = Vector3.Lerp(collider.transform.position, new Vector3(collider.transform.position.x, tornadoHeight, collider.transform.position.z), verticalPullSpeed);

            collider.transform.localScale = Vector3.Lerp(collider.transform.localScale, Vector3.one * minimumScale, scaleDecreaseSpeed);

            collider.transform.RotateAround(transform.position, Vector3.up, rotateSpeed * Time.fixedDeltaTime);
        }

        foreach (Collider pastCollider in pastColliders)
        {
            Rigidbody rb;
            if (!colliders.Contains(pastCollider) && pastCollider != null)
            {
                if (pastCollider.gameObject.TryGetComponent<Rigidbody>(out rb))
                {
                    rb.useGravity = true;
                }
            }
        }


        SavePastColliders();
    }

    private void SavePastColliders()
    {
        pastColliders = colliders.ToList();
    }
}
