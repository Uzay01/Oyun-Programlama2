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
        // Uygulamayý kapat.
        Application.Quit();

        // Bu satýr sadece Unity Editor içinde test ediyorsanýz iþe yarar.
        // Oyunun build edilmiþ bir sürümünde bu satýr etkili olmayacaktýr.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
