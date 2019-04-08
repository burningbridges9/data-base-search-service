using System.Runtime.Serialization;

namespace SQAAAAAAAAAAAA
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
    }
}