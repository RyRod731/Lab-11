using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Task1 : MonoBehaviour
{
    public string[] firstNames = new string[] { "Roger", "Bob", "Adam", "Alec", "Patrick", "Mario", "Luigi", "Ryan", "Michael", "Gabriel", "Raphael", "Uriel", "Daniel", "Karen", "Lucas", "Andres", "Ben", "Hilda", "Zack", "Vincent"};

    const int firstCapitalLetter = 65;
    const int lastCapitalLetter = 90;

    Queue<string> queue = new Queue<string>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++) queue.Enqueue(GenerateName());
        string initialList = FullList(queue.ToArray());
        Debug.Log("Initial login queue created. There are 5 players in the queue: " + initialList);
        StartCoroutine(LoginCor());
    }

   string GenerateName() => firstNames[Random.Range(0, firstNames.Length)] + " " + (char)Random.Range(firstCapitalLetter, lastCapitalLetter+1);

   public static string FullList(string[] strings)
   {
    string result = "";

    for (int i = 0; i < strings.Length; i++)
    {
        result += strings[i];
        result += (i < strings.Length-1)? ", " : ".";
    }
    
        return result;
   }

   IEnumerator LoginCor() {
    while(true) {
        yield return new WaitForSeconds(Random.Range(0.00001f, 25f));
        Debug.Log(queue.Peek() + ". is now inside the game.");
        queue.Dequeue();
        string newName = GenerateName ();
        queue.Enqueue(newName);
        Debug.Log(newName + ". is trying to login and added to the login queue.");
    }
   
   }
}    
    
