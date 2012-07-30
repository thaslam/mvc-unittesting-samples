using System.Xml.Serialization;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using MvcTestingSamples.Models;

namespace MvcTestingSamples.Repositories
{
    public class SampleRepository : ISampleRepository
    {
        public void  InsertSomething(Something value)
        {
            var serializer = new XmlSerializer(typeof(Something));
            
            using (TextWriter writer = new StreamWriter(
                       HttpContext.Current.Server.MapPath(
                       string.Format("~/App_Data/{0}.xml", value.ID)), false))
            {
                serializer.Serialize(writer, value);
                writer.Close();
            }
        }

        public void  UpdateSomething(Models.Something value)
        {
            var serializer = new XmlSerializer(typeof(Something));

            using (TextWriter writer = new StreamWriter(
                       HttpContext.Current.Server.MapPath(
                       string.Format("~/App_Data/{0}.xml", value.ID)), false))
            {
                serializer.Serialize(writer, value);
                writer.Close();
            }
        }

        public void  DeleteSomething(Models.Something value)
        {
 	        File.Delete(
                HttpContext.Current.Server.MapPath(
                string.Format("~/App_Data/{0}.xml", value.ID)));
        }

        public Models.Something  GetSomething(int ID)
        {
            return GetSomethingFromDisk(
                HttpContext.Current.Server.MapPath(
                string.Format("~/App_Data/{0}.xml", ID)));
        }

        public System.Collections.Generic.IEnumerable<Models.Something>  GetSomethings()
        {
            var files = 
                System.IO.Directory.EnumerateFiles(
                HttpContext.Current.Server.MapPath(@"~/App_Data"), "*.xml");

            foreach (var file in files)
                yield return GetSomethingFromDisk(file);
        }

        private Something GetSomethingFromDisk(string path)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Something));

            using (TextReader reader = new StreamReader(path))
            {
                var something = deserializer.Deserialize(reader) as Something;
                reader.Close();

                return something;
            }
        }
    }
}