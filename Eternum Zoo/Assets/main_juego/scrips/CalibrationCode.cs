using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class CalibrationCode : MonoBehaviour
{
    public GameObject escopeta;
    public GameObject pistola;
    public GameObject silenciador;  
    public GameObject cargador;  
    public GameObject bateria;  
    public GameObject cooler;
    public GameObject bala;  
    public Transform Pos1;
    public Transform Pos2;
    public Transform Pos3;
    public Transform Pos4;
    public Transform PosBat;
   

    void Update()
    {
        if(escopeta.activeSelf){
            if (CheckSon(escopeta.transform.Find("arreglo_1")))
            {
                MostrarImagenEnPunto(escopeta.transform.Find("arreglo_1").gameObject);
            }
            if (CheckSon(escopeta.transform.Find("arreglo_2")))
            {
                Debug.Log("Mejora 2");
            }
            if (CheckSon(escopeta.transform.Find("arreglo_3")))
            {
                Debug.Log("Mejora 3");
            }
            if (CheckSon(escopeta.transform.Find("arreglo_4")))
            {
                Debug.Log("Mejora 4");
            }
            if (CheckSon(escopeta.transform.Find("spawnesco_5")))
            {
                Debug.Log("Se ha insertado la Bateria");
            }
        }


        if(pistola.activeSelf){
            if (CheckSon(pistola.transform.Find("spawn_1")))
            {
                Debug.Log("Mejora 1");
                
            }
            if (CheckSon(pistola.transform.Find("spawn_2")))
            {
                Debug.Log("Se ha insertado la bateria");
            }
            if (CheckSon(pistola.transform.Find("spawn_3")))
            {
                Debug.Log("Mejora 2");
            }
            if (CheckSon(pistola.transform.Find("spawn_4")))
            {
                Debug.Log("Mejora 3");
            }

        }
    }
    bool CheckSon(Transform spawnpoint){
        if (spawnpoint.childCount > 0){
            return true;
        }
        else{
            return false;
        }
    }

    void MostrarImagenEnPunto(GameObject objeto)
    {
        Transform objetoTransform = objeto.GetComponent<Transform>();
        if (objetoTransform.GetChild(0).name == "bateria(Clone)" || objetoTransform.GetChild(0).name == "bateria_esco(Clone)")
        {
            GameObject nuevaImagenGO = Instantiate(bateria, Vector3.zero, Quaternion.identity);
            Image nuevaImagen = nuevaImagenGO.GetComponent<Image>();
            float posX = PosBat.position.x;
            float posY = PosBat.position.y;
            Vector2 posBateriaVector2 = new Vector2(posX, posY);
            nuevaImagen.GetComponent<RectTransform>().anchoredPosition = posBateriaVector2;        
        }
        else if (objetoTransform.GetChild(0).name == "cargador(Clone)")
        {
            GameObject nuevaImagenGO = Instantiate(cargador, Vector3.zero, Quaternion.identity);
            Image nuevaImagen = nuevaImagenGO.GetComponent<Image>();
            float posX = Pos1.position.x;
            float posY = Pos1.position.y;
            Vector2 posBateriaVector2 = new Vector2(posX, posY);
            nuevaImagen.GetComponent<RectTransform>().anchoredPosition = posBateriaVector2;             
        }
        else if (objetoTransform.GetChild(0).name == "cooler(Clone)")
        {
            GameObject nuevaImagenGO = Instantiate(cooler, Vector3.zero, Quaternion.identity);
            Image nuevaImagen = nuevaImagenGO.GetComponent<Image>(); 
            float posX = Pos2.position.x;
            float posY = Pos2.position.y;
            Vector2 posBateriaVector2 = new Vector2(posX, posY);
            nuevaImagen.GetComponent<RectTransform>().anchoredPosition = posBateriaVector2;   
        }
        else if (objetoTransform.GetChild(0).name == "silenciador(Clone)")
        {
            GameObject nuevaImagenGO = Instantiate(silenciador, Vector3.zero, Quaternion.identity);
            Image nuevaImagen = nuevaImagenGO.GetComponent<Image>();    
            float posX = Pos3.position.x;
            float posY = Pos3.position.y;
            Vector2 posBateriaVector2 = new Vector2(posX, posY);
            nuevaImagen.GetComponent<RectTransform>().anchoredPosition = posBateriaVector2;   
        }
        else if (objetoTransform.GetChild(0).name == "balas_reserva(Clone)")
        {
            GameObject nuevaImagenGO = Instantiate(bala, Vector3.zero, Quaternion.identity);
            Image nuevaImagen = nuevaImagenGO.GetComponent<Image>(); 
            float posX = Pos4.position.x;
            float posY = Pos4.position.y;
            Vector2 posBateriaVector2 = new Vector2(posX, posY);
            nuevaImagen.GetComponent<RectTransform>().anchoredPosition = posBateriaVector2;   
        }

    
    }

}
