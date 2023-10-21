 
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boton_volver : MonoBehaviour
{
    // Start is called before the first frame update

     
    public void CambiarAScena()
    {
         
        SceneManager.LoadScene("NivelZoo");
        

    }
    
}
