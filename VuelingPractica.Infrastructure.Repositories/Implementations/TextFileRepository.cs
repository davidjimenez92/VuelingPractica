using System.Configuration;
using System.IO;
using VuelingPractica.CrossCutting.AppSettings;
using VuelingPractica.Domain.Entities;
using VuelingPractica.Infrastructure.Repositories.Contracts;

namespace VuelingPractica.Infrastructure.Repositories.Implementations
{
    public class TextFileRepository : IFileRepository<Registry>
    {
        private static readonly VuelingPracticaAppSettings config = ConfigurationManager.GetSection(nameof(VuelingPracticaAppSettings)) as VuelingPracticaAppSettings;

        public Registry Add(Registry entity)
        {
            using (StreamWriter streamWriter = File.AppendText(config.TextFilePath))
            {
                streamWriter.WriteLine(entity);
            }

            return entity;
        }
    }
}
