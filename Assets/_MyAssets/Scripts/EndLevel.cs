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
            if(noScene < SceneManager.sceneCountInBuildSettings - 1)
            {
                SceneManager.LoadScene(noScene + 1);
            }
            else
            {
                Player player = FindAnyObjectByType<Player>();
                player.EndGamePlayer();
                Debug.Log("------ Fin de partie ------");
                Debug.Log("Nombre total de collisions : " + GameManager.Instance.NbCollisions.ToString());
                // Time.time temps écoule en secondes depuis le début du jeu au complet
                Debug.Log("Temps total : " + Time.time.ToString("f2") + " secondes");
                float tempsTotal = Time.time + GameManager.Instance.NbCollisions;
                Debug.Log("Temps final avec collisions :" + tempsTotal.ToString("f2") + " secondes");
            }
        }
 
    }
}
