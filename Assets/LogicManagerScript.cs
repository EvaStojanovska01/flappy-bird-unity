using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicManagerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public AudioSource gameOverSound;
    public AudioSource musicSource;

    void Start() {

        gameOverSound = GetComponent<AudioSource>();
    }


    [ContextMenu("Increase Score")]
    public void addScore(int score) {
        playerScore+=score;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver() { 
        gameOverScreen.SetActive(true);
        gameOverScreen.SetActive(true);
        musicSource.Stop();
        gameOverSound.PlayOneShot(gameOverSound.clip);
    }
}
