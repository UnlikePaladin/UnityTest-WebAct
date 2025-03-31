using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Elementos de la interfaz
    public Text txtName;
    public Text txtPoints;

    public static User player;

    // Start is called before the first frame update
    void Start()
    {
        player = new User();
        player.username = "Default";
        player.points = 0;
        txtName.text = player.username;
        txtPoints.text = player.points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        txtName.text = player.username;
        txtPoints.text = player.points.ToString();
    }
}
