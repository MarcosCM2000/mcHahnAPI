﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcHahn.Contracts.Authentication
{
    public record LoginRequest
    {
        string email;
        string password;
    }
}
