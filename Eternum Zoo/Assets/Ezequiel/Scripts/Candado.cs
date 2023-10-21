using UnityEngine;

public class Candado : MonoBehaviour
{
    private Rigidbody rb;

    public GameObject objetoARotar1; // Referencia al objeto que quieres rotar
     public GameObject objetoARotar2;
    public bool inicia = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    public void AbrirCandado()
    {
        inicia = true;
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.None;
        if (objetoARotar1 != null && objetoARotar2 != null)
        {
            objetoARotar1.GetComponent<RotarObjeto>().ActivarRotacion();
            objetoARotar2.GetComponent<RotarObjeto>().ActivarRotacion();
        }
    }
}