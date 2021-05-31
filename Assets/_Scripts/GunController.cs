using System.Collections;
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
    public int damage;
    public float range = 100f;
    public ParticleSystem muzzleFlash;

    public GameObject bloodImpact;

    public GameObject wallImpact;




    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }
    
    void Shoot(){
            
        if ( Time.time - _shotTimestamp < shotDelay) 
            return;
        _shotTimestamp = Time.time; 

        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range)){

            Debug.Log(hit.transform.name);
            EnemyController enemy = hit.transform.GetComponent<EnemyController>();
            if (enemy != null){
                enemy.TakeDamage(damage );
                
                GameObject impact = Instantiate(bloodImpact, hit.point, Quaternion.identity);//,Quaternion.LookRotation(hit.normal));
                Destroy(impact, 2.0f);
            }
        else {
            GameObject  wall= Instantiate(wallImpact, hit.point, Quaternion.identity);//,Quaternion.LookRotation(hit.normal));
            Destroy(wall, 2.0f);

            }
        }
    }
    void ShootOLD()
    {
    if ( Time.time - _shotTimestamp < shotDelay) 
            return;
    _shotTimestamp = Time.time; 


    Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

    GameObject bullet = Instantiate(shoot, gunWayPoint.transform.position, Camera.main.transform.rotation * Quaternion.Euler(0f, 90f, 0f));
    bullet.GetComponent<ShotBehaviour>().damage = damage;
    Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

    Vector3 direction = (ray.GetPoint(100000.0f) - bullet.transform.position).normalized;

    bulletRigidbody.AddForce(direction * bulletSpeed, ForceMode.Impulse);

    }

}
