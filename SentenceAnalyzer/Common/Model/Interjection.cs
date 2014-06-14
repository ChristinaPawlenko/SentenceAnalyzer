using Common.Model;
using Common.Model.Enum;

public class Interjection : Word
{
    public Interjection(string text) : base(text)
    { }

    public override string Key(string form)
    {
        return KEY;
    }

    public override WordType WordType
    {
        get { return WordType.Interjection; }
    }

    public const string KEY = @"I";
}