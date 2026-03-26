using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int noScene = SceneManager.GetActiveScene().buildIndex;

            // Vefifier si dernièr niveau du jeu
            if(noScene == SceneManager.sceneCountInBuildSettings - 2)
            {
                GameManager.Instance.EndTime = Time.time - GameManager.Instance.StartTime;
            }
            SceneManager.LoadScene(noScene + 1);
        }
 
    }
}
