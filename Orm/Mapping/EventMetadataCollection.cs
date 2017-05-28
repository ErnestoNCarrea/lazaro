using System;
using System.Collections.Generic;

namespace Lazaro.Orm.Mapping
{
        public class EventMetadataCollection : List<EventMetadata>
        {
                public EventMetadata GetByType(EventTypes type)
                {
                        foreach(var Evt in this) {
                                if(Evt.Type == type) {
                                        return Evt;
                                }
                        }

                        return null;
                }
        }
}
