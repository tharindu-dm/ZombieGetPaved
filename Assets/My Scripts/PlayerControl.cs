using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class PlayerControl : MonoBehaviour
{
    public float HorizontalInput;
    public float VerticalInput;
    public float speed = 10f; 

    public TextMeshProUGUI TeleporterCount;

    private float RangeXofPlayer = 20.0f;
    private float RangeZofPlayer = 17.0f;

    public Camera Cam1;
    public Camera Cam2;
    public Camera Cam3;

    public Light headlightLeft;
    public Light headlightRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(RangeXofPlayer < transform.position.x)
        {
            transform.position = new Vector3(RangeXofPlayer, transform.position.y, transform.position.z);
        }
        if (-RangeXofPlayer > transform.position.x)
        {
            transform.position = new Vector3(-RangeXofPlayer, transform.position.y, transform.position.z);
        }
        if (RangeZofPlayer < transform.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, RangeZofPlayer);
        }
        if (0 > transform.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * HorizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * VerticalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Teleport();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            Cam1.enabled = true; //top view
            Cam2.enabled = false;
            Cam3.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Cam1.enabled = false;
            Cam2.enabled = true; //Third Person
            Cam3.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Cam1.enabled = false;
            Cam2.enabled = false;
            Cam3.enabled = true; //first person
        }


        if (Input.GetKeyDown(KeyCode.F))
        {
            headlightLeft.enabled = !headlightLeft.enabled;
            headlightRight.enabled = !headlightRight.enabled;
        }
    }

    private void Teleport()
    {
        int count = int.Parse(TeleporterCount.text);
        if (count != 0)
        {
            --count;
            TeleporterCount.text = count.ToString();
            
            Vector3 position = transform.position;
            transform.position = new Vector3(-position.x, position.y, position.z);
        }
    }
}
