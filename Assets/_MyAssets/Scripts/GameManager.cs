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

        CollisionManager.OnCollisionOccured += CollisionManager_OnCollisionOccured;
    }

    private void OnDestroy()
    {
        CollisionManager.OnCollisionOccured -= CollisionManager_OnCollisionOccured;
        Player.OnPlayerPaused += Player_OnPlayerPaused;
    }

    private float startTime;
    public float StartTime => startTime;    
    private float endTime;
    public float EndTime { get => endTime; set => endTime = value; }

    private bool isPaused = false;

    private void Start()
    {
        _nbCollisions = 0;
        startTime= Time.time;
        Player.OnPlayerPaused += Player_OnPlayerPaused;
    }
    private void Player_OnPlayerPaused(object sender, System.EventArgs e)
    {
        if(isPaused)
        {

        }
    }

    private void CollisionManager_OnCollisionOccured(object sender, CollisionManager.OnCollisionOccuredEventArgs e)
    {
        _nbCollisions += e.CollisionValue;
    }

}
