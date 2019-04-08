using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SQAAAAAAAAAAAA
{
    [DataContract]
    public class FindResponse
    {
        [DataMember]
        public List<Person> Persons = new List<Person>();

        [DataMember]
        public bool IsFailed { get; set; }

        [DataMember]
        public bool IsMoreThanTenNames { get; set; }

        [DataMember]
        public bool IsMoreThanTenSurnames { get; set; }

        [DataMember]
        public int ExtNamesValue { get; set; }

        [DataMember]
        public int ExtSurnamesValue { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public int CountForSurname { get; set; }

        [DataMember]
        public int CountForName { get; set; }
    }
}