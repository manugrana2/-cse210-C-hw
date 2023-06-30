/*
Keeps track of both the reference and the text of the scripture.
Can hide words and get the rendered display of the text.
*/
using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, List<Word> words)
    {
        _reference = reference;
        _words = words;
    }

    public void HideRandomWords(int numberToHide)
    {
        var random = new Random();
        for (int i = 0; i < numberToHide; i++)
        {
            var wordToHide = _words[random.Next(_words.Count)];
            wordToHide.Hide();
        }
    }

    public string GetDisplayText()
    {
        string text = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return _reference.GetDisplayText() + " "+text;
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}
