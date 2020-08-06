using CodeBlog.CORE.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.CORE.ResultTypes
{
    public class EntityResult
    {
        public EntityResult(string msg,ResultState state)
        {
            Message = msg;
            State = state;
        }
        public string Message { get; set; }
        public ResultState State { get; set; }
    }

    public class EntityResult<TData> : EntityResult
        where TData: class
    {
        public EntityResult(TData data,string msg,ResultState state): base(msg,state)
        {
            Data = data;
        }
        public TData Data { get; set; }
    }
}
