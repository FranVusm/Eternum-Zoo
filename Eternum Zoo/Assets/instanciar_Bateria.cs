using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class instanciar_Bateria : MonoBehaviour
{
    public GameObject prefab3D; // Asigna el prefab 3D desde el Inspector
    private Image imagenSeleccionada; // Almacena la imagen seleccionada actualmente
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Dictionary<Image, GameObject> imagenesYPrefabs = new Dictionary<Image, GameObject>();
    public void AsociarImagenConPrefab(Image imagen, GameObject prefab)
    {
        imagenesYPrefabs[imagen] = prefab;
    }
    // Update is called once per frame
    void Update()
    { 

    }
    public void SeleccionarObjeto()
    {
        if (imagenSeleccionada != null && imagenesYPrefabs.ContainsKey(imagenSeleccionada))
        {
            GameObject objetoInstanciado = Instantiate(imagenesYPrefabs[imagenSeleccionada]);
            // Puedes ajustar la posición y la orientación del objeto instanciado según tus necesidades
        }
    }
}
