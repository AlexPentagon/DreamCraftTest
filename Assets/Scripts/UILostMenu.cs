using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILostMenu : MonoBehaviour
{
    [SerializeField] Health playerHealth;
    [SerializeField] GameObject losePanel;

    private void Start()
    {
        playerHealth.OnDead += ShowMenu;
    }

    private void ShowMenu()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClickRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
