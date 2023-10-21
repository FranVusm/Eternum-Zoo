using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    public static WeaponControl Instance;

    public GameObject[] accesorios;
    public int[]  spauner = new int[4];
   
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            Instance= this;
        }
    }
}
