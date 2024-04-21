using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public int puntosTotales;
    int puntosAleatorios;

    public void SumarPuntos(int puntosASumar)
    {
        puntosAleatorios = Random.Range(1, 10);

        int puntosSumados = puntosAleatorios + puntosASumar;

        puntosTotales += puntosSumados;

        print("Puntos Totales: " + puntosTotales);
    }
}
