
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public float _baseSpeed = 10.0f;
    public float _gravidade = 9.8f; 
    public float jump = 5.0f;
    private int life;
    

    float y = 0;

    CharacterController characterController;

    //Referência usada para a câmera filha do jogador
    GameObject playerCamera;
    //Utilizada para poder travar a rotação no angulo que quisermos.
    float cameraRotation;

    GameManager gm;
    
    
    void Start()
    {
        gm = GameManager.GetInstance();
        characterController = GetComponent<CharacterController>();
        playerCamera = GameObject.Find("Main Camera");
        cameraRotation = 0.0f;
        life = 5;
        }
    
    void Update()
    {  
        if (gm.gameState != GameManager.GameState.GAME) {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;    
            Cursor.visible = true;
            return;
        }

        if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
            gm.ChangeState(GameManager.GameState.PAUSE);
            Time.timeScale = 0;
        }


        if (gm.lastState != GameManager.GameState.GAME && gm.gameState == GameManager.GameState.GAME){
            Cursor.lockState = CursorLockMode.Locked;    
            Cursor.visible = false;
        }

        //Tratando movimentação do mouse
        float mouse_dX = Input.GetAxis("Mouse X");
        float mouse_dY = Input.GetAxis("Mouse Y");
       
        //Tratando a rotação da câmera
        cameraRotation += -mouse_dY;
        cameraRotation = Mathf.Clamp(cameraRotation, -75.0f, 75.0f);

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
    }

    public void TakeDamage()
    {
        Debug.Log("Damage");
        life--;
        if (life <= 0) Die();
    }
    public void Die(){

        gm.ChangeState(GameManager.GameState.ENDGAME);
    }


}