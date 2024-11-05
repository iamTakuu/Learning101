using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    public void HideStartPanel()
    {
        panel.SetActive(false);
    }
}
