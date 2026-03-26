using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIStart : MonoBehaviour
{
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject instructionPanel;

    [SerializeField] Button startBtn;
    [SerializeField] Button closeBtnInstructions;


    private void Awake()
    {
        GameManager uigame = FindAnyObjectByType<GameManager>();
        if (uigame != null)
        {
            Destroy(uigame.gameObject);
        }
    }

    private void Start()
    {
        //Sélectionner un btn par défaut
        EventSystem.current.SetSelectedGameObject(startBtn.gameObject);
    }
    public void OnStartClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnInstructionsClick() 
    {
        //Faire apparaitre les instructions
        startPanel.SetActive(false);
        instructionPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(closeBtnInstructions.gameObject);
    }

    public void OnCloseCLick()
    {
        startPanel.SetActive(true);
        instructionPanel.SetActive(false);
    }

    public void OnQuitClick() 
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying= false;
#else
        Application.Quit();
#endif
    }
}
