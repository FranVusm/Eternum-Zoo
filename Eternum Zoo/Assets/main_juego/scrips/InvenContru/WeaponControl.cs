using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    public static WeaponControl Instance;

    public GameObject weaponPrefab; // Referencia al prefab del arma

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
        }
    }
}
