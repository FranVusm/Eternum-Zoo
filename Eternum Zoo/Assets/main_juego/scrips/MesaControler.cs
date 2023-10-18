using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesaControler : MonoBehaviour
{
    LayerMask mask;
    public float distancia = 1.5f;
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
                if(Input.GetKeyDown(KeyCode.E)) 
                {
                    hit.collider.transform.GetComponent<mesa_usu>().CambiarAScena();
                    Cursor.lockState = CursorLockMode.None;
                }
            }
        }
    }
}
