using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject GameOverMenu;
    int contador=1;
    int personaje = 1;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        PauseGame();
    }
    public void Menu()
    {
        
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void startGame()
    {
        
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
        }
    }
    public void regreso()
    {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
    }
    public void GameOver()
    {
        personaje--;
        if(personaje < 1)
        {
            Time.timeScale = 0;
            GameOverMenu.SetActive(true);
        }
    }

    
}

