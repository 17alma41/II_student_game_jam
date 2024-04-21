using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        // Reproducir el video automáticamente al iniciar la escena
        videoPlayer.Play();
    }

    void Update()
    {
        // Verificar si el video ha terminado de reproducirse
        if (!videoPlayer.isPlaying)
        {
            // Cargar la siguiente escena del juego
            SceneManager.LoadScene("MainScene");
        }
    }
}
