using System;
using System.Collections;

public class NaiveBayes
{
    public NaiveBayes()
	{
	}


    // use a quequ to contain all the tranning set
    Queue tranningset = new Queue();

    private void storeTranningSet(string data)
    {
        tranningset.Enqueue(data);
        Console.WriteLine("enqueue sucess\n");
    }

}
