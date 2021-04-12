using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public PlayerBehavior player;
    public GameObject panel;
    public TextMeshProUGUI tutorial1;
    public TextMeshProUGUI tutorial2;
    public TextMeshProUGUI tutorial3;
    public TextMeshProUGUI tutorial4;
    public TextMeshProUGUI tutorial5;
    public TextMeshProUGUI tutorial6;
    public Button jumpBtn;
    public Button invBtn;
    public Button miniMapBtn;
    public Button shootBtn;

    public string number1 = "Move Both Joysticks";
    public string number2 = "Jump Button";
    public string number3 = "Minimap Button";
    public string number4 = "Inventory Button";
    public string number5 = "Use Health Pack";
    public string number6 = "Kill the Enemy";

    public void Start()
    {
        tutorial1.text = number1;
        tutorial2.text = number2;
        tutorial3.text = number3;
        tutorial4.text = number4;
        tutorial5.text = number5;
        tutorial6.text = number6;
    }
    public void Quest1()
    {
        panel.SetActive(false);
        tutorial1.text = number1;
        quest.isActive = true;
        player.quest = quest;
    }
    public void Quest1Done()
    {
        tutorial1.fontStyle = FontStyles.Strikethrough;
        jumpBtn.gameObject.SetActive(true);
    }
    public void Quest2()
    {
        tutorial2.text = number2;
        player.quest = quest;
    }
    public void Quest2Done()
    {
        tutorial2.fontStyle = FontStyles.Strikethrough;
        miniMapBtn.gameObject.SetActive(true);
    }
    public void Quest3()
    {
        tutorial3.text = number3;
        player.quest = quest;
    }
    public void Quest3Done()
    {
        tutorial3.fontStyle = FontStyles.Strikethrough;
        invBtn.gameObject.SetActive(true);
    }
    public void Quest4()
    {
        tutorial4.text = number4;
        player.quest = quest;
    }
    public void Quest4Done()
    {
        tutorial4.fontStyle = FontStyles.Strikethrough;
    }
    public void Quest5()
    {
        tutorial5.text = number5;
        player.quest = quest;
    }
    public void Quest5Done()
    {
        tutorial5.fontStyle = FontStyles.Strikethrough;
        shootBtn.gameObject.SetActive(true);
    }
    public void Quest6()
    {
        tutorial6.text = number6;
        player.quest = quest;
    }
    public void Quest6Done()
    {
        tutorial6.fontStyle = FontStyles.Strikethrough;
    }
}
