using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class STARAI : MonoBehaviour
{
    [SerializeField] ShipDataGenerator DataMaster;
    [SerializeField] TextMeshProUGUI STARDialogue;
    private int Oxygen = 21;
    private int Nitrogen = 79;
    private int HeatResistance = 2750;
    private string[] Comms = { "NearEarth", "Space", "Deep Space" };
    private string[] Materials = { "Aluminum", "Steel", "Titanium", "Carbon Fiber", "Glass Epoxy", "Ceramic" };
    private float CabinPressure = 14.7f;
    private string[] FuelType = { "Hydrogen", "Oxygen", "Methane", "Kerosene" };
    private string[] PowerType = { "Solar", "Unstable Atoms", "Battery" };
    private int Temperature = 24;
    private int FuelValue = 100;
    private string UserPowerType;
    private string UserFuelType;
    private string UserMaterials;

    private void Start()
    {
        DataMaster = GameObject.Find("Ship Data Master").GetComponent<ShipDataGenerator>();
        STARDialogue = GameObject.Find("Star Dialogue").GetComponent<TextMeshProUGUI>();
        STARDialogue.text = ("Welcome to STAR! (Standards Technical Assistance Resource)");
        Check();
        Recommendations();
    }

    private void Check()
    {
        bool RadiationProtection = DataMaster.radProt;
        if (RadiationProtection)
        {
            STARDialogue.text = (STARDialogue.text + "Radiation Protection is adequate");
            PilotScript.rad = true;
        }
        else
        {
            STARDialogue.text = (STARDialogue.text + "\nRadiation Protection is inadequate");
            STARDialogue.text = (STARDialogue.text + ". I have notified the ground crew to make appropriate changes.");
        }

        float UserOxygen = DataMaster.oxygen;
        float UserNitrogen = DataMaster.nitrogen;
        if (UserOxygen + UserNitrogen == 100)
        {
            if (UserOxygen == Oxygen && UserNitrogen == Nitrogen)
            {
                STARDialogue.text = (STARDialogue.text + "\nOxygen and Nitrogen levels are adequate");
                PilotScript.air = true;
            }
            else
            {
                STARDialogue.text = (STARDialogue.text + "\nOxygen and Nitrogen levels are inadequate");
                STARDialogue.text = (STARDialogue.text + ". I have notified the ground crew to create another mixture.");
            }
        }
        else
        {
            STARDialogue.text = (STARDialogue.text + "\nPlease reinput air mixture levels. The sum of Oxygen and Nitrogen should be 100.");
        }

        float UserHeatResistance = DataMaster.heatResist;
        if (UserHeatResistance >= HeatResistance)
        {
            STARDialogue.text = (STARDialogue.text + "\nHeat Resistance is adequate");
            PilotScript.heat = true;
        }
        else
        {
            STARDialogue.text = (STARDialogue.text + "\nHeat Resistance is inadequate");
            STARDialogue.text = (STARDialogue.text + ". Proper heat resistant shielding is on its way.");
        }

        string UserComms = DataMaster.comms;
        bool commsAvailable = false;
        foreach(string commSystem in Comms)
        {
            if (UserComms == commSystem)
            {
                STARDialogue.text = (STARDialogue.text + "\nCommunication system is recognized");
                commsAvailable = true;
                PilotScript.comms = true;
                break;
            }
        }
        if(!commsAvailable)
        {
            STARDialogue.text = (STARDialogue.text + "\nCommunication system was not recognized");
            STARDialogue.text = (STARDialogue.text + ". I have selected an appropriate communication system for the ship.");
        }
        UserMaterials = DataMaster.mats;
        bool MatsAvailable = false;
        foreach (string Material in Materials)
        {
            if (Material == UserMaterials)
            {
                STARDialogue.text = (STARDialogue.text + "\nMaterials are correct");
                MatsAvailable = true;
                PilotScript.mats = true;
                break;
            }
        }
        if (!MatsAvailable)
        {
            STARDialogue.text = (STARDialogue.text + "\nMaterials are incorrect");
            STARDialogue.text = (STARDialogue.text + ". A repair crew is on its way to replace the faulty parts of the hull.");
        }
        float UserCabinPressure = DataMaster.cabinPressure;
        if (CabinPressure - 0.2f <= UserCabinPressure && UserCabinPressure <= CabinPressure + 0.2f)
        {
            STARDialogue.text = (STARDialogue.text + "\nCabin Pressure is adequate");
            PilotScript.pres = true;
        }
        else
        {
            STARDialogue.text = (STARDialogue.text + "\nCabin Pressure was inadequate");
            STARDialogue.text = (STARDialogue.text + ". I have changed the cabin pressure to acceptable levels.");
        }

        UserFuelType = DataMaster.fuelType;
        bool fuelAvailable = false;
        foreach (string fuel in FuelType)
        {
            if (fuel == UserFuelType)
            {
                STARDialogue.text = (STARDialogue.text + "\nFuel Type is correct. ");
                fuelAvailable = true;
                if (UserFuelType == "Battery")
                {
                    bool choice = DataMaster.backupBattery;
                    if (choice == false)
                    {
                        STARDialogue.text = (STARDialogue.text + "However, please provide backup battery or risk running out of fuel");
                    }
                    PilotScript.bat = true;
                }
                PilotScript.fuelType = true;
                break;
            }
        }
        if (!fuelAvailable)
        {
            STARDialogue.text = (STARDialogue.text + "\nFuel Type is incorrect");
            STARDialogue.text = (STARDialogue.text + ". I have notified the ground crew to replace the fuel.");
        }


        UserPowerType = DataMaster.powerType;
        bool PowerAvailable = false;
        foreach (string power in PowerType)
        {
            if (power == UserPowerType)
            {
                STARDialogue.text = (STARDialogue.text + "\nPower Type is adequate");
                PowerAvailable = true;
                PilotScript.power = true;
                break;
            }
            
        }
        if (!PowerAvailable)
        {
            STARDialogue.text = (STARDialogue.text + "\nPower Type is inadequate");
            STARDialogue.text = (STARDialogue.text + ". I have notified the repair crew to replace the ship's power.");
        }
        float UserTemperature = DataMaster.temp;
        if (Temperature - 8 <= UserTemperature && UserTemperature <= Temperature + 6)
        {
            STARDialogue.text = (STARDialogue.text + "\nTemperature is acceptable");
            PilotScript.temp = true;
        }
        else
        {
            STARDialogue.text = (STARDialogue.text + "\nTemperature was not acceptable");
            STARDialogue.text = (STARDialogue.text + ". I have changed the temperature of the ship to acceptable levels.");
        }

        float UserFuelValue = DataMaster.fuelValue;
        if (UserFuelValue >= FuelValue)
        {
            STARDialogue.text = (STARDialogue.text + "\nFuel Value is adequate");
            PilotScript.fuelValue = true;
        }
        else
        {
            STARDialogue.text = (STARDialogue.text + "\nFuel Value is inadequate");
            STARDialogue.text = (STARDialogue.text + ". I have notified the ground crew to refuel the ship.");
        }
    }

    private void Recommendations()
    {
        STARDialogue.text = (STARDialogue.text + "\nBased on your input, I recommend the following changes:");
        if (UserPowerType != "Unstable Atoms")
        {
            STARDialogue.text = (STARDialogue.text + "\nI recommend switching to Unstable Atoms");
            STARDialogue.text = (STARDialogue.text + "\nUnstable Atoms are the most efficient power source and will allow you to travel the farthest distance.");
        }
        if (UserFuelType != "Hydrogen")
        {
            STARDialogue.text = (STARDialogue.text + "\nI recommend switching to Hydrogen");
            STARDialogue.text = (STARDialogue.text + "\nHydrogen has the lowest molecular weight of any known substance, making it ideal for keeping the weight of a rocket relatively small. It is also the most efficient fuel source and will allow you to travel the farthest distance.");
        }
        if (UserMaterials != "Aluminum")
        {
            STARDialogue.text = (STARDialogue.text + "\nI recommend switching to Aluminum for the body of the spacecraft");
            STARDialogue.text = (STARDialogue.text + "\nAluminium has relatively low density, which allows the spacecraft to have much lower weight while still having the same strength.");
        }
    }
}

