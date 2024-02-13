using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWIn : MonoBehaviour
{
    [SerializeField] VoidEvent gameWinEvent;

    private void OnTriggerEnter(Collider other)
    {
        gameWinEvent.RaiseEvent();
    }
}
