using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfMonitorManager : MonoBehaviour
{
	[SerializeField] private GameObject fpsModule;
	[SerializeField] private GameObject specsModule;
    private bool on;

    private void Start()
    {
        on = false;
        fpsModule.SetActive(on);
        specsModule.SetActive(on);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            if (on) on = false;
            else on = true;
            fpsModule.SetActive(on);
            specsModule.SetActive(on);
        }
    }
}
