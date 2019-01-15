using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.InfraestructuraInstruciones
{
    using ViewModels;

    class InstanceLocator
    {
        #region Propiedad
        public MainViewModel Main { get; set; }
        #endregion

        #region Constructor
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
        #endregion
    }
}
