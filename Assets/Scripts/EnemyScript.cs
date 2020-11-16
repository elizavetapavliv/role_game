using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private Image health_bar;
    [SerializeField]
    private Text health_bar_text;
	public float health;
    public void Start()
    {
        health = 100;
    }
    public void Update()
    {
        health_bar.fillAmount = health / 100;
        health_bar_text.text = health.ToString()+"%";
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}