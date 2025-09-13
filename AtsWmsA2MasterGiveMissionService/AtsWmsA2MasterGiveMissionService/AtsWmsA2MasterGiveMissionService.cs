using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace AtsWmsA2MasterGiveMissionService
{
    public partial class AtsWmsA2MasterGiveMissionService : ServiceBase
    {
        static string className = "AtsWmsA2MasterGiveMissionService";
        private static readonly ILog Log = LogManager.GetLogger(className);
        public AtsWmsA2MasterGiveMissionService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                Log.Debug("OnStart :: AtsWmsA2MasterGiveMissionService in OnStart....");

                try
                {
                    XmlConfigurator.Configure();
                    try
                    {
                        AtsWmsA2MasterGiveMissionServiceTaskThread();
                    }
                    catch (Exception ex)
                    {
                        Log.Error("OnStart :: Exception occured while AtsWmsA1MasterGiveMissionServiceTaskThread  threads task :: " + ex.Message);
                    }
                    Log.Debug("OnStart :: AtsWmsA1MasterGiveMissionServiceTaskThread in OnStart ends..!!");
                }
                catch (Exception ex)
                {
                    Log.Error("OnStart :: Exception occured in OnStart :: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Log.Error("OnStart :: Exception occured in OnStart :: " + ex.Message);
            }
        }

        public async void AtsWmsA2MasterGiveMissionServiceTaskThread()
        {
            await Task.Run(() =>
            {
                try
                {
                    AtsWmsA2MasterGiveMissionDetails AtsWmsA2MasterGiveMissionDetailsInstance = new AtsWmsA2MasterGiveMissionDetails();
                    AtsWmsA2MasterGiveMissionDetailsInstance.startOperation();
                }
                catch (Exception ex)
                {
                    Log.Error("TestService :: Exception in AtsWmsA1MasterGiveMissionServiceTaskThread :: " + ex.Message);
                }

            });
        }


        protected override void OnStop()
        {
            try
            {
                Log.Debug("OnStop :: AtsWmsA2MasterGiveMissionService in OnStop ends..!!");
            }
            catch (Exception ex)
            {
                Log.Error("OnStop :: Exception occured in OnStop :: " + ex.Message);
            }
        }
    }
}
