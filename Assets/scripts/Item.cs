using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public bool isPickedUp = false;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
    }
///
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInteraction playerInteraction = other.GetComponent<PlayerInteraction>();
            if (playerInteraction != null)
            {
                playerInteraction.PickUpItem(this);
            }
        }
    }

    public void PickUp()
    {
        isPickedUp = true;
        rb.isKinematic = true; // Disable physics while picked up
    }

    public void PutDown()
    {
        isPickedUp = false;
        rb.isKinematic = false; // Enable physics when put down
    }
}
