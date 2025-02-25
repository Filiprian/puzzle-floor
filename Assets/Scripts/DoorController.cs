using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public List<GameObject> buttonDoors;
     public List<GameObject> switchDoors;

    public void ButtonOpen()
    {
        foreach (var door in buttonDoors)
        {
            door.GetComponent<ButtonLogics>().AlwaysOpen();
        }
    }

     public void DoorOpen()
     {
        foreach (var door in switchDoors)
        {
            door.GetComponent<SwitchLogics>().Open();
        }
     }

     public void DoorClose()
     {
        foreach (var door in switchDoors)
        {
            door.GetComponent<SwitchLogics>().Close();
        }
     }
}