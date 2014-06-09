using Common.Model;
using Common.Model.Enum;

public class Interjection : Word
{
    public Interjection(string text) : base(text)
    { }

    public override WordType WordType
    {
        get { return WordType.Interjection; }
    }

    public const string KEY = @"I";
    public override string Key { get { return KEY; } }
}