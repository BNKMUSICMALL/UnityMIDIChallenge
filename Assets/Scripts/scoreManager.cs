using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public static scoreManager Instance;
    public AudioSource hitSFX;

    private Text scoreDisplay;
    private Text comboDisplay;

    int combo;
   
    public static int scoreTotal;

    // Start is called before the first frame update
    void Start()
    {
        scoreTotal = 0;
        Instance = this;
        comboDisplay = GameObject.Find("combo_display").GetComponent<Text>();
        scoreDisplay = GameObject.Find("score_display").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(combo > 0)
        {
            comboDisplay.enabled = true;
            comboDisplay.text = $"x {combo}";
            comboDisplay.fontSize = (int)Mathf.Clamp((float)comboDisplay.fontSize, 14, 20);
        }
        else
        {
            comboDisplay.enabled = false;
        }

        scoreDisplay.text = scoreTotal.ToString();
    }

    public static void Hit(int score)
    {
        Instance.combo += 1;
        Instance.hitSFX.Play();
        scoreTotal += score;
    }

    public static void Miss()
    {
        Instance.combo = 0;
    }

}
