using System;
using System.Collections.Generic;
namespace Lfx.Updates
{
        public class PackageCollection : List<Package>
        {
                public Updater Updater { get; set; }

                public PackageCollection(Updater parent)
                {
                        this.Updater = parent;
                }

                new public void Add(Package item)
                {
                        item.Updater = this.Updater;
                        base.Add(item);
                }
        }
}
