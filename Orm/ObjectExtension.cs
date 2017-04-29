using System;

namespace Lazaro.Orm
{
        public static class ObjectExtension
        {
                public static T LazyLoad<T>(this object obj, EntityManager em, ref T currentValue, int primaryKeyId) where T : new()
                {
                        if(currentValue == null) {
                                currentValue = em.Find<T>(primaryKeyId);
                        } else {
                                // TODO: check primaryKeyId?
                        }

                        return currentValue;
                }
        }
}
