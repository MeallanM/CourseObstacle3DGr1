using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;


public class UIGame : MonoBehaviour
{
    public static UIGame Instance;
    [SerializeField] private GameObject pausePnl;
    [SerializeField] private Button continueBtn;
    [SerializeField] private TextMeshProUGUI txtChrono;
    [SerializeField] private TextMeshProUGUI txtCollisions;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogError("Un deuxieme UIGame essaie de se créé");
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        Player.OnPlayerPaused += Player_OnPlayerPaused;
        CollisionManager.OnCollisionOccured += CollisionManager_OnCollisionOccured;
        ChangeCollisionUI();
    }

    private void Player_OnPlayerPaused(object sender, System.EventArgs e)
    {
        pausePnl.SetActive(!pausePnl.activeSelf);
        EventSystem.current.SetSelectedGameObject(pausePnl.gameObject);
    }

    private void OnDestroy()
    {
        Player.OnPlayerPaused -= Player_OnPlayerPaused;

        CollisionManager.OnCollisionOccured -= CollisionManager_OnCollisionOccured;

    }


    private void Update()
    {
        TimeDisplayUI();
    }

    private void TimeDisplayUI()
    {
        float elapsedTime = Time.time - GameManager.Instance.StartTime;
        txtChrono.text = $"Temps : {elapsedTime:f2}";
    }

    private void CollisionManager_OnCollisionOccured(object sender, CollisionManager.OnCollisionOccuredEventArgs e)
    {
        ChangeCollisionUI();
    }

    private void ChangeCollisionUI()
    {
        txtCollisions.text = $"Collision : {GameManager.Instance.NbCollisions}";
    }

    public void OnRestartClick()
    {
        SceneManager.LoadScene(0);
    }

    public void OnQuitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OnContinueClick()
    {
        Player.OnPlayerPause
    }
}
