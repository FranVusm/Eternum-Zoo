using UnityEngine;

public class RotarObjeto : MonoBehaviour
{
    public float velocidadRotacion = 1.0f;
    public float limiteRotacion = 90.0f; // Nuevo campo para el límite de rotación

    private bool rotacionActiva = false;
    private int n = 0;
    public AudioSource audioSource1;
    public AudioSource audioSource2;

    // Variables para controlar si la música está reproduciéndose
    private bool isPlayingAudio1 = false;
    private bool isPlayingAudio2 = false;
    private bool cambioRealizado = false;

    public void ActivarRotacion()
    {
        rotacionActiva = true;
        // Si ya se realizó un cambio, salir del método
        if (cambioRealizado)
        {
            //Debug.Log("El cambio ya se realizó. No se puede cambiar nuevamente.");
            return;
        }

        if (isPlayingAudio1)
        {
            // Si audioSource1 está reproduciéndose, detenerlo y reproducir audioSource2
            audioSource1.Stop();
            audioSource2.Play();
            isPlayingAudio1 = false;
            isPlayingAudio2 = true;
        }
        // Marcar que el cambio se ha realizado
        cambioRealizado = true;
    }
    void Start(){
        audioSource1.Play();
        audioSource2.Stop();
        isPlayingAudio1 = true;
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
