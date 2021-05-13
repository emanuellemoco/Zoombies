
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public GameObject shoot;
    public float bulletSpeed = 2.0f;
    public float _baseSpeed = 10.0f;
    public float _gravidade = 9.8f;
    public float jump = 5.0f;
    
    float y = 0;

    CharacterController characterController;

    //Referência usada para a câmera filha do jogador
    GameObject playerCamera;
    //Utilizada para poder travar a rotação no angulo que quisermos.
    float cameraRotation;
    
    
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = GameObject.Find("Main Camera");
        cameraRotation = 0.0f;
        Cursor.lockState = CursorLockMode.Locked;    
        Cursor.visible = false;
        }
    
    void Update()
    {   
        //Tratando movimentação do mouse
        float mouse_dX = Input.GetAxis("Mouse X");
        float mouse_dY = Input.GetAxis("Mouse Y");
       
        //Tratando a rotação da câmera
        cameraRotation += -mouse_dY;
        Mathf.Clamp(cameraRotation, -75.0f, 75.0f);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        if  (Input.GetKeyDown(KeyCode.Space))
            y += jump;


        //Verificando se é preciso aplicar a gravidade
        if(!characterController.isGrounded){
            y = -_gravidade;
        }
        
        Vector3 direction = transform.right * x + transform.up * y + transform.forward * z;

        characterController.Move(direction * _baseSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, mouse_dX);
        playerCamera.transform.localRotation = Quaternion.Euler(cameraRotation, 0.0f, 0.0f);
        
        
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }


    void Shoot()
    {

    //Instantiate(shoot, playerCamera.transform.position+(playerCamera.transform.forward*2), Quaternion.identity);

    Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

    GameObject bullet = Instantiate(shoot, playerCamera.transform.position+(playerCamera.transform.forward*2), Quaternion.identity);
    Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

    Vector3 direction = (ray.GetPoint(100000.0f) - bullet.transform.position).normalized;

    bulletRigidbody.AddForce(direction * bulletSpeed, ForceMode.Impulse);
    


    }
}