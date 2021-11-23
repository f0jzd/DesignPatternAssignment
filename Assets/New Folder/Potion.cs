using System;
using UnityEngine;

public class Potion : MonoBehaviour
{
    
    [Range(0,20)]
    private int healthToAdd;

    private void AddHealth()
    {
        //player.instance += healthToAdd;
        Player.Instance.playerHealth+=healthToAdd;

        //PlayerProfile.Instance.playerHealth += healthToAdd;
    }
    /*private void OnGUI()
    {
        GUI.TextArea(new Rect(10, 20, 100, 50), PlayerProfile.Instance.playerHealth.ToString());
        if (GUI.Button(new Rect(10, 70, 50, 100),"Add Health"))
        {
            AddHealth();
        }
    }*/


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Heal player");
            AddHealth();
        }
    }

}
