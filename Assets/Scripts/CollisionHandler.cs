using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    public GameObject player;
    public ParticleSystem  ps;
    public GameObject WinScreen;
    public GameObject DeathScreen;
    public TMP_Text scoreMessage;
    public int scoreMultiplier = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WinScreen.SetActive(false);
        DeathScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreMessage.text = "Score: " + ComputeScore();
    }

    public void HandleReset(int check)
    {
        if (check == 1)
            WinScreen.SetActive(true);
        else
            DeathScreen.SetActive(true);

        Destroy(player);
        ps.Play();
        Invoke("RestartGame", 3f);
    }

    private int ComputeScore()
    {
        return Mathf.RoundToInt(scoreMultiplier * transform.position.z);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
