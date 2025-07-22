using TMPro;
using UnityEngine;

public class LeftTriggerScript : MonoBehaviour
{
    public int rightScore;
    public TextMeshProUGUI rightScoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        rightScoreText.text = rightScore.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        rightScore++;
        collision.gameObject.transform.position = Vector3.zero;

    }
}
