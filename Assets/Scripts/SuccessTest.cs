using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessTest : MonoBehaviour
{
    public Answers []answers;

    // public struct AnswerVerification
    //  {
    //     public float answer;
    //     public string type;
    //     public AnswerVerification(float answer, string type){
    //         this.answer = answer;
    //         this.type = type;
    //     }
    //  }

    // AnswerVerification answerStruct;
    // [SerializeField] int idFase;

    public Queue<Answers> answerQueue;

    void Start(){
        answerQueue = new Queue<Answers>();
        answerQueue.Clear();
        
        foreach(Answers answers in answers){
            answerQueue.Enqueue(answers);
        }

        // if(idFase == 1){
        //     answerStruct = new AnswerVerification(0f,"more");
        //     answerQueue.Enqueue(new AnswerVerification(3f, "equal"));
        //     answerQueue.Enqueue(new AnswerVerification(4f, "equal"));
        // }
        // else if(idFase == 2){
        //     return;
        // }
    }

    public bool Verify(float answer){

        Answers playerAnswer = answerQueue.ToArray()[0];
        bool passTest;

        switch(playerAnswer.type){
            case "less":
                passTest = answer < playerAnswer.answer;
            break;

            case "more":
                passTest = answer > playerAnswer.answer;
            break;

            default:
                passTest = answer == playerAnswer.answer;
            break;
            
        }

        if(passTest){
            answerQueue.Dequeue();
        }
        return passTest;        
    }
}