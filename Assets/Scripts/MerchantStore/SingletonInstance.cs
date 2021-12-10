using UnityEngine;

class SingletonInstance : MonoBehaviour
{
    public static SingletonInstance Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }
    }
}
