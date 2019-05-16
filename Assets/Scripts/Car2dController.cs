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
    public int coins = 0;

    public float resetDelay = 1f;

    int lap;
    int lives;

    public Text lapText;
    public Text coinText;
    public GameObject win;
    public GameObject nextLevel;
    public GameObject exit;
    public GameObject lose;
    private AudioSource lineSound;
    public static bool first = false;
    private bool sec;

    private void Awake()
    {
        //lapText = GetComponent<Text>();
        //livesText = GetComponent<Text>();
        //coinText = GetComponent<Text>();
        //win = GetComponent<GameObject>();
        //nextLevel = GetComponent<GameObject>();
        //exit = GetComponent<GameObject>();
        //lose = GetComponent<GameObject>();
    }
    // Use this for initialization
    void Start()
    {
        lap = -1;
        lives = 3;
        lineSound = GetComponent<AudioSource>();

    }
    void Update()
    {
        //Debug.Log(speedForce);
        sec = CarControllerPlayer2.first;
    }



    // Update is called once per frame
    void FixedUpdate()
    {

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        //Debug.Log(RightVelocity().magnitude);

        float driftFactor = driftFactorSticky;
        if (RightVelocity().magnitude > maxStickyVelocity)
        {
            driftFactor = driftFactorSlippy;
        }




        rb.velocity = ForwardVelocity() + RightVelocity() * driftFactor;

        if (Input.GetButton("Accelerate"))
        {
            rb.AddForce(transform.up * speedForce);

        }

        if (Input.GetButton("Brakes"))
        {
            rb.AddForce(transform.up * -speedForce / 2f);
        }


        float tf = Mathf.Lerp(0, torqueForce, rb.velocity.magnitude / 2);

        rb.angularVelocity = Input.GetAxis("Horizontal") * tf;
    }

    Vector2 ForwardVelocity()
    {
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
            Debug.Log("collide Oil");
        }
        if (other.gameObject.tag == "FinishLine")
        {
            lap += 1;
            ManageTextP1.instance.lapText.text = "Laps: " + lap;
            lineSound.Play();
        }
        
        if (other.gameObject.tag == "Tanque")
        {
            //speedForce = Mathf.Floor(Time.time * 2) + 30;
            //speedForce = 40f;
            Destroy(other.gameObject);
            RunForTime(2f, () => speedForce += 7 * Time.deltaTime);
            Debug.Log("collide tanque");
        }

        if (other.gameObject.tag == "Moneda")
        {
            Destroy(other.gameObject);
            coins += 1;
            ManageTextP1.instance.coinText.text = "Coins: " + coins;
            Debug.Log("collide moneda");
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

    void CheckGameOver()
    {
        if (lap == 3)
        {
            first = true;
            //win.SetActive(true);
            //Time.timeScale = .25f;
            //Invoke("Reset", resetDelay);
            //Destroy(gameObject);
        }

        if (first && !sec)
        {
            ManageTextP1.instance.win.SetActive(true);
            ManageTextP1.instance.nextLevel.interactable = true;
            ManageTextP1.instance.exit.interactable = true;
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }
        else if (!first && sec)
        {
            ManageTextP1.instance.lose.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }
        /*if (lives < 1)
        {
            gameover.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
            //Destroy(gameObject);
        }*/
    }

    //https://answers.unity.com/questions/1222208/add-x-amount-in-x-seconds.html
    IEnumerator _RunForTime(float aDuration, System.Action aCallback)
    {
        float t = 0f;
        while (t < aDuration)
        {
            t += Time.deltaTime;
            aCallback();
            yield return null;
        }
    }
    public void RunForTime(float aDuration, System.Action aCallback)
    {
        StartCoroutine(_RunForTime(aDuration, aCallback));
    }
}
