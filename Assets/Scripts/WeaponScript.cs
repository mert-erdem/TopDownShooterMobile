using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet, muzzle, canvas;
    private int ammo = 50;
    private CanvasController canvasController;

    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("ui");
        canvasController = canvas.GetComponent<CanvasController>();
    }

    public void Fire()
    {
        if(ammo!=0)
        {
            Instantiate(bullet, muzzle.transform.position, Quaternion.identity);
            ammo--;
            canvasController.AmmoChanged(ammo);
        }        
    }

    public void MaxAmmo()
    {
        this.ammo = 50;
        canvasController.AmmoChanged(ammo);
    }
}
