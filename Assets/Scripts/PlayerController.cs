using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{   
    // Controlador del personaje
    public CharacterController controller;
    // Obtener camara
    public Camera mainCamera;
    Vector3 camX;
    Vector3 camZ;
    // Cuerpo de velocidad
    Vector3 velocity;
    Vector3 move;
    // Definir variables
    public float speed = 0f;
    public float gravity = -9.81f;
    void Start(){}

    private void Update() {
        // Obtener el input del jugador.
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        camUpdate();
        // Mover el cuerpo del jugador según velocidad e input.
        move = x * camZ + z * camX;
        velocity.y += gravity * Time.deltaTime;
    }

    void camUpdate(){
        // Fijar el movimiento por el angulo de la camara.
        camX = mainCamera.transform.forward;
        camZ = mainCamera.transform.right;
        camX = camX.normalized;
        camZ = camZ.normalized;
        camX.y = 0;
        camZ.y = 0;
    }

    void FixedUpdate() 
    {   
        controller.Move(move * speed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }
}
