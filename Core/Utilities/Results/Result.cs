using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        
        public Result(bool success,string message):this(success)
        {
            //get; readonly'dir. Readonly olanlar constructorda set edilebilir.
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }

        //set;'i de ekleyebilirdik. Ama programcı isteği üzerine birşey yazmasın.Kodların okunurluğu standart olsun.
        public bool Success { get; }

        public string Message { get; }
    }
}
