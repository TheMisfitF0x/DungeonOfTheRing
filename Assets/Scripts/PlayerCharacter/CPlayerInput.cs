using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerInput : MonoBehaviour
{
    Vector2 movementDir;
    Vector2 mousePos;

    private DCharacterController cc;
    public Collider2D interactionRadius;
    private Camera cam;

    private void Start()
    {
        cc = this.GetComponent<DCharacterController>();
        cam = GameObject.Find("Camera").GetComponent<Camera>();
        print("I'm alive");
    }
    // Update is called once per frame
    void Update()
    {
        //Input
        movementDir.x = Input.GetAxis("Horizontal");
        movementDir.y = Input.GetAxis("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        
        cc.ExecuteCommand(new MoveCommand(movementDir, mousePos)); //Maybe redo this so it isn't sending a command every frame? idk. Stuff's fast anyhow.

        if (cc.myWeapon != null)
        {
            if (cc.myWeapon.canHoldTrigger)//If the weapon has an autoTrigger,
            {
                if (Input.GetButton("Fire1")) cc.ExecuteCommand(new ShootCommand(false)); //Issue a shoot command every frame the fire button is held.
            }
            else
            {
                if (Input.GetButtonDown("Fire1")) cc.ExecuteCommand(new ShootCommand(false)); //Otherwise, only listen for trigger down, so the trigger must be reset before firing again.
            }
        }

        if (Input.GetButtonDown("Fire2")) cc.ExecuteCommand(new ShootCommand(true));

        if (Input.GetButtonDown("Interact"))
        {
            Collider2D[] overlappingColliders = new Collider2D[10];
            interactionRadius.OverlapCollider(new ContactFilter2D().NoFilter(), overlappingColliders);

            foreach(Collider2D collider in overlappingColliders)
            {
                if (collider != null && collider != interactionRadius)
                {
                    if(collider.CompareTag("Weapon"))
                    {
                        cc.ExecuteCommand(new InteractCommand(collider.gameObject.GetComponent<DWeapon>()));
                    }
                }
            }
        }
    }
}
