﻿using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace StructureMap.SolrNetIntegration.Config
{
    public class SolrServerElements : ConfigurationElementCollection, IEnumerable<ISolrServer>
    {
        public void Add(SolrServerElement configurationElement)
        {
            base.BaseAdd(configurationElement);
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new SolrServerElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var solrServerElement = (SolrServerElement)element;
            return solrServerElement.Url + solrServerElement.DocumentType;
        }

        IEnumerator<ISolrServer> IEnumerable<ISolrServer>.GetEnumerator()
        {
            foreach (SolrServerElement server in this)
            {
                yield return server;
            }
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override string ElementName
        {
            get { return "server"; }
        }
    }
}
