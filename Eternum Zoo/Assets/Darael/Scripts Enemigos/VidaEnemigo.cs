using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public float vidaMaxima = 100f;
    public float vidaActual;
    private Transform jugador; // El objeto Transform del jugador al que nos moveremos
    private GameObject cuteAlien;
    private GameObject cuteAlienRagdoll;
    private GameObject armaAlien;
    private bool firstime = true;

    private BoxCollider _boxCollider;

    private void Start()
    {
        // Buscar los objetos CuteAlien y CuteAlienRagdoll en los hijos del objeto actual
        jugador = GameObject.Find("player").transform;
        cuteAlien = transform.Find("CuteAlien").gameObject;
        cuteAlienRagdoll = transform.Find("CuteAlienRagdoll").gameObject;
        armaAlien = transform.Find("ArmaAlien").gameObject;

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
    void Update()
    {
        // Verificar si el jugador está a una distancia mayor o igual a 50 unidades
        float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);
        if (distanciaAlJugador <= distanciaAcercarMaxima && distanciaAlJugador >= distanciaAcercarMínima && !muerto)
        {
            // Calcular la dirección hacia el jugador
            Vector3 direccionAlJugador = (jugador.position - transform.position).normalized;

            RaycastHit hit;
            
                    // Mover el NPC hacia el jugador solo si no hay obstáculos debajo
            transform.Translate(direccionAlJugador * velocidad * Time.deltaTime);
        
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


