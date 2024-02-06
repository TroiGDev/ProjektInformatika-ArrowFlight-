using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public bool isMobile;

    [Header("pc/mb common")]
    public GameObject Bullet;
    public float launchForce;
    public Vector2 angleOffset; //randomnes to angle
    public float launchOffset;  //randomnes to velocity
    public Transform gunPos;
    private float currCooldown;

    public Camera personalCamera;
    private CameraShake camShake;

    [Header("pc")]
    public float coolDown;

    [Header("mobile")]
    public Joystick firingJs;
    public Rigidbody2D rb;

    public float mbCoolDown;


    [Header("ammo & reload")]
    private HealthManager hltMngr;

    public float reloadTime;
    private float currAmmo;

    // Start is called before the first frame update
    void Start()
    {
        if (Application.isMobilePlatform)
        {isMobile = true;}else{isMobile = false;}

        camShake = personalCamera.GetComponent<CameraShake>();

        if (hltMngr == null)
        {hltMngr = (HealthManager)FindObjectOfType(typeof (HealthManager));}
    }

    // Update is called once per frame
    void Update()
    {
        currAmmo = hltMngr.ammo;

        if (currAmmo >= 1)
        {
            if (!isMobile)
            {
                Vector2 gunPos = transform.position;
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 Direction = mousePos - gunPos + new Vector2(Random.Range(-angleOffset.x, angleOffset.x), Random.Range(-angleOffset.y, angleOffset.y));
                transform.right = Direction;

                currCooldown += 1 * Time.deltaTime;

                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                {
                    if (currCooldown > coolDown)
                    {
                        Shoot();
                        camShake.shake = true;
                        currCooldown = 0;
                    }
                }
            }

            if (isMobile)
            {
                currCooldown += 1 * Time.deltaTime;

                if (firingJs.Direction.y != 0)
                {
                    if (currCooldown > mbCoolDown)
                    {
                        Shoot();
                        
                        camShake.shake = true;
                        currCooldown = 0;
                    }
                }
            }
        }
        else
        {
            hltMngr.Reload(reloadTime);
        }
    } 

    void Shoot()
    {
        hltMngr.ammo -= 1;

        GameObject bullet = Instantiate(Bullet, gunPos.position, gunPos.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
    }
}
