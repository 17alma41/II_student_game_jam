using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject menuInicial;
    [SerializeField] GameObject menuCreadores;
    void Start()
    {
        menuCreadores.SetActive(false);
        menuInicial.SetActive(true);

    }
    public void Play()
    {
        Debug.Log("Bot�n play");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CreadoresMenu()
    {
        Debug.Log("Bot�n creadores");
        menuCreadores.SetActive(true);
        menuInicial.SetActive(false);
    }

    public void Volver()
    {
        Debug.Log("Bot�n volver");
        menuCreadores.SetActive(false);
        menuInicial.SetActive(true);
    }
    public void Exit()
    {
        Debug.Log("Bot�n salir");
        Application.Quit();
    } 

}
