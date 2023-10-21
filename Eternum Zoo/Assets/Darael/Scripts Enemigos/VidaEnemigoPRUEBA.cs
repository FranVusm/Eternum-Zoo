using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigoPRUEBA : MonoBehaviour
{
    public float vidaMaxima = 100f;
    public float vidaActual;
    private Transform jugador; // El objeto Transform del jugador al que nos moveremos
    private GameObject cuteAlien;
    private GameObject cuteAlienRagdoll;
    private GameObject armaAlien;
    private bool firstime = true;
    private Rigidbody rb;
    int capaSuelo;
    private BoxCollider _boxCollider;

    private void Start()
    {
        // Buscar los objetos CuteAlien y CuteAlienRagdoll en los hijos del objeto actual
        jugador = GameObject.Find("JugadorSOLOMOVIMIENTO").transform;
        cuteAlien = transform.Find("CuteAlien").gameObject;
        cuteAlienRagdoll = transform.Find("CuteAlienRagdoll").gameObject;
        armaAlien = transform.Find("ArmaAlien").gameObject;
        capaSuelo = LayerMask.NameToLayer("Floor");
        rb = GetComponent<Rigidbody>();


        // Inicializar la vida actual
        vidaActual = vidaMaxima;

        // Obtener el boxCollider del padre
        _boxCollider = GetComponent<BoxCollider>();
    }

    
    public float velocidad = 3f; // Velocidad a la que nos moveremos hacia el jugador
    public float distanciaAcercarMaxima = 10f;
    public float distanciaAcercarMínima = 1f;
    //public LayerMask capaSuelo; // Capa "Floor"
    private bool muerto = false;
    private float speed = 10;
    private float multiplier = 10;

    void Update()
    {
        // Verificar si el jugador está a una distancia mayor o igual a 50 unidades
        
        float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);
        if (distanciaAlJugador <= distanciaAcercarMaxima && distanciaAlJugador >= distanciaAcercarMínima && !muerto)
        {
            rb.AddForce(speed * multiplier * Time.deltaTime * transform.forward);
        
            // Verificar si hay suelo debajo del NPC
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 100f, capaSuelo))
            {
                // Ajustar la posición vertical del NPC para que esté en el suelo
                Vector3 newPosition = transform.position;
                newPosition.y = hit.point.y; // Establecer la altura del suelo
                transform.position = newPosition;
            }
        }
        
        
    }

    public void RecibirDanio(float cantidadDanio)
    {
        // Restar la cantidad de daño a la vida actual
        vidaActual -= cantidadDanio;

        // Verificar si la vida ha llegado a cero o menos
        if (firstime && vidaActual <= 0f)
        {
            // Desactivar CuteAlien y activar CuteAlienRagdoll
            cuteAlien.SetActive(false);
            armaAlien.SetActive(false);
            cuteAlienRagdoll.SetActive(true);
            
            // Desactivando el BoxColldier del Padre, para que aparezca el Rigdoll
            _boxCollider.enabled = false;
            muerto = true;

            // Puedes agregar aquí cualquier otra lógica que necesites cuando el enemigo muere
        }
    }
}


