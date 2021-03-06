using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastWeapon : MonoBehaviour
{
    public bool isFiring = false;
    public Transform rayCastOrigin;
    public Transform rayCastDestination;
    public ParticleSystem hitEffect;

    Ray ray;
    RaycastHit hitInformation;

    public void StartFiring()
    {
        isFiring = true;

        ray.origin = rayCastOrigin.position;
        ray.direction = rayCastDestination.position - rayCastOrigin.position;

        if (Physics.Raycast(ray, out hitInformation))
        {
            hitEffect.transform.position = hitInformation.point;
            hitEffect.transform.forward = hitInformation.normal;
            hitEffect.Emit(1);
        }
    }

    public void StopFiring()
    {
        isFiring = false;
    }
}
