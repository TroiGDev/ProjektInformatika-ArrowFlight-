using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollisions : MonoBehaviour
{
    [Header("owner")]
    public GameObject owner;
    private ShootArrow shootArrow;
    public float ownerYoffset_down;
    public float ownerYoffset_up;
    public float ownerXoffset_forward;

    [Header("raycasts")]
    public float downRayLength;
    public float upRayLength;
    public float forwardRayLength;

    [Header("camera shake")]
    public CameraShake camShake;

    // Start is called before the first frame update
    void Start()
    {
        shootArrow = owner.GetComponent<ShootArrow>();
        camShake = (CameraShake)FindObjectOfType(typeof (CameraShake));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //down ray
        RaycastHit2D[] downHits = Physics2D.RaycastAll(transform.position, -Vector2.up, downRayLength);

        foreach (RaycastHit2D hit in downHits)
        {
            Collider2D hitCollider = hit.collider;

            if (hitCollider.gameObject.tag == "Solid")
            {
                shootArrow.IsTeleporting = true;
                owner.transform.position = new Vector3(hit.point.x, hit.point.y + ownerYoffset_down, owner.transform.position.z);
                shootArrow.impact_src.PlayOneShot(shootArrow.impact_sfx, 1f);
                shootArrow.Teleport_pfx.Play();
                camShake.shake = true;
                Destroy(gameObject, 0f);
            }
        }

        //up ray
        RaycastHit2D[] upHits = Physics2D.RaycastAll(transform.position, Vector2.up, upRayLength);

        foreach (RaycastHit2D hit in upHits)
        {
            Collider2D hitCollider = hit.collider;

            if (hitCollider.gameObject.tag == "Solid")
            {
                shootArrow.IsTeleporting = true;
                owner.transform.position = new Vector3(hit.point.x, hit.point.y + ownerYoffset_up, owner.transform.position.z);
                shootArrow.impact_src.PlayOneShot(shootArrow.impact_sfx, 1f);
                shootArrow.Teleport_pfx.Play();
                camShake.shake = true;
                Destroy(gameObject, 0f);
            }
        }

        //forward ray
        RaycastHit2D[] forwardHits = Physics2D.RaycastAll(transform.position, -transform.right, forwardRayLength);

        foreach (RaycastHit2D hit in forwardHits)
        {
            Collider2D hitCollider = hit.collider;

            if (hitCollider.gameObject.tag == "Solid")
            {
                shootArrow.IsTeleporting = true;
                owner.transform.position = new Vector3(hit.point.x, hit.point.y + ownerXoffset_forward, owner.transform.position.z);
                shootArrow.impact_src.PlayOneShot(shootArrow.impact_sfx, 1f);
                shootArrow.Teleport_pfx.Play();
                camShake.shake = true;
                Destroy(gameObject, 0f);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawRay(transform.position, -Vector2.up * downRayLength);
        Gizmos.DrawRay(transform.position, Vector2.up * upRayLength);
        Gizmos.DrawRay(transform.position, -transform.right * forwardRayLength);
    }
}
