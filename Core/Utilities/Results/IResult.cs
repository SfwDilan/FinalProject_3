﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IResult
    {
        //Temel void'ler için 
        bool Success { get; }
        string Message { get; }
    }
}
