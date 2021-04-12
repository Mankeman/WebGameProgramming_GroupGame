using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public Types goalType;
    public QuestGiver questGiver;

    [Header("Kill/Gathering Type")]
    public int requiredAmount;
    public int currentAmount;

    [Header("Movement Type")]
    public bool leftJoystickMoved;
    public bool rightJoystickMoved;

    [Header("Button Type")]
    public bool jumpButtonPressed;
    public bool shootButtonPressed;
    public bool inventoryButtonPressed;
    public bool miniMapButtonPressed;

    public void MovementDone()
    {
        if(leftJoystickMoved && rightJoystickMoved)
        {
            questGiver.Quest1Done();
        }
    }
    public void JumpDone()
    {
        questGiver.Quest2Done();
    }
    public void MiniMapDone()
    {
        questGiver.Quest3Done();
    }
    public void InventoryDone()
    {
        questGiver.Quest4Done();
    }
    public void HealingDone()
    {
        questGiver.Quest5Done();
    }
    public void KillingDone()
    {
        questGiver.Quest6Done();
    }
}

public enum Types
{
    Movement,
    Button,
    Kill,
    Gathering
}
