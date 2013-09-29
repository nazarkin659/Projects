using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace YandexAPI
{
    [Serializable]
    [DataContract]
    class YandexJSON
    {
        [DataMember]
        public int code { get; set; }
        [DataMember]
        public string lang { get; set; }

        [DataMember]
        public List<string> text { get; set; }
    }
}
