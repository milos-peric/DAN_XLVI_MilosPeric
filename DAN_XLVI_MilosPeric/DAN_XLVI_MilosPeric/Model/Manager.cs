using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLVI_MilosPeric.Model
{
    class Manager : Employee
    {
        public string Sector { get; set; } //HR / finansije / R&D
        public string AccessLevel { get; set; } //modify / read-only
    }
}
