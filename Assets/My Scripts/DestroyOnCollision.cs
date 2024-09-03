using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class DestroyOnCollision : MonoBehaviour
{
    public Image HealthBar;
    public Image ShieldBar;
    public TextMeshProUGUI TeleporterCount;
    public TextMeshProUGUI ScoreHolder;

    private float healthAmount = 100.0f;
    private float shieldAmount = 0.0f;

    private int ScoreAmount;

    public GameManager game_Manager;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthBar.fillAmount <= 0 && !isDead)
        {
            isDead = true;
            game_Manager.GameOver(int.Parse(ScoreHolder.text));
            Debug.Log("GAME OVER!");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boulder")
        {
            ShielDamage(10f);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Vehicle")
        {
            ShielDamage(20f);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Zombie")
        {
            TakeDamage(1.0f);
            SetScore(10);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "ZombieBig")
        {
            TakeDamage(5.0f);
            SetScore(20);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "PowUp_HP")
        {
            Heal(15.0f);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "PowUp_Shield")
        {
            SetShieldStrength(50f);
            Destroy(other.gameObject); //max shile strenght is 100
        }
        if (other.gameObject.tag == "PowUp_Teleporter")
        {
            TPCounter();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Blockade")
        {
            TakeDamage(15.0f);
        }
    }

    private void TakeDamage(float amount)
    {
        healthAmount -= amount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        HealthBar.fillAmount = healthAmount / 100f;
        
    }

    private void ShielDamage(float amount)
    {
        shieldAmount = ShieldBar.fillAmount * 100;
        if (shieldAmount >= 50)
        {
            shieldAmount -= 50;
            shieldAmount = Mathf.Clamp(shieldAmount, 0, 100);

            ShieldBar.fillAmount = shieldAmount / 100f;
        }
        else
        {
            TakeDamage(amount);
        }
    }
    private void SetScore(int amount)
    {
        ScoreAmount = int.Parse(ScoreHolder.text);
        ScoreAmount += amount;

        ScoreHolder.text = ScoreAmount.ToString();
    }
    private void SetShieldStrength(float amount)
    {
        shieldAmount += amount;
        shieldAmount = Mathf.Clamp(shieldAmount, 0, 100);

        ShieldBar.fillAmount = shieldAmount / 100f;
    }
    
    private void Heal(float amount)
    {
        healthAmount += amount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        HealthBar.fillAmount = healthAmount / 100f;
    }

    private void TPCounter()
    {
        int count = int.Parse(TeleporterCount.text);
        if (count >= 0  && count <5 )
        {
            ++count;
            TeleporterCount.text = count.ToString();
        }
    }
}
