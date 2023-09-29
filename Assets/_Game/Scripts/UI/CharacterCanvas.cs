using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCanvas : MonoBehaviour
{
    public InfoPanel infoPanel;
    public EmojiPanel emojiPanel;
    
    private Transform cam;

    void Start()
    {
        cam = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        transform.LookAt(cam);
    }
    
    
}
