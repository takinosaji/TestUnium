using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Threading;
using TestUnium.Extensibility;

namespace TestUnium.Plugging
{
    public class StaticPluginCompositionEngine : ICompositionEngine<IStaticPlugin>
    {
        private readonly CompositionContainer _container;

        [ImportMany]
        public IEnumerable<Lazy<IStaticPlugin>> Parts;

        public StaticPluginCompositionEngine(String directoryPath, Boolean includeSubdirectories = false)
        {
            var paths = includeSubdirectories ? Directory.EnumerateDirectories(directoryPath, "*", SearchOption.AllDirectories) 
                : new List<String> { directoryPath };
            AggregateCatalog catalog = new AggregateCatalog();

            foreach (var path in paths)
            {
                catalog.Catalogs.Add(new DirectoryCatalog(path));
            }
            _container = new CompositionContainer(catalog);

            try
            {
                _container.ComposeParts(this);
            }
            catch (Exception excp)
            {
                Parts = new List<Lazy<IStaticPlugin>>();
            }
        }

        public IEnumerable<IStaticPlugin> GetComposedParts() => Parts.Select(p => p.Value);
    }
}