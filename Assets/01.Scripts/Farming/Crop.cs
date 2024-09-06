using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    public Soil plantedSoil { get; set; }
    public bool isHarvestable { get; set; }
    private SpriteRenderer _spriteRenderer;
    private CropSO _plantedCrop;
    private int _cropGrowthStage;
    private int _maxCropGrowthStage;
    private float _grownTimer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!_plantedCrop || _cropGrowthStage >= _maxCropGrowthStage)
        {
            return;
        }

        _grownTimer += (plantedSoil.currentState & SoilState.Fertile) == SoilState.Default ? Time.deltaTime : Time.deltaTime * 1.5f;

        if (_grownTimer >= _plantedCrop.grownTime)
        {
            Grow();
        }
    }

    public bool Plant(CropSO crop)
    {
        if (_plantedCrop != null)
        {
            return false;
        }

        _plantedCrop = crop;
        isHarvestable = false;
        _spriteRenderer.sprite = _plantedCrop.cropSprites[0];
        _cropGrowthStage = 0;
        _maxCropGrowthStage = _plantedCrop.cropSprites.Length - 1;
        _grownTimer = 0f;

        return true;
    }

    public void Grow()
    {
        if ((plantedSoil.currentState & SoilState.Wet) == SoilState.Default)
        {
            plantedSoil.currentState ^= SoilState.Planted;
            _plantedCrop = null;

            gameObject.SetActive(false);

            return;
        }

        _spriteRenderer.sprite = _plantedCrop.cropSprites[++_cropGrowthStage];
        _grownTimer = 0f;

        if (_cropGrowthStage >= _maxCropGrowthStage)
        {
            isHarvestable = true;
        }
    }

    public bool Harvest()
    {
        if (!isHarvestable)
        {
            return false;
        }

        Debug.Log($"{_plantedCrop.cropName} ¼öÈ®µÊ.");
        plantedSoil.Plow(true);

        isHarvestable = false;
        _plantedCrop = null;

        gameObject.SetActive(false);

        return true;
    }
}
