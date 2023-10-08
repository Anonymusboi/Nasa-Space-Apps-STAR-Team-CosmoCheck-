using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDataGenerator : MonoBehaviour
{
    public bool radProt, backupBattery;
    public float oxygen, nitrogen, heatResist, cabinPressure, temp, fuelValue;
    public string fuelType, comms, mats, powerType;
    public string[] possibleComms = { "NearEarth", "Space", "Deep Space" },
        possibleMats = { "Aluminum", "Steel", "Titanium", "Carbon Fiber", "Glass Epoxy", "Ceramic" },
        possibleFuels = { "Hydrogen", "Oxygen", "Methane", "Kerosene" },
        possiblePowers = { "Solar", "Unstable Atoms", "Battery" };
    // Start is called before the first frame update
    void Start()
    {
        radProt =  Random.Range(0, 1) == 1;
        backupBattery = Random.Range(0, 1) == 1;
        oxygen = Random.Range(0, 100);
        nitrogen = 100 - oxygen;
        heatResist = Random.Range(1000, 4000);
        cabinPressure = Random.Range(5, 25);
        temp = Random.Range(5, 40);
        fuelValue = Random.Range(50, 120);
        fuelType = possibleFuels[Random.Range(0, 3)];
        comms = possibleComms[Random.Range(0, 2)];
        mats = possibleMats[Random.Range(0, 5)];
        powerType = possiblePowers[Random.Range(0, 2)];
    }
}
