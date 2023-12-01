using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    public static WeaponControl Instance;

    public GameObject[] accesorios;
    public GameObject[] accesorios_esco;
    public int[]  spauner = new int[4];
    public int[] spauner_esco = new int[5];
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
