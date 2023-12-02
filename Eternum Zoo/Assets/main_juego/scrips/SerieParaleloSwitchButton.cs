using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SerieParaleloSwitchButton : MonoBehaviour
{
    public Image On;
    public Image Off;
    public GameObject Paralelo;
    public GameObject Serie;

    int index;
    // Start is called before the first frame update
    void Start()
    {
        Paralelo.gameObject.SetActive(false);
        Serie.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(index==1){
            Serie.gameObject.SetActive(false);
            Paralelo.gameObject.SetActive(true);
        }
        if(index==0){
            Serie.gameObject.SetActive(true);
            Paralelo.gameObject.SetActive(false);
        }    
    }



    public void ON(){
        index = 1;
        Off.gameObject.SetActive(true);
        On.gameObject.SetActive(false);
    }


    public void OFF(){
        index = 0;
        Off.gameObject.SetActive(false);
        On.gameObject.SetActive(true);
    }

}
