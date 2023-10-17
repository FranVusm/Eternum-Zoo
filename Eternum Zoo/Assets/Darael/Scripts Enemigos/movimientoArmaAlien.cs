using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoArmaAlien : MonoBehaviour
{
    public Transform targetTransform; // Objeto cuya posición y rotación queremos igualar

    void Update()
    {
        if (targetTransform != null)
        {
            // Iguala la posición y rotación del objeto actual con el objeto de destino
            transform.position = targetTransform.position;
            transform.rotation = targetTransform.rotation;
        }
        else
        {
            Debug.LogError("Objeto de destino no asignado en el script MatchTransform.");
        }
    }
}
