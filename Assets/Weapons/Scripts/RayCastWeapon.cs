using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastWeapon : MonoBehaviour
{
    public bool isFiring = false;
    public Transform rayCastOrigin;
    public Transform rayCastDestination;
    public ParticleSystem hitEffect;

    public GameObject waterLaser;

    private GameObject spawnedLaser;

    Ray ray;
    RaycastHit hitInformation;

    void Start()
    {
        spawnedLaser = Instantiate(waterLaser, rayCastOrigin.transform) as GameObject;
        StopFiring();
    }

    public void StartFiring()
    {
        isFiring = true;

        ray.origin = rayCastOrigin.position;
        ray.direction = rayCastDestination.position - rayCastOrigin.position;

        spawnedLaser.SetActive(true);

        if (Physics.Raycast(ray, out hitInformation))
        {
            hitEffect.transform.position = hitInformation.point;
            hitEffect.transform.forward = hitInformation.normal;
            hitEffect.Play();
        }
    }

    public void updateLaser()
    {
        float distance = Vector3.Distance(rayCastOrigin.position, rayCastDestination.position );
        Vector3 oneThird = rayCastOrigin.position + ray.direction * (distance * 0.3f);

        spawnedLaser.transform.position = oneThird;
    }

    public void StopFiring()
    {
        isFiring = false;
        spawnedLaser.SetActive(false);
        hitEffect.Stop();
    }
}
