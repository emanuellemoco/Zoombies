﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject parent;
    public GameObject shoot;
    public GameObject gunWayPoint;
    private float bulletSpeed = 200;

    public float shotDelay;
    private float _shotTimestamp = 0.0f; 


    void Start()
    {
        this.gameObject.transform.SetParent(parent.transform);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
            Shoot();
    }
    
    void Shoot()
    {
    if ( Time.time - _shotTimestamp < shotDelay) 
            return;
    _shotTimestamp = Time.time; 

    //Instantiate(shoot, playerCamera.transform.position+(playerCamera.transform.forward*2), Quaternion.identity);

    Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

    GameObject bullet = Instantiate(shoot, gunWayPoint.transform.position, Camera.main.transform.rotation * Quaternion.Euler(0f, 90f, 0f));
    Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

    Vector3 direction = (ray.GetPoint(100000.0f) - bullet.transform.position).normalized;

    bulletRigidbody.AddForce(direction * bulletSpeed, ForceMode.Impulse);
    


    }
}