using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UiEnd : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtTotalTime;
    [SerializeField] private TextMeshProUGUI txtTotalCollisions;
    [SerializeField] private TextMeshProUGUI txtFinalTime;
    [SerializeField] private Button restartBtn;
    private void Awake()
    {
        UIGame uigame = FindAnyObjectByType<UIGame>();
        if(uigame != null)
        {
            Destroy(uigame.gameObject);
        }
    }

    private void Start()
    {
        txtTotalCollisions.text = $"Collisions : {GameManager.Instance.NbCollisions}";
        txtTotalTime.text = $"Temps total: {GameManager.Instance.EndTime:f2}";
        float final = GameManager.Instance.NbCollisions + GameManager.Instance.EndTime;
        txtFinalTime.text = $"Temps final : {final:f2}";
        EventSystem.current.SetSelectedGameObject(restartBtn.gameObject);
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
}
