﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objetos;

namespace Dados
{
    internal interface ICampanha
    {
        Campanha AlterarCampanha(Campanha c);

        Campanha RetirarCampanha(Campanha c);

        bool ExisteCampanha(Campanha c);
        
        
    }
}