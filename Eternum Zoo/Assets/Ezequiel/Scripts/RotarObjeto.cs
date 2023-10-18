using UnityEngine;

public class RotarObjeto : MonoBehaviour
{
    public float velocidadRotacion = 1.0f;
    public float limiteRotacion = 90.0f; // Nuevo campo para el límite de rotación

    private bool rotacionActiva = false;
    private int n = 0;

    public void ActivarRotacion()
    {
        rotacionActiva = true;
    }

    void Update()
    {
        if (rotacionActiva)
        {
            float rotacion = velocidadRotacion * Time.deltaTime;

            // Limitar la rotación
            if (limiteRotacion > 0)
            {


                if (Mathf.Abs(transform.localEulerAngles.y + rotacion) <= limiteRotacion)
                {
                    
                    transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
                }

            }
            else{
                if (n < 3)
                {
                    transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
                    n +=1;
                }

                if (Mathf.Abs(transform.localEulerAngles.y + rotacion) >= 270 )
                {
                    transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
                }
            }
        }
    }
}
