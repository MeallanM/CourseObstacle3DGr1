using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _nbCollisions;
    public int NbCollisions => _nbCollisions; // accesseur

    // Mise en place Singleton
    public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null) 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _nbCollisions = 0;
    }

    public void AddCollision(int p_collision)
    {
        _nbCollisions += p_collision;
        Debug.Log("Nombre de collisions : " + _nbCollisions);
    }
}
