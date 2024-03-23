using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gui : MonoBehaviour
{

    [Header("Score")]
    [SerializeField] private TextMeshProUGUI   Score ;

    [SerializeField] private Player player ;


    // Start is called before the first frame update
    void Start()
    {
        // TextMeshPro textMeshPro = Score.GetComponentInChildren<TextMeshPro>();


    }

    // Update is called once per frame
    void Update()
    {
        Score.text = "Score : " + player.score.ToString();
    }
}
