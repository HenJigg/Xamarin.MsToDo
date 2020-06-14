using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Core
{
    public interface IAutofacLocator
    {
        void Register();

        TInterface Get<TInterface>();
    }
}
