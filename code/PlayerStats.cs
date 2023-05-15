using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public int maxPlayerHealth = 100;
    public int currentPlayerHealth;
    public int level = 1;
    public int currentEXP = 0;
    public int neededEXP = 10;

    List<GameObject> weapons = new List<GameObject>();

    public TextMeshProUGUI healthTextUI;
    public TextMeshProUGUI levelTextUI;
    public TextMeshProUGUI expirienceTextUI;
    public Image healthMask;
    public Image expirienceMask;
    RectTransform hm;
    RectTransform em;

    void Start()
    {
        currentPlayerHealth = maxPlayerHealth;
        hm = healthMask.GetComponent<RectTransform>();
        em = expirienceMask.GetComponent<RectTransform>();
        healthTextUI.text = currentPlayerHealth.ToString() + "/" + maxPlayerHealth.ToString();
        hm.sizeDelta = new Vector2(172 * (currentPlayerHealth/maxPlayerHealth), 22);
        levelTextUI.text = "LEVEL" + level.ToString();
        expirienceTextUI.text = currentEXP.ToString() + "/" + neededEXP.ToString();
        em.sizeDelta = new Vector2(172 * (currentEXP/neededEXP), 22);
    }


    public void RecieveEXP(int expValue)
    {
        currentEXP += expValue;
        Debug.Log("Exp Needed: " + (neededEXP-currentEXP));
        expirienceTextUI.text = currentEXP.ToString() + "/" + neededEXP.ToString();
        em.sizeDelta = new Vector2(172 * currentEXP / neededEXP, 22);
        if (currentEXP < neededEXP) return;
        RecieveLevel();
    }

    void RecieveLevel()
    {
        level +=1;
        currentEXP = currentEXP - neededEXP;
        neededEXP *= 2;
        levelTextUI.text = "LEVEL" + level.ToString();
        expirienceTextUI.text = currentEXP.ToString() + "/" + neededEXP.ToString();
        em.sizeDelta = new Vector2(172 * (currentEXP/neededEXP), 22);
        Debug.Log("I hace just recieved a level!");
    }
}
