using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resta : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        UIManager.player.points -= 1;
    }
}
