using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace SQAAAAAAAAAAAA
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1 : IService1
    {
        public FindResponse Find(string value) 
        {
            //get from config amount of data that will be displayed
            var result = new FindResponse() { ExtNamesValue =Int32.Parse(ConfigurationManager.AppSettings["ExtNamesValue"]),
                ExtSurnamesValue = Int32.Parse(ConfigurationManager.AppSettings["ExtSurnamesValue"]) };
            try
            {
                FindParamsValidator validator = new FindParamsValidator();//check for correct input

                List<string> errors = validator.Validate(value); //get potential errors

                if (errors.Count > 0) // if contains err-s set isFailed = true and return msg
                {
                    result.IsFailed = true;
                    result.Message = String.Join(" ", errors);
                    return result;
                }
                PersonRepository repository = new PersonRepository(); 
                List<Person> persons = new List<Person>();
                persons = repository.FindBySurnameAndName(value); // search for surname and name
                persons.AddRange(repository.FindBySurname(value)); // first added by surname
                result.CountForSurname = persons.Count; // count gained data
                if (result.CountForSurname > result.ExtSurnamesValue)
                {
                    result.IsMoreThanTenNames = true; // if > 10 -> message and show less data
                }

                persons.AddRange(repository.FindByName(value)); // second add by name
                result.CountForName = repository.FindByName(value).Count; // count gained data from find by name
                
                if (result.CountForName > result.ExtNamesValue)
                {
                    result.IsMoreThanTenSurnames = true; // if > 10 -> message and show less data
                }
                result.Persons = persons;
                return result;
            }
            catch (Exception ex)
            {
                result.IsFailed = true;
                result.Message = ex.Message;
                return result;
            }
            
        }
        
    }
    // Добавьте здесь дополнительные операции и отметьте их атрибутом [OperationContract]
}

