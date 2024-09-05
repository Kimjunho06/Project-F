using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmingTest : MonoBehaviour
{
    [SerializeField]
    private CropSO[] _testSO;
    private Soil _soil;

    private void Awake()
    {
        _soil = GetComponent<Soil>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _soil.Plow();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _soil.Water();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _soil.Fertilize();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _soil.cropBase.Harvest();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _soil.Plant(_testSO[0]);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            _soil.Plant(_testSO[1]);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            _soil.Plant(_testSO[2]);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            _soil.Plant(_testSO[3]);
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            _soil.Plant(_testSO[4]);
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            _soil.Plant(_testSO[5]);
        }
    }
}
