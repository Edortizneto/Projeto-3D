using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    float _baseSpeed = 10.0f;
    float _runSpeed = 20.0f;
    float _actualSpeed = 10.0f;
    float _gravidade = 2.0f;
    bool _runnnig = false; 
    float velJump = 0.0f;
    CharacterController characterController;
    GameObject playerCamera;
    float cameraRotation;


    void Start(){
        playerCamera = GameObject.Find("Main Camera");
        cameraRotation = 0.0f;
        characterController = GetComponent<CharacterController>();
    }

    void Update(){
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        float mouse_dX = Input.GetAxis("Mouse X");
        float mouse_dY = Input.GetAxis("Mouse Y");

        cameraRotation += mouse_dY;
        cameraRotation = Mathf.Clamp(cameraRotation, -75.0f, 75.0f);

        float y = 0;
        y += Jump();
        if(!characterController.isGrounded) y -= _gravidade;

        Vector3 direction = transform.right * x + transform.up * y + transform.forward * z;
        characterController.Move(direction * _actualSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, mouse_dX);
        playerCamera.transform.localRotation = Quaternion.Euler(cameraRotation, 0.0f, 0.0f);
    }

    void LateUpdate(){
        RaycastHit hit;
        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward*10.0f, Color.magenta);
        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 100.0f)){
            //Debug.Log(hit.collider.name);
        }
    }


    float Jump(){
        
        if(Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded) velJump = 5.0f;
        velJump -= velJump > 0 ? 7.0f * Time.deltaTime : 0.0f;
        return velJump;
    }

    void CheckRun(){
        print(Input.GetKeyDown(KeyCode.LeftShift));
        print(_runnnig);
        if (Input.GetKeyDown(KeyCode.LeftShift) && _runnnig){ 
            _actualSpeed = _baseSpeed;
            _runnnig = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && !_runnnig) {
            _actualSpeed = _runSpeed;
            _runnnig = true;
        }
    }
}
