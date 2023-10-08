using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotScript : MonoBehaviour
{
    static public bool rad, bat, air, heat, pres, temp, fuelValue, fuelType, comms, mats, power;
    static public bool SafeToFly;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rad && bat && air && heat && pres && temp && fuelValue && fuelType && comms && mats && power)
        {
            SafeToFly = true;
        }
        else
        {
            SafeToFly = false;
        }
    }
    public void ChangeState(int State)
    {
        switch(State)
        {
            case 1:
                rad = true;
                break;
            case 2:
                bat = true;
                break;
            case 3:
                air = true;
                break;
            case 4:
                heat = true;
                break;
            case 5:
                pres = true;
                break;
            case 6:
                temp = true;
                break;
            case 7:
                fuelValue = true;
                break;
            case 8:
                fuelType = true;
                break;
            case 9:
                comms = true;
                break;
            case 10:
                mats = true;
                break;
            case 11:
                power = true;
                break;

        }
    }
}
