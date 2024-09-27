using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected int ammoCapacity;
    [SerializeField] protected int currentLoadedAmmo;
    [SerializeField] protected int currentSpareAmmo;
    [SerializeField] protected bool canFire;
    [SerializeField] protected Transform firePoint;

    [SerializeField] protected Magazine magazine;

    [SerializeField] public Enums.MagazineType magazineType;
    private GameObject ammoText;

    // Start is called before the first frame update
    void Start()
    {
        ammoText = GameObject.FindWithTag("AmmoText");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void Reload(Magazine newMag)
    {
        if(magazine != null)
        {
            magazine = newMag;
        }
    }

    public virtual int CheckAmmo()
    {
        if(magazine != null)
        {
            return magazine.GetRounds();
        }
    }

    public virtual void Fire()
    {
        if(magazine != null)
        {
            if(magazine.GetRounds() > 0)
            {
                magazine.RemoveRound();
                ammoText.GetComponent<TextMeshProUGUI>().text = "Ammo " + currentWeapon.CheckAmmo();
                RaycastHit hit;
                if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, 500))
                {
                    Debug.DrawRay(firePoint.position, firePoint.forward * hit.distance, Color.red, 2f);
                    if(hit.transform.CompareTag("Zombie"))
                    {
                        hit.transform.GetComponent<Enemy>().TakeDamage(1);
                    }
                }
            }
        } 
    }
}
