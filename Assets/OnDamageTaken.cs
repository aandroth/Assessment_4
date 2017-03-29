using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnDamageTaken : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    public void ReportDamage()
    {
        Debug.Log("Damage was taken!");
    }
}
