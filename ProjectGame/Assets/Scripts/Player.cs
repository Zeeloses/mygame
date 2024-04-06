using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    private int camPosX;
    private int camPosY;
    public Camera Camera;
    public TMP_Text Keys;
    public TMP_Text RoomsPassed;


    public float speed = 5.0f;

    public int keys = 0;
    public float knockbackForce;
    public GameObject explosionPrefab;
    private KeySystem keySystem;

    // Start is called before the first frame update
    void Start()
    {
        keySystem = this.GetComponent<KeySystem>();
        keySystem.random(5);
        Keys.text = "Keys: " + keys.ToString() + "/" + keySystem.keyNum;
        RoomsPassed.text = "Room(s): " + DoorSystem.Rooms.ToString();
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow) | Input.GetKey(KeyCode.A))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            transform.eulerAngles = Vector3.forward * 180;
        }
        if (Input.GetKey(KeyCode.RightArrow) | Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            transform.eulerAngles = Vector3.forward * 0;
        }
        if (Input.GetKey(KeyCode.UpArrow) | Input.GetKey(KeyCode.W))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            transform.eulerAngles = Vector3.forward * 90;
        }
        if (Input.GetKey(KeyCode.DownArrow) | Input.GetKey(KeyCode.S))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            transform.eulerAngles = Vector3.forward * -90;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            Vector2 difference = (transform.position - collision.gameObject.transform.position).normalized;
            Vector2 force = difference * 100;
            this.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);

            void Awake()
            {
                // Load the explosion Prefab here
                explosionPrefab = Resources.Load<GameObject>("ExploPar");
            }
            GameObject explosion = Instantiate(explosionPrefab);
            explosion.transform.position = collision.gameObject.transform.position;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Door" && keys == keySystem.keyNum)
        {
           
            DoorSystem.Rooms++;
            RoomsPassed.text = "Rooms" + DoorSystem.Rooms.ToString();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        if (collision.gameObject.tag == "Key")
        {
            keys++;
            Keys.text = "Keys: " + keys.ToString() + "/" + keySystem.keyNum;
            Destroy(collision.gameObject);
        }
        /*    private void FixedUpdate()
            {
                if (transform.position.x - camPosX > 5)
                {
                    camPosX += 10;
                    Camera.transform.position = new Vector3(camPosX, camPosY, -5);
                }
                if (camPosX - transform.position.x > 10)
                {
                    camPosX -= 10;
                    Camera.transform.position = new Vector3(camPosX, camPosY, -5);
                }
                if (transform.position.y - camPosY > 5)
                {
                    camPosY += 10;
                    Camera.transform.position = new Vector3(camPosX, camPosY, -5);
                }
                if (camPosY - transform.position.y > 5)
                {
                    camPosY -= 10;
                    Camera.transform.position = new Vector3(camPosX, camPosY, -5);
                }
            }*/
    }
}
