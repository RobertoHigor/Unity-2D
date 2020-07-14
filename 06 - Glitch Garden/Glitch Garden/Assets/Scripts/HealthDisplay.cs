using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] int lives = 10;
    [SerializeField] int damage = 1;
    Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<Text>();
        UpdateDisplay();
    }

    // Update is called once per frame
    private void UpdateDisplay()
    {
      healthText.text = lives.ToString();  
    }

    public void TakeLife()
    {
        lives -= damage;
        UpdateDisplay();

        if (lives <= 0)
        {
            FindObjectOfType<SceneLoader>().LoadGameOver();
        }
    }
}
