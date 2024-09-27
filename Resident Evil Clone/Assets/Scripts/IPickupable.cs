using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickupable : MonoBehaviour
{
    public void Pickup(PlayerController player);
}