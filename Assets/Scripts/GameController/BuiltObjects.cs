using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BuiltObjects : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI UI;
    public TextMeshProUGUI puntos;
    [SerializeField] GameObject structure;
    [SerializeField] int structureValor;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if(gameManager.puntosTotales >= structureValor)
            {
                UI.gameObject.SetActive(true);

                if (Input.GetKey(KeyCode.E))
                {
                    
                    structure.SetActive(true);
                    gameManager.puntosTotales -= structureValor;
                    puntos.text = gameManager.puntosTotales.ToString();
                    UI.gameObject.SetActive(false);
                    print(gameManager.puntosTotales);
                    
                }
                else
                {
                    Debug.Log("No tienes materiales");
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UI.gameObject.SetActive(false);
        }
    }
}
