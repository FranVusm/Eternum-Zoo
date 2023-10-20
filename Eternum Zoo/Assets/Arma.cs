 
using UnityEngine;

public class Arma : MonoBehaviour
{
    public GameObject[] spawn;
    
    // Start is called before the first frame update
    void Start()
    {
        
        GameObject[] accesorios = WeaponControl.Instance.accesorios;
        int[] spawn_content = WeaponControl.Instance.spauner;
        
        for (int i = 0;i<spawn.Length ;i++)

        {
            if (spawn_content[i] == -1)
            {
                continue;
            }

            Vector3 spawnPosition = spawn[i].transform.position;
            Quaternion spawnRotation = spawn[i].transform.rotation;

            // Instancia el objeto en la posición y rotación del spawn[i]
            GameObject newAccesorio = Instantiate(accesorios[spawn_content[i]], spawnPosition, spawnRotation);

            // Mantén la escala del accesorio
            Vector3 accesorioScale = accesorios[spawn_content[i]].transform.localScale;
            newAccesorio.transform.localScale = accesorioScale;

            // Establece el padre del objeto recién instanciado para mantenerlo unido
            newAccesorio.transform.parent = spawn[i].transform;


        }
        
    }

   
}
