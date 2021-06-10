using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public AudioClip shotSound;
    public AudioClip reloadSound;
    public GameObject parent;
    public GameObject shoot;
    public float shotDelay;
    private float _shotTimestamp = 0.0f; 
    public int damage;
    public float range = 100f;
    public int totalBullets;
    public int bullets;
    public float reloadTime;
    
    public GameObject reloadMessage; 

    public ParticleSystem muzzleFlash;

    public GameObject bloodImpact;

    public GameObject wallImpact;
    GameManager gm;

    private bool isReloading = false;
    



    void Start()
    {
        gm = GameManager.GetInstance();
        gm.bullets = bullets;
        gm.totalBullets = totalBullets;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && gm.bullets > 0 && !isReloading)
            Shoot();
        if ((gm.bullets <=0 || Input.GetKeyDown(KeyCode.R)) && !isReloading && gm.totalBullets >= 0){
            isReloading = true;
            StartCoroutine(Reload());}
        if (gm.bullets <= 2 && gm.totalBullets > 0 && !isReloading)
            reloadMessage.gameObject.SetActive(true);
        else  
            reloadMessage.gameObject.SetActive(false);
        
    }
    
    void Shoot(){
        
        if ( Time.time - _shotTimestamp < shotDelay) 
            return;
        _shotTimestamp = Time.time; 
        muzzleFlash.Play();
        gm.bullets--;
        AudioManager.PlaySFX(shotSound);


        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range)){

            // Debug.Log(hit.transform.name);
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

    IEnumerator Reload() {
        AudioManager.PlaySFX(reloadSound);
        yield return new WaitForSeconds(reloadTime);
        if (gm.totalBullets >= bullets) {
            gm.bullets = bullets;
            gm.totalBullets -= gm.bullets;}
        else {
            gm.bullets = gm.totalBullets;
            gm.totalBullets = 0;}
        isReloading = false;
    }

}
