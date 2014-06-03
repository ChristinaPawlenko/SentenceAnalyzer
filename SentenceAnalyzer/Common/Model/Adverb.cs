﻿using Common.Model.Enum;

namespace Common.Model
{
    public class Adverb : Word
    {
        public Adverb(string text) : base(text)
        { }

        public override WordType WordType
        {
            get { return WordType.Adverb; }
        }
    }
}