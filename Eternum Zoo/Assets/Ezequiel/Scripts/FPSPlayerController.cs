using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPlayerController : MonoBehaviour
{
    CharacterController characterController;

    [Header("Opciones de Personaje")]
    public float walkSpeed = 6.0f;
    public float runSpeed = 10.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    [Header("Opciones de Camara")]
    //public Camera cam;
    //public float mouseHorizontal = 30.0f;
    //public float mouseVertical = 20.0f;
    //public float minRotation = -65.0f;
    //public float maxRotation = 60.0f;
    //float h_mouse; 
    //float v_mouse;

    public Vector3 move =Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

       // h_mouse = mouseHorizontal * Input.GetAxis("Mouse X") * Time.deltaTime;
       // v_mouse += mouseVertical * Input.GetAxis("Mouse Y") * Time.deltaTime;

       // v_mouse = Mathf.Clamp(v_mouse, minRotation, maxRotation);
       // cam.transform.localEulerAngles = new Vector3(v_mouse, h_mouse, 0);

        if (characterController.isGrounded)
        {
            // Moverse
            move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            //Correr con Shift o si no caminar
            if(Input.GetKey(KeyCode.LeftShift))
                move = transform.TransformDirection(move) * runSpeed ;
            else
                move = transform.TransformDirection(move) * walkSpeed ;

            //Saltar
            if(Input.GetKey(KeyCode.Space))
            move.y = jumpSpeed;
        }

        //Gravedad
        move.y -=gravity *Time.deltaTime;

        characterController.Move(move * Time.deltaTime);
    }
}
