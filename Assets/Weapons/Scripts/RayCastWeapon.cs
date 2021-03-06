using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastWeapon : MonoBehaviour
{
    public bool isFiring = false;
    public Transform rayCastOrigin;
    public Transform rayCastDestination;

    Ray ray;
    RaycastHit hitInformation;

    public void StartFiring()
    {
        isFiring = true;

        ray.origin = rayCastOrigin.position;
        ray.direction = rayCastDestination.position - rayCastOrigin.position;

        if (Physics.Raycast(ray, out hitInformation))
        {
            Debug.Log("Generate line");
            Debug.DrawLine(ray.origin, hitInformation.point, Color.red, 1.0f);
        }
    }

    public void StopFiring()
    {
        isFiring = false;
    }
}
