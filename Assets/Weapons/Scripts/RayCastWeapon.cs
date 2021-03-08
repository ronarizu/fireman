using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastWeapon : MonoBehaviour
{
    public bool isFiring = false;
    public Transform rayCastOrigin;
    public Transform rayCastDestination;
    public ParticleSystem hitEffect;

    public TrailRenderer tracerEffect;

    Ray ray;
    RaycastHit hitInformation;

    void Start()
    {
        StopFiring();
    }

    public void StartFiring()
    {
        isFiring = true;

        ray.origin = rayCastOrigin.position;
        ray.direction = rayCastDestination.position - rayCastOrigin.position;

        var tracer = Instantiate(tracerEffect, ray.origin, Quaternion.identity);
        tracer.AddPosition(ray.origin);

        if (Physics.Raycast(ray, out hitInformation))
        {
            hitEffect.transform.position = hitInformation.point;
            hitEffect.transform.forward = hitInformation.normal;
            hitEffect.Play();

            tracer.transform.position = hitInformation.point;

            Debug.DrawLine(ray.origin, hitInformation.point, Color.blue, 1.0f);
        }
    }

    public void updateLaser()
    {
        float distance = Vector3.Distance(rayCastOrigin.position, rayCastDestination.position );
        Vector3 oneThird = rayCastOrigin.position + ray.direction * (distance * 0.3f);
    }

    public void StopFiring()
    {
        isFiring = false;
        hitEffect.Stop();
    }
}
