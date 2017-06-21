using System;
using Mylib.Reflection;

namespace MessageSample.Messages
{
    class AlertMessage
    {

        public String Type {get; set; }
        public int Priority { get; set; }
        public String Content { get; set; }
        public String From { get; set; }


        public override string ToString()
        {
            return string.Format("Type: {0}, Priority: {1}, Content: {2}, From: {3}", Type, Priority, Content, From);
        } 

    }
}
