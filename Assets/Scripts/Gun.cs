using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    private Animator animator;
    private PlayerInput playerInput;

    [Header("Shooting")]
    public int maxAmmo;
    public int shotPerSecond;
    public float reloadSpeed;

    private bool isReloading;
    private bool isShooting;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && !isShooting && !isReloading)
        {
            isShooting = true;
            StartCoroutine(Shoot());
        }
        else
        {
            animator.SetBool("Usp1", false);
            isShooting = false;
        }

    }

    IEnumerator Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Debug.Log(hit.point);

            animator.SetBool("Usp1", true);

            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void StartReload()
    {
        animator.SetBool("Reload", true);
        Invoke("StopReload", 2f);
        isReloading= true;
        Debug.Log("reload");
    }

    public void StopReload()
    {
        Debug.Log("stop reload!");
        animator.SetBool("Reload", false);
        isReloading= false;
    }
}
