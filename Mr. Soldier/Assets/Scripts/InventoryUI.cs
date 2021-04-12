using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [Header("Components")]
    //Reference to our Inventory.
    public Transform itemsParent;
    public GameObject inventoryUI;
    public GameController gameController;
    public bool isInventory = false;
    Inventory inventory;
    InventorySlot[] slots;
    public PlayerBehavior player;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        player = FindObjectOfType<PlayerBehavior>();
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        //If user presses b or i, open inventory. (WebGL/Desktop)
        //if (Input.GetButtonDown("Inventory"))
        //{
        //    OpenInventory();
        //}

        //if you opened inventory, stop time and make cursor visible, else, go back to the game.
        //if (isInventory)
        //{
        //    Time.timeScale = 0.0f;
        //    Cursor.lockState = CursorLockMode.None;
        //}
        //else
        //{
        //    Time.timeScale = 1.0f;
        //    Cursor.lockState = CursorLockMode.Locked;
        //}
    }
    void UpdateUI()
    {
        //Add items or remove them, run a for loop to check which slots are filled or not.
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
    void OpenInventory()
    {
        isInventory = !isInventory;
        inventoryUI.SetActive(!inventoryUI.activeSelf);
        if (player.quest.isActive)
        {
            player.quest.goal.inventoryButtonPressed = true;
            player.quest.goal.InventoryDone();
        }
    }
    public void InventoryButton()
    {
        OpenInventory();
    }
}
