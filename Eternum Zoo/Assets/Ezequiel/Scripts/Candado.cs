using UnityEngine;

public class AplicarGravedad : MonoBehaviour
{
    private Rigidbody rb;

    public GameObject objetoARotar1; // Referencia al objeto que quieres rotar
     public GameObject objetoARotar2;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnMouseDown()
    {
        rb.useGravity = true;
        if (objetoARotar1 != null && objetoARotar2 != null)
        {
            objetoARotar1.GetComponent<RotarObjeto>().ActivarRotacion();
            objetoARotar2.GetComponent<RotarObjeto>().ActivarRotacion();
        }
    }
}