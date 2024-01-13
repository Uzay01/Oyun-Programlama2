using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        // Uygulamay� kapat.
        Application.Quit();

        // Bu sat�r sadece Unity Editor i�inde test ediyorsan�z i�e yarar.
        // Oyunun build edilmi� bir s�r�m�nde bu sat�r etkili olmayacakt�r.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
