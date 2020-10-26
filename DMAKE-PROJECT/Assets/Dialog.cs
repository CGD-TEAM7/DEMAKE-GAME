using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Player player;

    public Text dialogText;

    public Image image;


    void Start()
    {
        player._moveSpeed = 0;
        StartCoroutine(IntroText());
    }

    IEnumerator IntroText()
    {
        dialogText.text = "Follow";
        yield return new WaitForSeconds(0.25f);

        dialogText.text = "Follow  me";
        yield return new WaitForSeconds(0.25f);

        dialogText.text = "Follow  me  into";
        yield return new WaitForSeconds(0.25f);

        dialogText.text = "Follow  me  into  the";
        yield return new WaitForSeconds(0.25f);

        dialogText.text = "Follow  me  into  the  woods";
        yield return new WaitForSeconds(0.25f);


        dialogText.text = "Follow  me  into  the  woods  boy";
        yield return new WaitForSeconds(3);


        dialogText.text = "It";
        yield return new WaitForSeconds(0.25f);

        dialogText.text = "It  is";
        yield return new WaitForSeconds(0.25f);

        dialogText.text = "It  is  time";
        yield return new WaitForSeconds(0.25f);

        dialogText.text = "It  is  time  you";
        yield return new WaitForSeconds(0.25f);

        dialogText.text = "It  is  time  you  showed";
        yield return new WaitForSeconds(0.25f);

        dialogText.text = "It  is  time  you  showed  me";
        yield return new WaitForSeconds(0.25f);

        dialogText.text = "It  is  time  you  showed  me  what";
        yield return new WaitForSeconds(0.25f);

        dialogText.text = "It  is  time  you  showed  me  what  you";
        yield return new WaitForSeconds(0.25f);

        dialogText.text = "It  is  time  you  showed  me  what  you  know";
        yield return new WaitForSeconds(0.25f);

        dialogText.text = "It  is  time  you  showed  me  what  you  know  about";
        yield return new WaitForSeconds(0.25f);

        dialogText.text = "It  is  time  you  showed  me  what  you  know  about  hunting";
        yield return new WaitForSeconds(3);
        dialogText.text = "";
        image.enabled = false;
        player._moveSpeed = 5;
    }


    void Update()
    {
        
    }



    
}
