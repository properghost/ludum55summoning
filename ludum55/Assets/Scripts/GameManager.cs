using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isPaused;
    [SerializeField] private GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            isPaused = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            isPaused = false;
        }

        if(isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        else{pausePanel.SetActive(false); Time.timeScale = 1;};
    }
}
