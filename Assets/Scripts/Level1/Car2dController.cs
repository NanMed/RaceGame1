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
    public static int coins = 0;
    public static int counter1 = 0;

    public float resetDelay = 1f;

    public static int lap;

    private AudioSource lineSound;
    public static bool first = false;
    private bool sec;

    // Use this for initialization
    void Start()
    {
        ManageTextP1.instance.win.SetActive(false);
        lap = -1;
        lineSound = GetComponent<AudioSource>();
        first = false;

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
            Destroy(other.gameObject);
            RunForTime(2f, () => speedForce += 7 * Time.deltaTime);
            Debug.Log("collide tanque");
        }

        if (other.gameObject.tag == "Moneda")
        {
            Destroy(other.gameObject);
            coins += 1;
            ManageTextP1.instance.coinText.text = "Coins: " + coins;
            PlayerPrefs.SetInt("coins1", coins);
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
            counter1 += 1;
            PlayerPrefs.SetInt("counter1", counter1);
            ManageTextP1.instance.win.SetActive(true);
            ManageTextP1.instance.NextLevel.gameObject.SetActive(true);
            //Time.timeScale = .25f;
            //Invoke("Reset", resetDelay);
        } else
        {
            ManageTextP1.instance.win.SetActive(false);
            ManageTextP1.instance.NextLevel.gameObject.SetActive(false);
        }
        if (!first && sec)
        {
            ManageTextP1.instance.lose.SetActive(true);
            //Time.timeScale = .25f;
            //Invoke("Reset", resetDelay);
        }
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
