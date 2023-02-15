using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entities
{
    public enum HMOName{כללית ,מאוחדת, מכבי, לאומית}
    internal class HMO
    {
        public int Id { get; set; }
        public HMOName Name { get; set; }
    }
}
