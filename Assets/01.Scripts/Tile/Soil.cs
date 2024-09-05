using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags]
public enum SoilState
{
    Default = 0,
    Plantable = 1 << 0,
    Wet = 1 << 1,
    Fertile = 1 << 2,
    Planted = 1 << 3,
}

public class Soil : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _soilSprites;
    public SoilState currentState { get; set; }
    public Crop cropBase { get; set; }
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        cropBase = transform.GetChild(0).GetComponent<Crop>();
        cropBase.plantedSoil = this;

        cropBase.gameObject.SetActive(false);
    }

    public bool Plow()
    {
        if (currentState != SoilState.Default)
        {
            return false;
        }

        currentState = SoilState.Plantable;
        _spriteRenderer.sprite = _soilSprites[1];

        return true;
    }

    public bool Water()
    {
        if (currentState == SoilState.Default)
        {
            return false;
        }

        if ((currentState & SoilState.Wet) == SoilState.Default)
        {
            currentState |= SoilState.Wet;
            _spriteRenderer.sprite = _soilSprites[2];

            return true;
        }

        return false;
    }

    public bool Fertilize()
    {
        if (currentState == SoilState.Default)
        {
            return false;
        }

        if ((currentState & SoilState.Fertile) == SoilState.Default)
        {
            currentState |= SoilState.Fertile;
            Debug.Log("비료를 사용함.");

            return true;
        }

        return false;
    }

    public bool Plant(CropSO crop)
    {
        if (currentState == SoilState.Default)
        {
            return false;
        }

        cropBase.gameObject.SetActive(true);

        bool hasPlanted = cropBase.Plant(crop);

        if (!hasPlanted)
        {
            cropBase.gameObject.SetActive(false);
        }
        else
        {
            currentState |= SoilState.Planted;
        }

        return hasPlanted;
    }
}
