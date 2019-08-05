using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerHead : MonoBehaviour, IInteractable
{
    private ParticleSystem ps;
    public bool isOn = false;

    private void Start()
    {
        ps = this.GetComponent<ParticleSystem>();
    }

    public void TurnOn()
    {
        isOn = true;
        ps.Play();
    }

    public void TurnOff()
    {
        isOn = false;
        ps.Stop();
    }

    public void Action()
    {
        if (isOn)
            TurnOff();
        else
            TurnOn();
    }
}
