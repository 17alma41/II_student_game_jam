using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    public static UnityEvent PlayerDead = new UnityEvent();
    public static UnityEvent OnCountdownZero = new UnityEvent();
}
