﻿using Assets.Scripts.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    public interface IObjectPool
    {
        public ObjectPool ObjectPool { get; set; }
    }
}
