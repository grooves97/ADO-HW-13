﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DCA.Models;

namespace DCA.DataAcces.Abstract
{
    public interface IRepository<T> : IDisposable where T:Entity
    {
        void Add(T item);
        void Update(T item);
        void Delete(Guid id);
        ICollection<T> GetAll();
    }
}
