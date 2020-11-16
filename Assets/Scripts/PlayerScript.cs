using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public static MagicCharacter player;
    private Rigidbody2D player_rigid;
    public float Speed { get; set; }
    public float High { get; set; }
    private bool FacingRight { get; set; }
    private bool grounded = false;
    public Transform ground_check = null;
    public float ground_radius = 0.2f;
    public LayerMask what_is_ground;
    private bool game_over = false;
    [SerializeField]
    private GameObject game_over_menu;
    [SerializeField]
    private GameObject win_menu;
    [SerializeField]
    private GameObject info_bar;
    [SerializeField]
    private Text level;
    public Transform Target { get; set; }
    public void Start()
    {
        int index = PlayerPrefs.GetInt("Character selected");
        player = new MagicCharacter(InputDataScript.user_name, transform.GetChild(index).gameObject.name, InputDataScript.gender, InputDataScript.user_age);
        player_rigid = GetComponent<Rigidbody2D>();
        Speed = 10f;
        High = 800f;
        FacingRight = true;
    }
    public void Update()
    {
        Text t = info_bar.GetComponentInChildren<Text>();
        t.text = player.ToString();
        GameObject g_o = GameObject.FindWithTag("Player");
        if (player.Health<=0 || (g_o.transform.position.y <= 140))
        {
            gameObject.SetActive(false);
            GameOver();
        }
        if (g_o.transform.position.x >= 465)
        {
            level.text = "Level 2";
        }
        if (g_o.transform.position.x >= 553)
        {
            win_menu.SetActive(true);
        }
        grounded = Physics2D.OverlapCircle(ground_check.transform.position, ground_radius, what_is_ground);
        float move = Input.GetAxis("Horizontal");
        player_rigid.velocity = new Vector2(move * Speed, player_rigid.velocity.y);
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            player_rigid.AddForce(new Vector2(0, High));
        }
        if (move < 0 && FacingRight)
        {
            Flip();
        }
        else if (move > 0 && !FacingRight)
        {
            Flip();
        }
		if (Input.GetKeyDown (KeyCode.B)) 
		{
			InventoryScript.MyInstance.OpenClose ();
		}			
    }
    public void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    public void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag=="Enemy")
        {
            player.Health -= 10;
            
            if (FacingRight)
            {
                player_rigid.position = new Vector2(player_rigid.position.x - 10, player_rigid.position.y);
            }
            else
            {
                player_rigid.position = new Vector2(player_rigid.position.x + 5, player_rigid.position.y);
            }
        }
	}

	[SerializeField]
	public ItemScript[] items;
    private void OnTriggerEnter2D(Collider2D collision)
    {
		if(collision.GetComponent<PolygonCollider2D>().name=="Eye1" || collision.GetComponent<PolygonCollider2D>().name=="Eye2")
        {
            Destroy(collision.gameObject);
            player.Experience += 10;
			AEye a = (AEye)Instantiate(items[3]);
			InventoryScript.AddItem (a);
        }
		if(collision.GetComponent<PolygonCollider2D>().name=="Stick1" || collision.GetComponent<PolygonCollider2D>().name=="Stick2" || collision.GetComponent<PolygonCollider2D>().name == "Stick3")
		{
			Destroy(collision.gameObject);
			player.Experience += 20;
			AStick a = (AStick)Instantiate(items[5]);
			InventoryScript.AddItem (a);
		}
		if(collision.GetComponent<PolygonCollider2D>().name=="Hbottle")
		{
			Destroy(collision.gameObject);
			player.Experience += 10;
			ABottle a = (ABottle)Instantiate(items[0]);
			InventoryScript.AddItem (a);
		}
		if(collision.GetComponent<PolygonCollider2D>().name=="Saliva"|| collision.GetComponent<PolygonCollider2D>().name == "Saliva2")
		{
			Destroy(collision.gameObject);
			player.Experience += 10;
			ASaliva a = (ASaliva)Instantiate(items[4]);
			InventoryScript.AddItem (a);
		}
		if(collision.GetComponent<PolygonCollider2D>().name=="Decoction1" || collision.GetComponent<PolygonCollider2D>().name=="Decoction2")
		{
			Destroy(collision.gameObject);
			player.Experience += 10;
			ADecoction a = (ADecoction)Instantiate(items[2]);
			InventoryScript.AddItem (a);
		}
		if(collision.GetComponent<PolygonCollider2D>().name=="Dbottle1" || collision.GetComponent<PolygonCollider2D>().name=="Dbottle2")
		{
			Destroy(collision.gameObject);
			player.Experience += 10;
			ABottleD a = (ABottleD)Instantiate(items[1]);
			InventoryScript.AddItem (a);
		}

    }
    public void GameOver()
    {
        if(!game_over)
        {
            game_over = true;
            game_over_menu.SetActive(true);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PrintInfo()
    {
        if (info_bar.activeSelf)
        {
            info_bar.SetActive(false);
        }
        else
        {
            info_bar.SetActive(true);
        }
    }
    [SerializeField]
	private GameObject[] spellPrefab;
	private IEnumerator Attack(){
		yield return new WaitForSeconds (1);
		if (Target != null) {
			SpellEffects s = Instantiate (spellPrefab [0], transform.position, Quaternion.identity).GetComponent<SpellEffects> ();
			s.MyTarget = Target;
		}
	}
	public void CastSpell(){
		if (Target != null) {
			StartCoroutine (Attack ());
		}
	}
}