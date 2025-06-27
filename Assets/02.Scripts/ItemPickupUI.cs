using UnityEngine;

public class ItemPickupUI : MonoBehaviour
{
    public GameObject itemUI;
    public GameObject itemObject;
    private bool isHolding = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isHolding && other.CompareTag("Item"))
        {
            itemUI.SetActive(true);
        }
    }

    void PickUpItem(GameObject item)
    {
        itemObject = item;
        itemObject.SetActive(false);
        isHolding = true;
        itemUI.SetActive(true);
    }

    void DropItem()
    {
        if (itemObject != null)
        {
            itemObject.transform.position = transform.position + transform.forward * 1f;
            itemObject.SetActive(true);
            itemObject = null;
        }

        isHolding = false;
        itemUI.SetActive(false);
    }
}
