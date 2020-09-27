using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{

    private void Awake()
    {
        myMat = GetComponent<Renderer>();
    }
    Renderer myMat;
    [Header("Texture Scroll")]

    public float offset = 0f;
    public float speed = 4f;

    // Update is called once per frame
    void FixedUpdate()
    {

        

    }

    public void TextureScroll()
    {
        offset += speed * Time.deltaTime;

        if (offset < 1f)
        {
            offset = 0f;
        }

     //   myMat.material.mainTextureOffset("_MainTex", new Vector2(0, offset));

    }
}
