using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenToggle : MonoBehaviour
{
    [SerializeField] GameObject invenObj;
    public event Action OnInvenActiveChange;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            invenObj.SetActive(!invenObj.activeSelf);
            OnInvenActiveChange?.Invoke();
        }
    }
}
