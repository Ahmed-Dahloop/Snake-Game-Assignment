using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private bool isGameOver = false;
    public AudioClip eatCoinSound; 
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (isGameOver) return;
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveZ);
        transform.Translate(move * speed * Time.deltaTime, Space.World);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            isGameOver = true; 
            GameManager.instance.GameOver(); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("coin"))
        {
            Destroy(other.gameObject); 
            GameManager.instance.IncrementScore();
            audioSource.PlayOneShot(eatCoinSound); 
            Vector3 newScale = transform.localScale;
            newScale.y += 0.2f;
            transform.localScale = newScale;
        }
    }
}
