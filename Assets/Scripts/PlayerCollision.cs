using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public GameManager gameManager;
    public Score score;

    private Renderer playerRenderer;
    private Material originalMaterial;

    void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        originalMaterial = playerRenderer.material;
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            
            movement.enabled = false;
           
            Material redMaterial = new Material(Shader.Find("Standard"));
            redMaterial.color = Color.red; 

            // Change player color to red
            playerRenderer.material = redMaterial;

            FindObjectOfType<GameManager>().EndGame();
           
            // Change the score text color to red
            score.ChangeScoreTextColor(Color.red);
        }
    }
    public void ResetPlayerColor()
    {
        playerRenderer.material = originalMaterial;
    }
}
