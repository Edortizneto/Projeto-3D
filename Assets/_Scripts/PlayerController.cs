using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    float _baseSpeed = 4.0f;
    float _runSpeed = 8.0f;
    float _duckSpeed = 1.0f;
    float _actualSpeed;
    float _gravidade = 5.0f;
    bool _crouching = false;
    bool _flashlight = true; 
    bool _isLooking = false;
    float countdown = 5;
    float velJump = 0.0f;
    CharacterController characterController;
    GameObject playerCamera;
    Light playerFlashlight;
    float cameraRotation;
    float horizontalSpeed = 5.0f;
    float verticalSpeed = -5.0f;
    GameManager gm;
    AudioManager am;
    Camera cam;
    GameObject enemy;
    public AudioClip stepsAudio;

    void Start(){
        gm = GameManager.GetInstance();
        am = AudioManager.GetInstance();
        enemy = GameObject.Find("Enemy");
        cam = GetComponentInChildren<Camera>();
        playerCamera = GameObject.Find("Main Camera");
        cameraRotation = 0.0f;
        characterController = GetComponent<CharacterController>();
        characterController.height = 2.0f;
        _actualSpeed = _baseSpeed;
        playerFlashlight = GetComponentInChildren<Light>();
    }

    void Update(){
        if (gm.gameState != GameManager.GameState.GAME) return;
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
        PauseGame();
        StepsSounds(x, z);
        
        if (Input.GetKeyDown(KeyCode.X)){
            gm.progression++;
        }
        float dist = Vector3.Distance(enemy.transform.position, transform.position);
        Vector3 viewPos = cam.WorldToViewportPoint(enemy.transform.position);
        if ((viewPos.x > 0.0F && viewPos.x < 1.0f) && (viewPos.y > 0.0F && viewPos.y < 1.0f)) {
            if (viewPos.z > 0.0F){
                if (enemy.transform.position.y > 0) _isLooking = true;
            }
        }
        else
            _isLooking = false;
        if(_isLooking) 
            countdown -= Time.deltaTime;
        if(!_isLooking)  
            countdown = 5;
        if(countdown <= 0 || dist <= 2.0f) {
            gm.ChangeState(GameManager.GameState.GAMELOST);
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
        if(Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded) velJump = 7.0f;
        velJump -= velJump > 0 ? 7.0f * Time.deltaTime : 0.0f;
        return velJump;
    }

    void Run(){
        if (Input.GetKey(KeyCode.LeftShift)){
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
            _actualSpeed = _duckSpeed;
            characterController.height = 0.5f;
        } else {
            characterController.height = 2.0f;
        }
    }

    void Flashlight(){
        if (Input.GetKeyDown(KeyCode.F)){
            _flashlight = _flashlight ? false : true;
        }
        if (_flashlight) playerFlashlight.intensity = 4.0f;
        else playerFlashlight.intensity = 0.0f;
    }

    void PauseGame(){
        if (Input.GetKeyDown(KeyCode.P)){
            gm.ChangeState(GameManager.GameState.PAUSE);
        }
    }

    void StepsSounds(float x, float z){
        if ((x > 0.0f || z > 0.0f) && !am.sfxSource.isPlaying) AudioManager.PlaySFX(stepsAudio);
    }
}
