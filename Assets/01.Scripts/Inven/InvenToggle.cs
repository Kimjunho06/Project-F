using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenToggle : MonoBehaviour
{
    [SerializeField] GameObject invenObj;
    [SerializeField] GameObject invenbarObj;
    public event Action OnInvenActiveChange;

    private void Start()
    {
        invenObj.SetActive(false);
        invenbarObj.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            invenObj.SetActive(!invenObj.activeSelf);
            invenbarObj.SetActive(!invenbarObj.activeSelf);
            OnInvenActiveChange?.Invoke();
        }
    }
}
