using System;

namespace Lazaro.Orm.Mapping
{
        public enum AssociationTypes
        {
                None = 0,
                OneToOne,
                ManyToOne,
                OneToMany,
                ManyToMany
        }
}