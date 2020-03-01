using System;
using System.Collections.Generic;

namespace com.b_velop.Stack.Air.Data.Dtos
{
    public class TimeDto
    {
        public long Id { get; set; }
        public DateTime Timestamp { get; set; }
        public IEnumerable<ValueDto> Values { get; set; }
    }
}
