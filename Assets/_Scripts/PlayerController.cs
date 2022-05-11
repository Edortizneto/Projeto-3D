using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    float _baseSpeed = 4.0f;
    float _runSpeed = 8.0f;
    float _duckSpeed = 1.0f;
    float _actualSpeed; //= 10.0f;
    float _gravidade = 2.0f;
    //bool _runnnig = false;
    bool _crouching = false;
    bool _flashlight = true; 
    float velJump = 0.0f;
    GameManager gm;
    CharacterController characterController;
    GameObject playerCamera;
    Light playerFlashlight;
    float cameraRotation;
    float horizontalSpeed = 5.0f;
    float verticalSpeed = -5.0f;



    void Start(){
        playerCamera = GameObject.Find("Main Camera");
        cameraRotation = 0.0f;
        characterController = GetComponent<CharacterController>();
        characterController.height = 2.0f;
        _actualSpeed = _baseSpeed;
        playerFlashlight = GetComponentInChildren<Light>();
        gm = GameManager.GetInstance();
    }

    void Update(){
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        float mouse_dX = horizontalSpeed * Input.GetAxis("Mouse X");
        float mouse_dY = verticalSpeed * Input.GetAxis("Mouse Y");

        cameraRotation += mouse_dY;
        cameraRotation = Mathf.Clamp(cameraRotation, -75.0f, 75.0f);

        float y = 0;
        y += Jump();
        if(!characterController.isGrounded) y -= _gravidade;

        Vector3 direction = transform.right * x + transform.up * y + transform.forward * z;
        characterController.Move(direction * _actualSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, mouse_dX);
        playerCamera.transform.localRotation = Quaternion.Euler(cameraRotation, 0.0f, 0.0f);
        
        Run();
        Duck();
        Flashlight();
        // Para testes apenas
        if (Input.GetKeyDown(KeyCode.X)){
            gm.progression++;
            //Debug.Log($"{gm.progression}");
        }
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

    void Run(){
        //print(Input.GetKeyDown(KeyCode.LeftShift));
        //print(_runnnig);
        /*if (Input.GetKeyDown(KeyCode.LeftShift) && _runnnig){ 
            _actualSpeed = _baseSpeed;
            _runnnig = false;
        }*/
        if (Input.GetKey(KeyCode.LeftShift)){
            //Debug.Log($"is LShift pressed: {Input.GetKey(KeyCode.LeftShift)}");
            _actualSpeed = _runSpeed;
        } else {
            _actualSpeed = _baseSpeed;
        }
    }

    void Duck(){

        if (Input.GetKeyDown(KeyCode.LeftControl) && characterController.isGrounded){
            _crouching = _crouching ? false : true;
        }    
        if (_crouching){    
            //Debug.Log($"is LControl pressed: {Input.GetKey(KeyCode.LeftControl)}");
            _actualSpeed = _duckSpeed;
            characterController.height = 0.5f;
            //transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        } else {
            characterController.height = 2.0f;
        }
    }

    void Flashlight(){
        if (Input.GetKeyDown(KeyCode.F)){
            _flashlight = _flashlight ? false : true;
        }
        if (_flashlight) playerFlashlight.intensity = 0.0f;
        else playerFlashlight.intensity = 4.0f;
    }
}
