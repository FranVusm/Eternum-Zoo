using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bateriaConeccion : MonoBehaviour
{
    public Transform connectionPoint; // El punto de conexi�n del segundo objeto.
    public LayerMask objectLayer; // La capa de objetos con la que se puede conectar.

    private bool isConnecting = false; // Para rastrear si se est� intentando conectar.

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Lanzar un rayo desde el punto de clic del mouse.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Comprobar si el rayo golpea un objeto en la capa especificada.
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, objectLayer))
            {
                // Verificar si el punto de conexi�n del segundo objeto est� cerca del punto de impacto.
                if (Vector3.Distance(hit.point, connectionPoint.position) < 0.1f)
                {
                    // Conectar los objetos (por ejemplo, establecer la posici�n del segundo objeto en el punto de conexi�n).
                    hit.transform.position = connectionPoint.position;
                    isConnecting = true;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isConnecting = false;
        }
    }
}
