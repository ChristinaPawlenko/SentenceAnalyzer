﻿using Common.Model.Enum;

namespace Common.Model
{
    public class Adjective : Word
    {
        public Adjective(string text) : base(text)
        { }

        public override WordType WordType
        {
            get { return WordType.Adjective; }
        }
    }
}