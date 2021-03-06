﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace MyCaffe.gym
{
    /// <summary>
    /// The MyCaffeGymUiProxy is used to interact with the MyCaffeGymUiService.
    /// </summary>
    public class MyCaffeGymUiProxy : DuplexClientBase<IXMyCaffeGymUiService>       
    {
        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="ctx">Specifies the context.</param>
        public MyCaffeGymUiProxy(InstanceContext ctx)
            : base(ctx, new ServiceEndpoint(ContractDescription.GetContract(typeof(IXMyCaffeGymUiService)),
                   new NetNamedPipeBinding(), new EndpointAddress("net.pipe://localhost/MyCaffeGym/gymui")))
        {
        }

        /// <summary>
        /// Open the Gym user interface.
        /// </summary>
        /// <param name="strName">Specifies the Gym name.</param>
        /// <param name="nId">Specifies the ID of the Gym.</param>
        /// <returns>The ID of the Gym opened is returned.</returns>
        public int OpenUi(string strName, int nId)
        {
            return Channel.OpenUi(strName, nId);
        }

        /// <summary>
        /// Closes the Gym user interface.
        /// </summary>
        /// <param name="nId">Specifies the ID of the Gym.</param>
        public void CloseUi(int nId)
        {
            Channel.CloseUi(nId);
        }

        /// <summary>
        /// Render the observation of the Gym.
        /// </summary>
        /// <param name="nId">Specifies the ID of the Gym.</param>
        /// <param name="obs">Specifies the Observation to render.</param>
        public void Render(int nId, Observation obs)
        {
            Channel.Render(nId, obs);
        }

        /// <summary>
        /// Returns whether or not the Gym user interface is visible or not.
        /// </summary>
        /// <param name="nId">Specifies the ID of the Gym.</param>
        /// <returns>Returns <i>true</i> if the Gym is visible, <i>false</i> otherwise.</returns>
        public bool IsOpen(int nId)
        {
            return Channel.IsOpen(nId);
        }
    }
}
