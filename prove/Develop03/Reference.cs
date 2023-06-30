/*
Keeps track of the book, chapter, and verse information.
*/
public class Reference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public string Verse { get; private set; }

    public Reference(string book, int chapter, string verse)
    {
        Book = book;
        Chapter = chapter;
        Verse = verse;
    }

    public string GetDisplayText()
    {
        return $"{Book} {Chapter}:{Verse}";
    }
}