using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Car2dController : MonoBehaviour
{
    float speedForce = 30f;
    float torqueForce = -200f;
    float driftFactorSticky = 0.9f;
    float driftFactorSlippy = 1;
    float maxStickyVelocity = 2.5f;

	public float resetDelay = 1f;

	int lap;
	int lives;

	public Text lapText;
	public Text livesText;
	public GameObject gameover;
	public GameObject win;

   
    // Use this for initialization
    void Start()
    {
		lap = 0;
		lives = 3;
    }
    void Update(){
		
	}

    

    // Update is called once per frame
    void FixedUpdate()
    {
       
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        //Debug.Log(RightVelocity().magnitude);

        float driftFactor = driftFactorSticky;
        if(RightVelocity().magnitude > maxStickyVelocity){
            driftFactor = driftFactorSlippy;
        }




        rb.velocity = ForwardVelocity() + RightVelocity()*driftFactor;

        if (Input.GetButton("Accelerate")){
        	rb.AddForce(transform.up * speedForce);

        }

        if(Input.GetButton("Brakes")){
            rb.AddForce(transform.up * -speedForce / 2f);
        }


        float tf = Mathf.Lerp(0, torqueForce, rb.velocity.magnitude/2);

        rb.angularVelocity = Input.GetAxis("Horizontal") * tf;
    }

    Vector2 ForwardVelocity(){
        return transform.up * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.up);

    }

    Vector2 RightVelocity()
    {
        return transform.right * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.right);

    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Oil")
		{
			speedForce = 4f;
		}
		if(other.gameObject.tag == "FinishLine"){
			lap +=1;
			lapText.text = "Laps: " + lap;
		}
		if(other.gameObject.tag == "Water"){
			lives -=1;
			livesText.text = "Lives: " + lives;
		}
		CheckGameOver();
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Oil")
		{
			speedForce = 30f;
		}
	}

	void CheckGameOver(){
		if(lap == 3){
			win.SetActive(true);
			Time.timeScale = .25f;
			Invoke("Reset", resetDelay);
			Destroy(gameObject);
		}
		if(lives < 1){
			gameover.SetActive(true);
			Time.timeScale = .25f;
			Invoke("Reset", resetDelay);
			Destroy(gameObject);
		}
	}
		
}
