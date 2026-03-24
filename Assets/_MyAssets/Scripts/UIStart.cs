using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStart : MonoBehaviour
{
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject instructionPanel;
    public void OnStartClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnInstructionsClick() 
    {
        //Faire apparaitre les instructions
        startPanel.SetActive(false);
        instructionPanel.SetActive(true);
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
