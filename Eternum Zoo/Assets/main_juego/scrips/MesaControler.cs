using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MesaControler : MonoBehaviour
{
    LayerMask mask;
    public float distancia = 1.5f;
    public GameObject imagen;
    void Start()
    {
        mask = LayerMask.GetMask("Floor");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out hit, distancia, mask))
        {
            if (hit.collider.tag == "mesa")
            {
                 imagen.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E)) 
                {
                    hit.collider.transform.GetComponent<mesa_usu>().CambiarAScena();
                    Cursor.lockState = CursorLockMode.None;
                }
            }
        }
        else
        {
            imagen.SetActive(false);
        }
    }
}
