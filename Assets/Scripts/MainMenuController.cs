using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public TextMeshProUGUI uWinner;

    void Start()
    {
        SaveController.Instance.Reset();
        string lastWinner = SaveController.Instance.GetLastWinner();

        if (lastWinner != "None")
        {
            uWinner.text = "Último vencedor: " + lastWinner;
        }
        else
        {
            uWinner.text = "";
        }
    }
}
