using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Character // Not the optimum way of doing this but it'll do for now.
{
    public string name;
    public string testDialogue;
    

    public Character(string name, string testDialogue) => this.name = name;

}
public class dialogue : MonoBehaviour
{
    
    public GameObject textBox;
    public Sprite kaneSprite;
    public List<Character> newDialogue;
    public string blank = "";

    int CreateDialogue(string x, int index)
    {
        switch (index)
        {
            case 0:
                x = "Leeman";
                break;

            case 1:
                x = "Hamza";
                break;

            case 2:
                x = "Bethany";
                break;

            case 3:
                x = "Kane";
                break;

            default:
                break;

        }
        return 0;
   
    }

    string ProgressText(List<Character> x)
    {
        
        
        

        //Debug.Log("Text: " + x[1].name);
        //Debug.Log(newText);
        blank = (x[1].name);
        //textBox.GetComponentInChildren<TMP_Text>().text = newText;
        Instantiate(textBox);
        return blank;
    }

    List<Character> InitDialogue()
    {
        newDialogue = new List<Character>();
        newDialogue.AddRange(new List<Character>
        {
            new Character("Kane", "Leeman... Please let me die"),
            new Character("Leeman", "No, U"),
            new Character("Bethany", "Hehehehe, it's Bethany!! REWILDING!! HEHEHEHE!!!"),
            new Character("Leeman", "Roses are red, violets are blue, I love you Beth even though you are only 4ft2"),
            new Character("Bethany", "Aw, that's so nice. I love it."),
            new Character("Hamza", "Leeman you fucking simp"),
        });

        Debug.Log("Dialogue initialized");
        return newDialogue;
    }

    void Awake()
    {
        
        List<Character> newDialogue = InitDialogue();    // I need to be able to push this value to the 'Update' function... Why's this so damn hard?
    }
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Press de 'E' man, ova");
            //ProgressText(newDialogue);
        }
    }
}
