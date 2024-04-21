using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] TMP_Text countDownTX;
    public float minutes = 2;
    public float seconds = 60;
    bool isCounting = true;

    void Update()
    {
        if (isCounting)
        {
            seconds -= Time.deltaTime;
            if (seconds <= 0)
            {
                seconds = 0;
                if (minutes > 0) // Solo actualizar minutos si hay minutos restantes
                {
                    minutes--;
                    seconds = 59; // Restaurar los segundos a 59 cuando se actualiza los minutos
                }
                else
                {
                    isCounting = false; // Detener el contador cuando el tiempo llegue a cer0
                    GameEvents.OnCountdownZero.Invoke();
                }
            }

            countDownTX.text = minutes.ToString("00") + ":" + Mathf.RoundToInt(seconds).ToString("00");
        }
    }

    public void ResetTime()
    {
        minutes = 0;
        seconds = 15;
        isCounting = true;
    }
}

