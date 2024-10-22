using System;
using UnityEngine;

public class UIController : MonoBehaviour
{
    #region VARIABLES

    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject optionsPanel;

    #endregion

    private void Start()
    {
        ShowOptions(false);
    }


    public void MainMenu(bool active) 
    {
            mainPanel.SetActive(active);
            optionsPanel.SetActive(!active);
    }
    
    public void ShowOptions(bool active)
    {
            optionsPanel.SetActive(active);
            mainPanel.SetActive(!active);
    }

}
