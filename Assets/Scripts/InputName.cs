using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputName : MonoBehaviour
{
    public bool isPlayer;
    public TMP_InputField inputField;

    void Start()
    {
        inputField.onValueChanged.AddListener(UpdateName); 
    }

    public void UpdateName(string name)
    {
        if(isPlayer)
            SaveController.Instance.namePlayer = name;
        else
            SaveController.Instance.nameEnemy = name;
    }
}
