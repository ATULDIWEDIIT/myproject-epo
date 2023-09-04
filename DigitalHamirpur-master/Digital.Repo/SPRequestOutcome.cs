using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Repo
{
    public class SPRequestOutcome
    {
        public SPRequestOutcome()
        {
            IsSuccess = true;
        }

        public object Data { get; set; }
        public bool IsSuccess { get; set; }
    }
}
