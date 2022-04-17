﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace VuelingPractica.CrossCutting.AppSettings
{
    public class CustomConfigLoader : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            if (section == null)
                throw new ArgumentNullException("section");

            var type = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .FirstOrDefault(t => t.Name == section.Name);

            if (type == null)
                throw new ArgumentNullException($"{section.Name}");

            var xmlSerializer = new XmlSerializer(type, new XmlRootAttribute(section.Name));
            using (var reader = new XmlNodeReader(section))
            {
                return xmlSerializer.Deserialize(reader);
            }
        }
    }
}
