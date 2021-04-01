using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Light playerLight;
    public float lightLoweringAmount;

    private void FixedUpdate()
    {
        // Lowers the player's light range over time
        if (playerLight.range > 0)
        {
            StartCoroutine(LowerLightOverTime());
        }
    }
    // Lower the player's light range over time
    public IEnumerator LowerLightOverTime()
    {
        yield return new WaitForSeconds(1f);
        playerLight.range -= lightLoweringAmount * Time.deltaTime;

    }
    // fuction that will increase the player's light range on pick up
    public IEnumerator RewardPlayerWithLight(int lightValue)
    {
        for(int i = 0; i < lightValue; i++)
        {
            yield return new WaitForSeconds(0.05f);
            playerLight.range++;
        }
    }
}
