﻿using Common.Model.Enum;

namespace Common.Model
{
    public class Numeral : Word
    {
        public Numeral(string text) : base(text)
        { }

        public override WordType WordType
        {
            get { return WordType.Numeral; }
        }

        public const string KEY = @"Num";
        public override string Key { get { return KEY; } }
    }
}