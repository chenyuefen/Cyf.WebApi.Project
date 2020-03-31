using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Ruanmou.SOA.Web.Remote
{
    [DataContractAttribute]
    public class UserInfo
    {
        public UserInfo()
        { }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        public int Age { get; set; }
    }
}