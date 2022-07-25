using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;

    private void Awake()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    private void OnPausebtn()
    {
        Time.timeScale = pausePanel.activeSelf ? 1 : 0;
        pausePanel.SetActive(!pausePanel.activeSelf);
    }
}
