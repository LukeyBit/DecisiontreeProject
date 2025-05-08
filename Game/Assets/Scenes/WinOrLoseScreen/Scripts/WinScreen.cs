using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinScreen : MonoBehaviour {
    public Player player;
    public TMP_Text goldText;
    public TMP_Text expText;
    int goldGained;
    int expGained;

    void Init() {
        goldGained = 15;
        expGained = 25;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.HidePlayer();
        player.AddExp(expGained);          // Give EXP for winning the battle
        player.Gold += goldGained;          // Give Gold for winning the battle

        goldText.text = "+ " + goldGained.ToString() + " Gold";
        expText.text = "+ " + expGained.ToString() + " EXP";
    }

    void Awake() {
      Init();   
    }
}
