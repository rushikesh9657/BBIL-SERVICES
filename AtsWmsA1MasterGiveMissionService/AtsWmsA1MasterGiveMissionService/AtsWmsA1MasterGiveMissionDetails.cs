using log4net;
using OPCAutomation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using AtsWmsA1MasterGiveMissionService.ats_wms_bharat_biotech_dbDataSetTableAdapters;
using static AtsWmsA1MasterGiveMissionService.ats_wms_bharat_biotech_dbDataSet;
using System.Threading;
using System.Runtime.ExceptionServices;

namespace AtsWmsA1MasterGiveMissionService
{
    class AtsWmsA1MasterGiveMissionDetails
    {
        #region DataTables
        ats_wms_master_plc_connection_detailsDataTable ats_wms_master_plc_connection_detailsDataTableDT = null;
        ats_wms_master_decision_point_direction_detailsDataTable ats_wms_master_decision_point_direction_detailsDataTableDT = null;
        ats_wms_master_decision_point_direction_detailsDataTable ats_wms_master_decision_point_direction_detailsDataTableDataRequestDT = null;
        ats_wms_master_decision_point_direction_detailsDataTable ats_wms_master_decision_point_direction_detailsDataTableTaskCompletionDT = null;
        ats_wms_master_decision_point_direction_detailsDataTable ats_wms_master_decision_point_direction_detailsDataTableTaskConfirmationDT = null;
        ats_wms_master_pallet_informationDataTable ats_wms_master_pallet_informationDataTableDT = null;
        ats_wms_outfeed_mission_runtime_detailsDataTable ats_wms_outfeed_mission_runtime_detailsDataTableDT = null;
        ats_wms_infeed_mission_runtime_detailsDataTable ats_wms_infeed_mission_runtime_detailsDataTableDT = null;
        ats_wms_master_stacker_tag_detailsDataTable ats_wms_master_stacker_tag_detailsDataTableDT = null;
        ats_wms_master_stacker_tag_detailsDataTable ats_wms_master_stacker_tag_detailsDataTableSourceDT = null;
        ats_wms_master_stacker_tag_detailsDataTable ats_wms_master_stacker_tag_detailsDataTableDestinationDT = null;
        ats_wms_master_stacker_tag_detailsDataTable ats_wms_master_stacker_tag_detailsDataTableFeedbackDT = null;
        ats_wms_master_position_detailsDataTable ats_wms_master_position_detailsDataTableDT = null;
        ats_wms_current_pallet_stock_detailsDataTable ats_wms_current_pallet_stock_detailsDataTableDT = null;
        ats_wms_master_station_tag_detailsDataTable ats_wms_master_station_tag_detailsDataTablePalletPresentDT = null;
        ats_wms_transfer_pallet_mission_runtime_detailsDataTable ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT = null;
        ats_wms_infeed_mission_runtime_detailsDataTable ats_wms_infeed_mission_runtime_detailsDataTableInProgressDT = null;
        ats_wms_transfer_pallet_mission_runtime_detailsDataTable ats_wms_transfer_pallet_mission_runtime_detailsDataTableInProgressDT = null;
        ats_wms_check_a1_mission_detailsDataTable ats_wms_check_a1_mission_detailsDataTableDT = null;
        ats_wms_master_rack_detailsDataTable ats_wms_master_rack_detailsDataTableDT = null;
        ats_wms_master_rack_detailsDataTable ats_wms_master_rack_detailsDataTablePrevTRDT = null;
        ats_wms_master_position_detailsDataTable ats_wms_master_position_detailsDataTablePrevTRDT = null;
        ats_wms_master_position_detailsDataTable ats_wms_master_position_detailsDataTableTemptDT = null;
        ats_wms_master_position_detailsDataTable ats_wms_master_position_detailsDataTableRackPalletsDT = null;
        ats_wms_infeed_mission_runtime_detailsDataTable ats_wms_infeed_mission_runtime_detailsDataTableReadyDT = null;
        ats_wms_transfer_pallet_mission_runtime_detailsDataTable ats_wms_transfer_pallet_mission_runtime_detailsDataTableReadyDT = null;
        ats_wms_outfeed_mission_runtime_detailsDataTable ats_wms_outfeed_mission_runtime_detailsDataTableReadyDT = null;

        #endregion

        #region TableAdapters
        ats_wms_master_plc_connection_detailsTableAdapter ats_wms_master_plc_connection_detailsTableAdapterInstance = new ats_wms_master_plc_connection_detailsTableAdapter();
        ats_wms_master_decision_point_direction_detailsTableAdapter ats_wms_master_decision_point_direction_detailsTableAdapterInstance = new ats_wms_master_decision_point_direction_detailsTableAdapter();
        ats_wms_master_pallet_informationTableAdapter ats_wms_master_pallet_informationTableAdapterInstance = new ats_wms_master_pallet_informationTableAdapter();
        ats_wms_outfeed_mission_runtime_detailsTableAdapter ats_wms_outfeed_mission_runtime_detailsTableAdapterInstance = new ats_wms_outfeed_mission_runtime_detailsTableAdapter();
        ats_wms_infeed_mission_runtime_detailsTableAdapter ats_wms_infeed_mission_runtime_detailsTableAdapterInstance = new ats_wms_infeed_mission_runtime_detailsTableAdapter();
        ats_wms_master_stacker_tag_detailsTableAdapter ats_wms_master_stacker_tag_detailsTableAdapterInstance = new ats_wms_master_stacker_tag_detailsTableAdapter();
        ats_wms_master_position_detailsTableAdapter ats_wms_master_position_detailsTableAdapterInstance = new ats_wms_master_position_detailsTableAdapter();
        ats_wms_current_pallet_stock_detailsTableAdapter ats_wms_current_pallet_stock_detailsTableAdapterInstance = new ats_wms_current_pallet_stock_detailsTableAdapter();
        ats_wms_master_station_tag_detailsTableAdapter ats_wms_master_station_tag_detailsTableAdapterInstance = new ats_wms_master_station_tag_detailsTableAdapter();
        ats_wms_transfer_pallet_mission_runtime_detailsTableAdapter ats_wms_transfer_pallet_mission_runtime_detailsTableAdapterInstance = new ats_wms_transfer_pallet_mission_runtime_detailsTableAdapter();
        ats_wms_check_a1_mission_detailsTableAdapter ats_wms_check_a1_mission_detailsTableAdapterInstance = new ats_wms_check_a1_mission_detailsTableAdapter();
        ats_wms_master_rack_detailsTableAdapter ats_wms_master_rack_detailsTableAdapterInstance = new ats_wms_master_rack_detailsTableAdapter();
        #endregion

        #region PLC PING VARIABLE   
        //private string IP_ADDRESS = System.Configuration.ConfigurationManager.AppSettings["IP_ADDRESS"]; //2
        private string IP_ADDRESS = "10.10.56.131";
        private Ping pingSenderForThisConnection = null;
        private PingReply replyForThisConnection = null;
        private Boolean pingStatus = false;
        private int serverPingStatusCount = 0;
        #endregion

        #region KEPWARE VARIABLES

        /* Kepware variable*/

        OPCServer ConnectedOpc = new OPCServer();

        Array OPCItemIDs = Array.CreateInstance(typeof(string), 100);
        Array ItemServerHandles = Array.CreateInstance(typeof(Int32), 100);
        Array ItemServerErrors = Array.CreateInstance(typeof(Int32), 100);
        Array ClientHandles = Array.CreateInstance(typeof(Int32), 100);
        Array RequestedDataTypes = Array.CreateInstance(typeof(Int16), 100);
        Array AccessPaths = Array.CreateInstance(typeof(string), 100);
        Array ItemServerValues = Array.CreateInstance(typeof(string), 100);
        OPCGroup OpcGroupNames;
        object aDIR;
        object bDIR;

        // Connection string
        static string plcServerConnectionString = null;

        #endregion

        #region Global Variables
        static string className = "AtsWmsA1MasterGiveMissionDetails";
        private static readonly ILog Log = LogManager.GetLogger(className);
        private System.Timers.Timer a1GiveMissionTimer = null;


        int palletPresentOnStackerPickupPosition = 0;
        string palletCodeOnStackerPickupPosition = "";
        int areaId = 1;
        int stackerRightSide = 2;
        int stackerLeftSide = 1;
        public int stackerAreaSide = 0;
        public int stackerFloor = 0;
        public int stackerColumn = 0;
        int positionNumberInRack = 0;
        int sourcePositionTagType = 0;
        int destinationPositionTagType = 1;
        int feedbackTagType = 2;
        public int destinationPositionNumberInRack = 1;
        int infeedTaskType = 1;
        int outfeedTaskType = 2;
        int transferTaskType = 3;
        int racksideLeft = 1;
        int racksideRight = 2;
        int loadingSideColumn = 1;
        int unLoadingSideColumn = 37;
        int startTargetFloorId = 1;
        int infeedAndOutfeedDepth = 2;



        #endregion

        public void startOperation()
        {
            try
            {
                //Timer 
                a1GiveMissionTimer = new System.Timers.Timer();
                //Running the function after 1 sec 
                a1GiveMissionTimer.Interval = (1000);
                //to reset timer after completion of 1 cycle
                a1GiveMissionTimer.AutoReset = false;


                //After 1 sec timer will elapse and DataFetchDetailsOperation function will be called 
                a1GiveMissionTimer.Elapsed += new System.Timers.ElapsedEventHandler(atsWmsA1GiveMissionOperation);
                //Timer Start
                a1GiveMissionTimer.Start();
            }
            catch (Exception ex)
            {
                Log.Error("startOperation :: Exception Occure in a1GiveMissionTimer" + ex.Message);
            }
        }


        public void atsWmsA1GiveMissionOperation(object sender, EventArgs args)
        {
            try
            {

                try
                {
                    //Stopping the timer to start the below operation
                    a1GiveMissionTimer.Stop();
                }
                catch (Exception ex)
                {
                    Log.Error("atsWmsA1GiveMissionOperation :: Exception occure while stopping the timer :: " + ex.Message + "StackTrace  :: " + ex.StackTrace);
                }

                try
                {
                    //Fetching PLC data from DB by sending PLC connection IP address
                    ats_wms_master_plc_connection_detailsDataTableDT = ats_wms_master_plc_connection_detailsTableAdapterInstance.GetDataByPLC_CONNECTION_IP_ADDRESS(IP_ADDRESS);

                }
                catch (Exception ex)
                {
                    Log.Error("atsWmsA1GiveMissionOperation :: Exception Occure while reading machine datasource connection details from the database :: " + ex.Message + "StackTrace :: " + ex.StackTrace);
                }


                // Check PLC Ping Status
                try
                {
                    //Checking the PLC ping status by a method
                    pingStatus = checkPlcPingRequest();
                }
                catch (Exception ex)
                {
                    Log.Error("atsWmsA1GiveMissionOperation :: Exception while checking plc ping status :: " + ex.Message + " stactTrace :: " + ex.StackTrace);
                }

                if (pingStatus == true)
                //if (true)
                {
                    Log.Debug("1");
                    //checking if the PLC data from DB is retrived or not
                    if (ats_wms_master_plc_connection_detailsDataTableDT != null && ats_wms_master_plc_connection_detailsDataTableDT.Count != 0)
                    //if (true)
                    {
                        Log.Debug("2");
                        try
                        {
                            plcServerConnectionString = ats_wms_master_plc_connection_detailsDataTableDT[0].PLC_CONNECTION_URL;
                        }
                        catch (Exception ex)
                        {
                            Log.Error("atsWmsA1GiveMissionOperation :: Exception while checking plcServerConnectionString :: " + ex.Message + " stactTrace :: " + ex.StackTrace);
                        }
                        try
                        {
                            //Calling the connection method for PLC connection
                            OnConnectPLC();
                        }
                        catch (Exception ex)
                        {
                            Log.Error("atsWmsA1GiveMissionOperation :: Exception while connecting to plc :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                        }

                        // Check the PLC connected status
                        if (ConnectedOpc.ServerState.ToString().Equals("1"))
                        //if (true)
                        {
                            Log.Debug("3");
                            //BussinessLogic


                            try
                            {
                                //Checking if any mission is ready, if the mission is ready then only go for the check



                                

                                    try
                                    {
                                    //checking inprogress mission count is 0

                                    if (isMissionInProgress(areaId) == false)
                                    {
                                        Log.Debug("4");
                                        try
                                        {
                                            //fetching is checked mission points, to check the unchecked mission points between filled pallet infeed, empty pallet outfeed, filled pallet outfeed and empty pallet infeed
                                            ats_wms_check_a1_mission_detailsDataTableDT = ats_wms_check_a1_mission_detailsTableAdapterInstance.GetDataByIS_CHECKED(0);
                                            if (ats_wms_check_a1_mission_detailsDataTableDT != null && ats_wms_check_a1_mission_detailsDataTableDT.Count > 0)
                                            {

                                                //checking for each mission point
                                                for (int i = 0; i < ats_wms_check_a1_mission_detailsDataTableDT.Count; i++)
                                                {
                                                    try
                                                    {
                                                        Thread.Sleep(200);
                                                        Log.Debug("5 ats_wms_check_a1_mission_detailsDataTableDT ID ::  " + ats_wms_check_a1_mission_detailsDataTableDT[i].A1_MISSION_DETAILS_ID);
                                                        //check for infeed missions
                                                        if (ats_wms_check_a1_mission_detailsDataTableDT[i].A1_MISSION_DETAILS_ID == 1)
                                                        {
                                                            try
                                                            {
                                                                Log.Debug("6 INFEED");
                                                                checkStackerMissionRequest("INFEED", ats_wms_check_a1_mission_detailsDataTableDT[i].A1_MISSION_DETAILS_ID);
                                                                ats_wms_check_a1_mission_detailsTableAdapterInstance.UpdateIS_CHECKEDWhereA1_MISSION_DETAILS_ID(1, ats_wms_check_a1_mission_detailsDataTableDT[i].A1_MISSION_DETAILS_ID);
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                Log.Error("giveMissionToStacker1Operation :: Exception occured while calling checkStackerMissionRequest and updating is check 1 for infeed mission ::" + ex.Message + " StackTrace:: " + ex.StackTrace);
                                                            }
                                                        }
                                                        //check for outfeed missions
                                                        else if (ats_wms_check_a1_mission_detailsDataTableDT[i].A1_MISSION_DETAILS_ID == 2)
                                                        {
                                                            try
                                                            {
                                                                Log.Debug("7 OUTFEED");
                                                                checkStackerMissionRequest("OUTFEED", ats_wms_check_a1_mission_detailsDataTableDT[i].A1_MISSION_DETAILS_ID);
                                                                ats_wms_check_a1_mission_detailsTableAdapterInstance.UpdateIS_CHECKEDWhereA1_MISSION_DETAILS_ID(1, ats_wms_check_a1_mission_detailsDataTableDT[i].A1_MISSION_DETAILS_ID);
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                Log.Error("giveMissionToStacker1Operation :: Exception occured while calling checkStackerMissionRequest and updating is check 1 for outfeed mission ::" + ex.Message + " StackTrace:: " + ex.StackTrace);
                                                            }
                                                        }
                                                        else if (ats_wms_check_a1_mission_detailsDataTableDT[i].A1_MISSION_DETAILS_ID == 3)
                                                        {
                                                            try
                                                            {
                                                                Log.Debug("8 TRANSFER");
                                                                checkStackerMissionRequest("TRANSFER", ats_wms_check_a1_mission_detailsDataTableDT[i].A1_MISSION_DETAILS_ID);
                                                                ats_wms_check_a1_mission_detailsTableAdapterInstance.UpdateIS_CHECKEDWhereA1_MISSION_DETAILS_ID(1, ats_wms_check_a1_mission_detailsDataTableDT[i].A1_MISSION_DETAILS_ID);
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                Log.Error("giveMissionToStacker1Operation :: Exception occured while calling checkStackerMissionRequest and updating is check 1 for transfer mission ::" + ex.Message + " StackTrace:: " + ex.StackTrace);
                                                            }
                                                        }
                                                        break;
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Log.Error("giveMissionToStacker1Operation :: Exception occured while checking mission deatils::" + ex.Message + " StackTrace:: " + ex.StackTrace);
                                                    }

                                                }
                                                try
                                                {
                                                    ats_wms_check_a1_mission_detailsDataTableDT = ats_wms_check_a1_mission_detailsTableAdapterInstance.GetDataByIS_CHECKED(0);
                                                    if (ats_wms_check_a1_mission_detailsDataTableDT != null && ats_wms_check_a1_mission_detailsDataTableDT.Count == 0)
                                                    {
                                                        ats_wms_check_a1_mission_detailsTableAdapterInstance.UpdateIS_CHECKED(0);
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    Log.Error("giveMissionToStacker1Operation :: Exception occured while updating is check 0 to all::" + ex.Message + " StackTrace:: " + ex.StackTrace);
                                                }

                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Log.Error("giveMissionToStacker1Operation :: Exception occured while getting is checked  = 0 data ::" + ex.Message + " StackTrace:: " + ex.StackTrace);
                                        }
                                    }
                                    }
                                    catch (Exception ex)
                                    {
                                        Log.Error("giveMissionToStacker1Operation :: Exception occured while checking infeed and outfeed mission inprogress data ::" + ex.Message + " StackTrace:: " + ex.StackTrace);
                                    }
                                
                            }
                            catch (Exception ex)
                            {
                                Log.Error("giveMissionToStacker1Operation :: Exception occured while checking ready missions ::" + ex.Message + " StackTrace:: " + ex.StackTrace);
                            }

                        }
                        else
                        {
                            //Reconnect to plc
                        }
                    }
                    else
                    {
                        //Reconnect to plc, Check Ip address, url
                    }
                }

            }
            catch (Exception ex)
            {

                Log.Error("startOperation :: Exception occured while stopping timer :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
            }
            finally
            {
                try
                {
                    //Starting the timer again for the next iteration
                    a1GiveMissionTimer.Start();
                }
                catch (Exception ex1)
                {
                    Log.Error("startOperation :: Exception occured while stopping timer :: " + ex1.Message + " stackTrace :: " + ex1.StackTrace);
                }
            }

        }

        #region isMissionInProgress

        public Boolean isMissionInProgress(int areaId)
        {

            Log.Debug("5 : Checking inprogress mission count is 0 of infeed,outfeed and tranfer");
            Log.Debug("4 : Check wheather the missions are in progress");
            Log.Debug("4A : Fetching Inprogress Outfeed Mission");
            try
            {
                //Fetching inprogress outfeed missions by sending area ID and mission status (to check if any outfeed mission is not running then infeed mission can be given)
                ats_wms_outfeed_mission_runtime_detailsDataTableDT = ats_wms_outfeed_mission_runtime_detailsTableAdapterInstance.GetDataByAREA_IDAndOUTFEED_MISSION_STATUS(areaId, "IN_PROGRESS");
            }
            catch (Exception ex)
            {
                Log.Error("giveMissionToStacker1Operation :: Exception occure while fetching outfeed mission data :: " + ex.Message + "StackTrace :: " + ex.StackTrace);
            }

            Log.Debug("4B : Fetching Inprogress Infeed Mission");
            try
            {
                //Fetching inprogress infeed missions by sending area ID and mission status (to check if any outfeed mission is not running then infeed mission can be given)
                ats_wms_infeed_mission_runtime_detailsDataTableInProgressDT = ats_wms_infeed_mission_runtime_detailsTableAdapterInstance.GetDataByAREA_IDAndINFEED_MISSION_STATUS(areaId, "IN_PROGRESS");
            }
            catch (Exception ex)
            {
                Log.Error("giveMissionToStacker1Operation :: Exception occure while fetching infeed mission data :: " + ex.Message + "StackTrace :: " + ex.StackTrace);
            }

            try
            {
                ats_wms_transfer_pallet_mission_runtime_detailsDataTableInProgressDT = ats_wms_transfer_pallet_mission_runtime_detailsTableAdapterInstance.GetDataByTRANSFER_MISSION_STATUSAndAREA_ID("IN_PROGRESS", areaId);
            }
            catch (Exception ex)
            {
                Log.Error("giveMissionToStacker1Operation :: Exception occured while fetching inprogress transfer mission data ::" + ex.Message + " StackTrace:: " + ex.StackTrace);
            }

            Log.Debug("4C : Fetching Inprogress Transfer Mission");

            //checking inprogress mission count is 0
            if (ats_wms_infeed_mission_runtime_detailsDataTableInProgressDT != null && ats_wms_infeed_mission_runtime_detailsDataTableInProgressDT.Count == 0 &&
                ats_wms_outfeed_mission_runtime_detailsDataTableDT != null && ats_wms_outfeed_mission_runtime_detailsDataTableDT.Count == 0 &&
                ats_wms_transfer_pallet_mission_runtime_detailsDataTableInProgressDT!=null && ats_wms_transfer_pallet_mission_runtime_detailsDataTableInProgressDT.Count==0

               )

            {
                return false;
            }

            return true;
        }

        #endregion
        public void checkStackerMissionRequest(string missionType, int checkId)
        {
            Log.Debug("8 checkStackerMissionRequest");
            //this function is used to check(read) the stacker data request
            //Fetching stacker data request tag from DB by sneding Decision point name 
            try
            {
                ats_wms_master_decision_point_direction_detailsDataTableDT = ats_wms_master_decision_point_direction_detailsTableAdapterInstance.GetDataByDECISION_POINT_NAME("AREA_1_STACKER_1_DATA_REQUEST");
            }
            catch (Exception ex1)
            {
                Log.Error("startOperation :: Exception occured while while getting data request tag details from DB :: " + ex1.Message + " stackTrace :: " + ex1.StackTrace);
            }
            for (;;)
            {
                Log.Debug("9 Check data request");
                Thread.Sleep(1000);
                try
                {
                    //Checking if the data is available in DB
                    if (ats_wms_master_decision_point_direction_detailsDataTableDT != null && ats_wms_master_decision_point_direction_detailsDataTableDT.Count > 0)
                    {
                        try
                        {
                            Log.Debug("checkStackerMissionRequest :: Found Data Request Tag :: waiting to become True");
                            //Checking if the data request is true or false(by reading the tag, True = data request is high, False = No data request from PLC)
                            if (readTag(ats_wms_master_decision_point_direction_detailsDataTableDT[0].DECISION_POINT_DIRECTION_TAG_NAME).Equals("True"))
                            {
                                if (isMissionInProgress(areaId) == false)
                                {
                                    Log.Debug("checkStackerMissionRequest :: checkStackerMissionRequest :: Recieved stacker Data Request  :: 1 ");

                                    //Calling method giveMissionToStacker by sending the pallet information ID
                                    checkPalletPresent(missionType, checkId);
                                    break;
                                }
                                else
                                {
                                    break;
                                }

                            }
                            else
                            {
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.Error("GiveMissionToStacker :: checkStackerMissionRequest :: Exception occured while reading stacker data request tag :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.Error("GiveMissionToStacker :: checkStackerMissionRequest :: Exception occured while getting stacker data request tag :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                }
            }
        }

        public void checkPalletPresent(string missionType, int checkId)
        {
            Log.Debug("IN checkPalletPresent ");

            if (missionType == "INFEED" && checkId == 1)
            {
                Log.Debug("check ID :: " + checkId + " checking palletPresent");
                //Checking if the Pallet is Present (1 - pallet is present and 0- pallet is not present)
                string palletPresent = "";
                try
                {
                    //string palletPresentTag = "";
                    //palletPresentTag=ats_wms_station_detailsDataTablePalletPresentDT[0].PLC_TAG_NAME;
                    palletPresent = readTag("ATS.WMS_AREA_1.AREA_1_STACKER_1_PICK_UP_POSITION_PALLET_PRESENT");
                }
                catch (Exception ex)
                {
                    Log.Error("Exception occurred while reading pallet present :: " + ex.StackTrace);
                }

                //if (palletPresentOnStackerPickupPosition == 1)
                if (palletPresent.Equals("True"))
                {
                    Log.Debug("6");
                    try
                    {
                        //Reading Scanner Pallet Code tag.
                        palletCodeOnStackerPickupPosition = "";
                        palletCodeOnStackerPickupPosition = readTag("ATS.WMS_AREA_1.AREA_1_STACKER_1_PICK_UP_POSITION_PALLET_CODE").Trim();
                        Log.Debug("giveMissionToStacker1Operation :: Scanned pallet code :: " + palletCodeOnStackerPickupPosition);

                        if (palletCodeOnStackerPickupPosition.Length == 4)
                        {
                            try
                            {
                                // Fetching Pallet Information from DB by passing pallet code 
                                ats_wms_master_pallet_informationDataTableDT = ats_wms_master_pallet_informationTableAdapterInstance.GetDataByPALLET_CODEAndPALLET_INFORMATION_IDOrderByDesc(palletCodeOnStackerPickupPosition);


                                // Checking if the data is present in DB
                                if (ats_wms_master_pallet_informationDataTableDT != null && ats_wms_master_pallet_informationDataTableDT.Count > 0)
                                {
                                    Log.Debug("7");
                                    Log.Debug("giveMissionToStacker1Operation :: PALLET_INFORMATION_ID :: " + ats_wms_master_pallet_informationDataTableDT[0].PALLET_INFORMATION_ID);

                                    if (ats_wms_master_pallet_informationDataTableDT[0].STATION_WORKDONE == 1)
                                    {
                                        try
                                        {
                                            Log.Debug("9");
                                            fetchMissionDetails(missionType, checkId, ats_wms_master_pallet_informationDataTableDT[0].PALLET_INFORMATION_ID);
                                        }
                                        catch (Exception ex)
                                        {
                                            Log.Error("giveMissionToStacker1Operation :: Exception occured while getting Outfeed mission Details ::" + ex.Message + " StackTrace:: " + ex.StackTrace);
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Log.Error("giveMissionToStacker1Operation :: Exception occured while fetching Pallet Information for scanned pallet code ::" + ex.Message + " StackTrace:: " + ex.StackTrace);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error("giveMissionToStacker1Operation :: Exception occured while reading scanner pallet code tag ::" + ex.Message + " StackTrace:: " + ex.StackTrace);
                    }
                }
            }

            else if (missionType == "OUTFEED" && checkId == 2)
            {
                Log.Debug("Mission type :: OUTFEED AND checkId == 2");
                ats_wms_outfeed_mission_runtime_detailsDataTableDT = ats_wms_outfeed_mission_runtime_detailsTableAdapterInstance.GetDataByAREA_IDAndOUTFEED_MISSION_STATUS(areaId, "READY");

                if (ats_wms_outfeed_mission_runtime_detailsDataTableDT != null && ats_wms_outfeed_mission_runtime_detailsDataTableDT.Count > 0)
                {
                    Log.Debug("Outfeed Mission ID  ::" + ats_wms_outfeed_mission_runtime_detailsDataTableDT[0].OUTFEED_MISSION_ID);
                    {
                        Log.Debug("checking palletPresentaAtProductionSide");
                        string palletPresentaAtProductionSide = "";
                        try
                        {
                            //string palletPresentTag = "";
                            //palletPresentTag=ats_wms_station_detailsDataTablePalletPresentDT[0].PLC_TAG_NAME;
                            palletPresentaAtProductionSide = readTag("ATS.WMS_AREA_1.AREA_1_STACKER_1_UNLOADING_POSITION_PALLET_PRESENT");
                        }
                        catch (Exception ex)
                        {
                            Log.Error("Exception occurred while reading pallet present :: " + ex.StackTrace);
                        }

                        //pallet is already present on the unloading conv

                        if (palletPresentaAtProductionSide.Equals("False"))
                        {
                            ats_wms_master_position_detailsDataTableRackPalletsDT = ats_wms_master_position_detailsTableAdapterInstance.GetDataByPOSITION_IDLessThanAndRACK_IDAndPOSITION_IS_EMPTYOrPOSITION_IS_ALLOCATED(ats_wms_outfeed_mission_runtime_detailsDataTableDT[0].POSITION_ID, ats_wms_outfeed_mission_runtime_detailsDataTableDT[0].RACK_ID, 0, 1);


                            if (ats_wms_master_position_detailsDataTableRackPalletsDT != null && ats_wms_master_position_detailsDataTableRackPalletsDT.Count == 0)
                            {
                                Log.Debug("checking palletPresentaAtProductionSide :: flase");
                                fetchMissionDetails(missionType, checkId, ats_wms_outfeed_mission_runtime_detailsDataTableDT[0].PALLET_INFORMATION_ID);
                            }
                        }
                    }
                }
                //Checking if the Pallet is Present (1 - pallet is present and 0- pallet is not present)

            }
            else if (missionType == "TRANSFER" && checkId == 3)
            {
                Log.Debug("Mission type :: OUTFEED AND checkId == 3");
                ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT = ats_wms_transfer_pallet_mission_runtime_detailsTableAdapterInstance.GetDataByTRANSFER_MISSION_STATUSAndAREA_ID("READY", areaId);

                if (ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT != null && ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT.Count > 0)
                {
                    Log.Debug("transfer Mission ID  ::" + ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT[0].TRANSFER_PALLET_MISSION_RUNTIME_DETAILS_ID);
                    for (int i = 0; i < ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT.Count; i++)
                    {
                        ats_wms_master_position_detailsDataTableTemptDT = ats_wms_master_position_detailsTableAdapterInstance.GetDataByPOSITION_ID(ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT[i].PREVIOUS_POSITION_ID);

                        Log.Debug("Pallet previous position ID :: " + ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT[i].PREVIOUS_POSITION_ID);
                        Log.Debug("Pallet previous rack ID :: " + ats_wms_master_position_detailsDataTableTemptDT[0].RACK_ID);
                        // checking if the position is above the missioned pallet posiotion has no pallet or position is not allocated
                        try
                        {
                            ats_wms_master_position_detailsDataTableDT = ats_wms_master_position_detailsTableAdapterInstance.GetDataByPOSITION_IDLessThanAndRACK_IDAndPOSITION_IS_EMPTYOrPOSITION_IS_ALLOCATED(ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT[i].PREVIOUS_POSITION_ID, ats_wms_master_position_detailsDataTableTemptDT[0].RACK_ID, 0, 1);
                        }
                        catch (Exception ex)
                        {
                            Log.Error("giveMissionToStacker1Operation :: Exception occured while getting mission rack details ::" + ex.Message + " StackTrace:: " + ex.StackTrace);
                        }

                        Log.Debug("Pallet count in rack before this pallet :: " + ats_wms_master_position_detailsDataTableDT.Count);
                        //cheking the count should be 0
                        if (ats_wms_master_position_detailsDataTableDT != null && ats_wms_master_position_detailsDataTableDT.Count == 0)
                        {
                            Log.Debug("checking palletPresentaAtDispatchSide :: flase");
                            fetchMissionDetails(missionType, checkId, ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT[i].PALLET_INFORMTION_ID);
                        }


                    }
                }

            }
        }

        public void fetchMissionDetails(string missionType, int checkId, int palletInformationId)
        {
            Log.Debug(" IN fetchMissionDetails ");
            if (missionType == "INFEED")
            {
                if (true)
                {
                    Log.Debug("11 missionType :: " + missionType);
                    try
                    {
                        ats_wms_infeed_mission_runtime_detailsDataTableDT = ats_wms_infeed_mission_runtime_detailsTableAdapterInstance.GetDataByPALLET_INFORMATION_IDAndINFEED_MISSION_STATUSAndAREA_ID(palletInformationId, "READY", areaId);

                        if (ats_wms_infeed_mission_runtime_detailsDataTableDT != null && ats_wms_infeed_mission_runtime_detailsDataTableDT.Count > 0)
                        {
                            Log.Debug("11.1 ");
                            ats_wms_check_a1_mission_detailsTableAdapterInstance.UpdateIS_CHECKEDWhereA1_MISSION_DETAILS_ID(1, checkId);
                            try
                            {
                                PositionActiveDetails positionActiveDetailsInstance = new PositionActiveDetails();

                                if (positionActiveDetailsInstance.isFloorInfeedActive(ats_wms_infeed_mission_runtime_detailsDataTableDT[0].FLOOR_ID, areaId) &&
                                    positionActiveDetailsInstance.isPositionActive(ats_wms_infeed_mission_runtime_detailsDataTableDT[0].POSITION_ID) &&
                                    positionActiveDetailsInstance.isRackActive(ats_wms_infeed_mission_runtime_detailsDataTableDT[0].RACK_ID))
                                {
                                    Log.Debug("11.2 ");
                                    try
                                    {
                                        MissionParametersDetails missionParametersDetailsInstance = new MissionParametersDetails();
                                        missionParametersDetailsInstance.missionId = ats_wms_infeed_mission_runtime_detailsDataTableDT[0].INFEED_MISSION_ID.ToString();
                                        missionParametersDetailsInstance.taskType = infeedTaskType.ToString();
                                        missionParametersDetailsInstance.targetColumn = ats_wms_infeed_mission_runtime_detailsDataTableDT[0].RACK_COLUMN.ToString();
                                        missionParametersDetailsInstance.targetFloor = ats_wms_infeed_mission_runtime_detailsDataTableDT[0].FLOOR_ID.ToString();
                                        missionParametersDetailsInstance.targetDepthOfLine = ats_wms_infeed_mission_runtime_detailsDataTableDT[0].POSITION_NUMBER_IN_RACK.ToString();

                                        if (ats_wms_infeed_mission_runtime_detailsDataTableDT[0].RACK_SIDE == "L")
                                        {
                                            missionParametersDetailsInstance.targetLine = racksideLeft.ToString();
                                        }
                                        else if (ats_wms_infeed_mission_runtime_detailsDataTableDT[0].RACK_SIDE == "R")
                                        {
                                            missionParametersDetailsInstance.targetLine = racksideRight.ToString();
                                        }
                                        missionParametersDetailsInstance.startFloor = startTargetFloorId.ToString();
                                        missionParametersDetailsInstance.startDepthOfLine = infeedAndOutfeedDepth.ToString();
                                        missionParametersDetailsInstance.startColumn = loadingSideColumn.ToString();
                                        missionParametersDetailsInstance.startLine = racksideLeft.ToString();

                                        missionParametersDetailsInstance.Sender = "WMS1";
                                        missionParametersDetailsInstance.Receiver = "PLC1";
                                        missionParametersDetailsInstance.Handshake = "RQ";
                                        missionParametersDetailsInstance.Teletype = "NEWM";
                                        missionParametersDetailsInstance.Error = "000000";


                                        string missionString = ConvertMissionParametersToString(missionParametersDetailsInstance);
                                        Log.Debug("missionString :: " + missionString);

                                        MissionParametersDetails missionDetails = ParseMissionString(missionString);
                                        giveMissionToStacker(missionString);
                                    }
                                    catch (Exception ex)
                                    {
                                        Log.Error("startOperation :: Exception occured while setting infeed mission values :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Log.Error("startOperation :: Exception occured while checking positon active atatus :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                            }
                        }
                        else
                        {
                            ats_wms_check_a1_mission_detailsTableAdapterInstance.UpdateIS_CHECKEDWhereA1_MISSION_DETAILS_ID(0, checkId);
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error("startOperation :: Exception occured while stopping timer :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                    }
                }
            }
            else if (missionType == "OUTFEED")
            {
                Log.Debug("12 missionType :: " + missionType);
                try
                {
                    ats_wms_outfeed_mission_runtime_detailsDataTableDT = ats_wms_outfeed_mission_runtime_detailsTableAdapterInstance.GetDataByPALLET_INFORMATION_IDAndOUTFEED_MISSION_STATUSAndAREA_ID(palletInformationId, "READY", areaId);

                    if (ats_wms_outfeed_mission_runtime_detailsDataTableDT != null && ats_wms_outfeed_mission_runtime_detailsDataTableDT.Count > 0)
                    {
                        Log.Debug("12.1");
                        ats_wms_check_a1_mission_detailsTableAdapterInstance.UpdateIS_CHECKEDWhereA1_MISSION_DETAILS_ID(1, checkId);
                        try
                        {
                            PositionActiveDetails positionActiveDetailsInstance = new PositionActiveDetails();

                            if (positionActiveDetailsInstance.isFloorOutfeedActive(ats_wms_outfeed_mission_runtime_detailsDataTableDT[0].FLOOR_ID, areaId) &&
                                positionActiveDetailsInstance.isPositionActive(ats_wms_outfeed_mission_runtime_detailsDataTableDT[0].POSITION_ID) &&
                                positionActiveDetailsInstance.isRackActive(ats_wms_outfeed_mission_runtime_detailsDataTableDT[0].RACK_ID))
                            {
                                Log.Debug("12.2");
                                try
                                {
                                    //fetch rack column

                                    ats_wms_master_rack_detailsDataTableDT = ats_wms_master_rack_detailsTableAdapterInstance.GetDataByRACK_ID(ats_wms_outfeed_mission_runtime_detailsDataTableDT[0].RACK_ID);



                                    MissionParametersDetails missionParametersDetailsInstance = new MissionParametersDetails();
                                    missionParametersDetailsInstance.missionId = ats_wms_outfeed_mission_runtime_detailsDataTableDT[0].OUTFEED_MISSION_ID.ToString();
                                    missionParametersDetailsInstance.taskType = outfeedTaskType.ToString();
                                    missionParametersDetailsInstance.startColumn = ats_wms_master_rack_detailsDataTableDT[0].RACK_COLUMN.ToString();
                                    missionParametersDetailsInstance.startFloor = ats_wms_outfeed_mission_runtime_detailsDataTableDT[0].FLOOR_ID.ToString();
                                    if (ats_wms_outfeed_mission_runtime_detailsDataTableDT[0].RACK_SIDE == "L")
                                    {
                                        missionParametersDetailsInstance.startLine = racksideLeft.ToString();
                                    }
                                    else if (ats_wms_outfeed_mission_runtime_detailsDataTableDT[0].RACK_SIDE == "R")
                                    {
                                        missionParametersDetailsInstance.startLine = racksideRight.ToString();
                                    }
                                    missionParametersDetailsInstance.startDepthOfLine = ats_wms_outfeed_mission_runtime_detailsDataTableDT[0].POSITION_NUMBER_IN_RACK.ToString();
                                    missionParametersDetailsInstance.targetColumn = loadingSideColumn.ToString();
                                    missionParametersDetailsInstance.targetLine = racksideRight.ToString();
                                    missionParametersDetailsInstance.targetFloor = startTargetFloorId.ToString();
                                    missionParametersDetailsInstance.targetDepthOfLine = infeedAndOutfeedDepth.ToString();



                                    missionParametersDetailsInstance.Sender = "WMS1";
                                    missionParametersDetailsInstance.Receiver = "PLC1";
                                    missionParametersDetailsInstance.Handshake = "RQ";
                                    missionParametersDetailsInstance.Teletype = "NEWM";
                                    missionParametersDetailsInstance.Error = "000000";
                                    string missionString = ConvertMissionParametersToString(missionParametersDetailsInstance);
                                    Log.Debug("missionString :: " + missionString);

                                    MissionParametersDetails missionDetails = ParseMissionString(missionString);
                                    giveMissionToStacker(missionString);
                                }
                                catch (Exception ex)
                                {
                                    Log.Error("startOperation :: Exception occured while setting outfeed mission values :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.Error("startOperation :: Exception occured while checking position details :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                        }
                    }
                    else
                    {
                        ats_wms_check_a1_mission_detailsTableAdapterInstance.UpdateIS_CHECKEDWhereA1_MISSION_DETAILS_ID(0, checkId);
                    }
                }
                catch (Exception ex)
                {
                    Log.Error("startOperation :: Exception occured while stopping timer :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                }
            }

            else if (missionType == "TRANSFER")
            {
                Log.Debug("13 missionType :: " + missionType);
                try
                {
                    ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT = ats_wms_transfer_pallet_mission_runtime_detailsTableAdapterInstance.GetDataByPALLET_INFORMATION_IDAndTRANSFER_MISSION_STATUSAndAREA_ID(palletInformationId, "READY", areaId);

                    if (ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT != null && ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT.Count > 0)
                    {
                        Log.Debug("13.1");
                        ats_wms_check_a1_mission_detailsTableAdapterInstance.UpdateIS_CHECKEDWhereA1_MISSION_DETAILS_ID(1, checkId);
                        try
                        {
                            PositionActiveDetails positionActiveDetailsInstance = new PositionActiveDetails();

                            if (positionActiveDetailsInstance.isFloorTransferActive(ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT[0].FLOOR_ID, areaId) &&
                                positionActiveDetailsInstance.isPositionActive(ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT[0].TRANSFER_POSITION_ID) &&
                                positionActiveDetailsInstance.isRackActive(ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT[0].RACK_ID))
                            {
                                Log.Debug("13.2");
                                try
                                {
                                    //fetch rack column

                                    ats_wms_master_position_detailsDataTablePrevTRDT = ats_wms_master_position_detailsTableAdapterInstance.GetDataByPOSITION_ID(ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT[0].PREVIOUS_POSITION_ID);
                                    ats_wms_master_rack_detailsDataTablePrevTRDT = ats_wms_master_rack_detailsTableAdapterInstance.GetDataByRACK_ID(ats_wms_master_position_detailsDataTablePrevTRDT[0].RACK_ID);



                                    MissionParametersDetails missionParametersDetailsInstance = new MissionParametersDetails();
                                    missionParametersDetailsInstance.missionId = ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT[0].TRANSFER_PALLET_MISSION_RUNTIME_DETAILS_ID.ToString();
                                    missionParametersDetailsInstance.taskType = transferTaskType.ToString();
                                    missionParametersDetailsInstance.startColumn = ats_wms_master_rack_detailsDataTablePrevTRDT[0].RACK_COLUMN.ToString();
                                    missionParametersDetailsInstance.startFloor = ats_wms_master_position_detailsDataTablePrevTRDT[0].FLOOR_ID.ToString();
                                    if (ats_wms_master_rack_detailsDataTablePrevTRDT[0].RACK_SIDE == "L")
                                    {
                                        missionParametersDetailsInstance.startLine = racksideLeft.ToString();
                                    }
                                    else if (ats_wms_master_rack_detailsDataTablePrevTRDT[0].RACK_SIDE == "R")
                                    {
                                        missionParametersDetailsInstance.startLine = racksideRight.ToString();
                                    }
                                    missionParametersDetailsInstance.startDepthOfLine = ats_wms_master_position_detailsDataTablePrevTRDT[0].POSITION_NUMBER_IN_RACK.ToString();
                                    missionParametersDetailsInstance.targetColumn = ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT[0].RACK_COLUMN.ToString();
                                    if (ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT[0].RACK_SIDE == "L")
                                    {
                                        missionParametersDetailsInstance.targetLine = racksideLeft.ToString();
                                    }
                                    else if (ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT[0].RACK_SIDE == "R")
                                    {
                                        missionParametersDetailsInstance.targetLine = racksideRight.ToString();
                                    }
                                    missionParametersDetailsInstance.targetFloor = ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT[0].FLOOR_ID.ToString();
                                    missionParametersDetailsInstance.targetDepthOfLine = ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT[0].POSITION_NUMBER_IN_RACK.ToString();


                                    missionParametersDetailsInstance.Sender = "WMS1";
                                    missionParametersDetailsInstance.Receiver = "PLC1";
                                    missionParametersDetailsInstance.Handshake = "RQ";
                                    missionParametersDetailsInstance.Teletype = "NEWM";
                                    missionParametersDetailsInstance.Error = "000000";

                                    string missionString = ConvertMissionParametersToString(missionParametersDetailsInstance);
                                    Log.Debug("missionString :: " + missionString);

                                    MissionParametersDetails missionDetails = ParseMissionString(missionString);
                                    giveMissionToStacker(missionString);
                                }
                                catch (Exception ex)
                                {
                                    Log.Error("startOperation :: Exception occured while setting transfer mission values :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.Error("startOperation :: Exception occured while checking position details :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                        }
                    }
                    else
                    {
                        ats_wms_check_a1_mission_detailsTableAdapterInstance.UpdateIS_CHECKEDWhereA1_MISSION_DETAILS_ID(0, checkId);
                    }
                }
                catch (Exception ex)
                {
                    Log.Error("startOperation :: Exception occured while stopping timer :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                }
            }
        }


        public void giveMissionToStacker(string missionString)
        {

            if (isMissionInProgress(areaId) == false)
            {
                try
                {
                    writeTag("ATS.AREA1.WNEWM", missionString);
                }
                catch (Exception ex)
                {
                    Log.Error("startOperation :: Exception occured while writting mission string in PLC :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                }


                Log.Debug("Checking AK string for any error :: ");
                if (checkErrorInPLCAK() == false)
                {

                    MissionParametersDetails missionDetails = ParseMissionString(missionString);

                    Log.Debug("missionId :: " + Convert.ToInt32(missionDetails.missionId));

                    Log.Debug("taskType :: " + Convert.ToInt32(missionDetails.taskType));

                    try
                    {
                        //Changing status of mission to IN_PROGRESS in DB
                        String timeNow = DateTime.Now.TimeOfDay.ToString();
                        TimeSpan currentTimeNow = TimeSpan.Parse(timeNow);

                        String currentDate = "";
                        currentDate = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                        if (missionDetails.taskType == "1")
                        {
                            try
                            {
                                Log.Debug("giveMissionToStacker :: Updating Mission Status to IN_PROGRESS");
                                //Updating the mission status by sending infeed mission ID
                                ats_wms_infeed_mission_runtime_detailsTableAdapterInstance.UpdateINFEED_MISSION_STATUSAndINFEED_MISSION_START_DATETIMEWhereINFEED_MISSION_ID("IN_PROGRESS", (currentDate + " " + currentTimeNow), Convert.ToInt32(missionDetails.missionId));
                                Log.Debug("GiveStackerMission :: giveMissionToStacker :: Status Updated to IN_PROGRESS for infeed mission ID :: " + ats_wms_infeed_mission_runtime_detailsDataTableDT[0].INFEED_MISSION_ID);
                            }
                            catch (Exception ex)
                            {
                                Log.Error("GiveStackerMission :: giveMissionToStacker :: Error While updating the status of the infeed mission to IN_PROGRESS. " + ex.Message + " stackTrace :: " + ex.StackTrace);
                            }
                        }
                        else if (missionDetails.taskType == "2")
                        {
                            try
                            {
                                //Updating the mission status by sending outfeed mission ID
                                ats_wms_outfeed_mission_runtime_detailsTableAdapterInstance.UpdateOUTFEED_MISSION_STATUSAndOUTFEED_MISSION_START_DATETIMEWhereOUTFEED_MISSION_ID((currentDate + " " + currentTimeNow), "IN_PROGRESS", Convert.ToInt32(missionDetails.missionId));

                                Log.Debug("GiveStackerMission :: giveMissionToStacker :: Status Updated to IN_PROGRESS for outfeed mission ID :: " + ats_wms_outfeed_mission_runtime_detailsDataTableDT[0].OUTFEED_MISSION_ID);
                            }
                            catch (Exception ex)
                            {
                                Log.Error("GiveStackerMission :: giveMissionToStacker :: Error While updating the status of the mission to IN_PROGRESS. " + ex.Message + " stackTrace :: " + ex.StackTrace);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Log.Error("GiveStackerMission :: giveMissionToStacker :: Error While updating mission status to inprogress. " + ex.Message + " stackTrace :: " + ex.StackTrace);
                    }





                    for (;;)
                    {
                        Thread.Sleep(300);
                        //reading stacker data request from the plc tag
                        try
                        {

                            //Fetching tag details from DB by sending Decision point tags name as AREA_1_STACKER_1_DATA_REQUEST
                            ats_wms_master_decision_point_direction_detailsDataTableDataRequestDT = ats_wms_master_decision_point_direction_detailsTableAdapterInstance.GetDataByDECISION_POINT_NAME("AREA_1_STACKER_1_DATA_REQUEST");
                            if (ats_wms_master_decision_point_direction_detailsDataTableDataRequestDT != null && ats_wms_master_decision_point_direction_detailsDataTableDataRequestDT.Count > 0)
                            {
                                Log.Debug("giveMissionToStacker :: Found Data Request Tag :: waiting to become false");
                                //Reading and checking of the plc tag value(true = data request high and false = no data request)
                                if (readTag(ats_wms_master_decision_point_direction_detailsDataTableDataRequestDT[0].DECISION_POINT_DIRECTION_TAG_NAME).Equals("False"))
                                {

                                    try
                                    {
                                        Log.Debug("giveMissionToStacker :: going in ReadMissionFeedbackDetails");
                                        //Calling a method ReadMissionFeedbackDetails by sending infeed mission data
                                        ReadMissionFeedbackDetails(missionString);
                                        Log.Debug("Tags Flushed");
                                    }
                                    catch (Exception ex)
                                    {
                                        Log.Error("GiveStackerMission :: giveMissionToStacker :: Error While Getting ReadMissionFeedbackDetails" + ex.Message + " stackTrace :: " + ex.StackTrace);
                                    }

                                    Log.Debug("ReadMissionFeedbackDetails done");

                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.Error("GiveStackerMission :: giveMissionToStacker :: Error While Getting Stacker Data Request." + ex.Message + " stackTrace :: " + ex.StackTrace);
                        }
                    }
                }
                else
                {
                    writeTag("ATS.AREA1.PNEWM", "0");
                }
            }




        }



        public void ReadMissionFeedbackDetails(string missionString)
        {
            try
            {
                for (;;)
                {

                    Log.Debug("READING missionStringAK");

                    string missionStringAK = (readTag("ATS.AREA1.PNEWM"));

                    Log.Debug("missionStringAK :: " + missionStringAK);

                    MissionParametersDetails missionDetailsAK = ParseMissionString(missionStringAK);

                    Log.Debug("missionIdAk :: " + Convert.ToInt32(missionDetailsAK.missionId));

                    string senderAK = missionDetailsAK.Sender;
                    Log.Debug("senderAK :: " + senderAK);

                    string receiverAK = missionDetailsAK.Receiver;
                    Log.Debug("receiverAK :: " + receiverAK);

                    string handshakeAK = missionDetailsAK.Handshake;
                    Log.Debug("handshakeAK :: " + handshakeAK);

                    string teletypeAK = missionDetailsAK.Teletype;
                    Log.Debug("teletypeAK :: " + teletypeAK);

                    string startLineAK = missionDetailsAK.startLine;
                    Log.Debug("startLineAK :: " + startLineAK);

                    string startFloorAK = missionDetailsAK.startFloor;
                    Log.Debug("startFloorAK :: " + startFloorAK);

                    string startDepthOfLineAK = missionDetailsAK.startDepthOfLine;
                    Log.Debug("startDepthOfLineAK :: " + startDepthOfLineAK);

                    string startColumnAK = missionDetailsAK.startColumn;
                    Log.Debug("startColumnAK :: " + startColumnAK);

                    string targetLineAK = missionDetailsAK.targetLine;
                    Log.Debug("targetLineAK :: " + targetLineAK);

                    string targetFloorAK = missionDetailsAK.targetFloor;
                    Log.Debug("targetFloorAK :: " + targetFloorAK);

                    string targetDepthOfLineAK = missionDetailsAK.targetDepthOfLine;
                    Log.Debug("targetDepthOfLineAK :: " + targetDepthOfLineAK);

                    string targetColumnAK = missionDetailsAK.targetColumn;
                    Log.Debug("targetColumnAK :: " + targetColumnAK);

                    string taskTypeAK = missionDetailsAK.taskType;
                    Log.Debug("taskTypeAK :: " + Convert.ToInt32(taskTypeAK));

                    string missionIdAK = missionDetailsAK.missionId;
                    Log.Debug("missionIdAK :: " + missionIdAK);

                    int missionID = Convert.ToInt32(missionDetailsAK.missionId);


                    string errorAK = missionDetailsAK.Error;
                    Log.Debug("errorAK :: " + errorAK);

                    string Ack = missionDetailsAK.Handshake;

                    Log.Debug("missionDetailsAK :: Handshake :: " + missionDetailsAK.Handshake);


                    MissionParametersDetails missionDetailsRQ = ParseMissionString(missionString);

                    string senderRQ = missionDetailsRQ.Sender;
                    Log.Debug("senderRQ :: " + senderRQ);

                    string receiverRQ = missionDetailsRQ.Receiver;
                    Log.Debug("receiverRQ :: " + receiverRQ);

                    string handshakeRQ = missionDetailsRQ.Handshake;
                    Log.Debug("handshakeRQ :: " + handshakeRQ);

                    string teletypeRQ = missionDetailsRQ.Teletype;
                    Log.Debug("teletypeRQ :: " + teletypeRQ);

                    string startLineRQ = missionDetailsRQ.startLine;
                    Log.Debug("startLineRQ :: " + startLineRQ);

                    string startFloorRQ = missionDetailsRQ.startFloor;
                    Log.Debug("startFloorRQ :: " + startFloorRQ);

                    string startDepthOfLineRQ = missionDetailsRQ.startDepthOfLine;
                    Log.Debug("startDepthOfLineRQ :: " + startDepthOfLineRQ);

                    string startColumnRQ = missionDetailsRQ.startColumn;
                    Log.Debug("startColumnRQ :: " + startColumnRQ);

                    string targetLineRQ = missionDetailsRQ.targetLine;
                    Log.Debug("targetLineRQ :: " + targetLineRQ);

                    string targetFloorRQ = missionDetailsRQ.targetFloor;
                    Log.Debug("targetFloorRQ :: " + targetFloorRQ);

                    string targetDepthOfLineRQ = missionDetailsRQ.targetDepthOfLine;
                    Log.Debug("targetDepthOfLineRQ :: " + targetDepthOfLineRQ);

                    string targetColumnRQ = missionDetailsRQ.targetColumn;
                    Log.Debug("targetColumnRQ :: " + targetColumnRQ);

                    string taskTypeRQ = missionDetailsRQ.taskType;
                    Log.Debug("taskTypeRQ :: " + Convert.ToInt32(taskTypeRQ));

                    string missionIdRQ = missionDetailsRQ.missionId;
                    Log.Debug("missionIdRQ :: " + missionIdRQ);

                    string errorRQ = missionDetailsRQ.Error;
                    Log.Debug("errorRQ :: " + errorRQ);

                    bool exactMatch = missionStringAK.Length == 56 && Ack == "AK" && missionIdRQ == missionIdAK &&
                        missionDetailsRQ.Sender == missionDetailsAK.Receiver &&
                        missionDetailsRQ.Receiver == missionDetailsAK.Sender &&
                        missionDetailsRQ.Teletype == missionDetailsAK.Teletype &&
                        missionDetailsRQ.startLine == missionDetailsAK.startLine &&
                        missionDetailsRQ.startFloor == missionDetailsAK.startFloor &&
                        missionDetailsRQ.startDepthOfLine == missionDetailsAK.startDepthOfLine &&
                        missionDetailsRQ.startColumn == missionDetailsAK.startColumn &&
                        missionDetailsRQ.targetLine == missionDetailsAK.targetLine &&
                        missionDetailsRQ.targetFloor == missionDetailsAK.targetFloor &&
                        missionDetailsRQ.targetDepthOfLine == missionDetailsAK.targetDepthOfLine &&
                        missionDetailsRQ.targetColumn == missionDetailsAK.targetColumn &&
                        missionDetailsRQ.taskType == missionDetailsAK.taskType &&
                        missionDetailsRQ.missionId == missionDetailsAK.missionId;
                    if (exactMatch)
                    {
                        //writeTag("ATS.PACK_AREA1.WNEWM", "00000000000000000000000000000000000000000000000000000000");

                        writeTag("ATS.AREA1.PNEWM", "00000000000000000000000000000000000000000000000000000000");
                        Log.Debug("ATS.AREA1.PNEWM ::" + "00000000000000000000000000000000000000000000000000000000");
                        Log.Debug("ReadMissionFeedBackDetails::Erasing missionString Tag");
                        if (readTag("ATS.AREA1.PNEWM").Equals("00000000000000000000000000000000000000000000000000000000"))
                        {
                            Log.Debug("PNEWM IS ZERO");
                            break;
                        }
                    }
                    else if (IsMissionAlreadyInProgress(missionDetailsAK.missionId))
                    {
                        Log.Warn("Stale mission data found in PNEWM, clearing tag");
                        writeTag("ATS.AREA1.PNEWM", "00000000000000000000000000000000000000000000000000000000");

                        if (readTag("ATS.AREA1.PNEWM") == "00000000000000000000000000000000000000000000000000000000")
                        {
                            break;
                        }
                    }
                    Thread.Sleep(200);
                }

            }
            catch (Exception ex)
            {
                Log.Error("ReadMissionFeedbackDetails :: Exception while reading column" + ex.Message + " Stacktrace:: " + ex.StackTrace);
            }

        }

        #region IsMissionAlreadyInProgress
        private bool IsMissionAlreadyInProgress(string missionId)
        {
            // Query your DB or service cache to check if this mission ID is already in progress
            // Example:
            var missionStatus = GetMissionStatusFromDB(missionId); // implement this
            return missionStatus == "IN_PROGRESS";
        }
        #endregion

        #region string conversion
        public static string PadLeftWithZeros(string input, int totalLength)
        {
            return input.PadLeft(totalLength, '0');
        }


        public static string ConvertMissionParametersToString(MissionParametersDetails missionDetails)
        {
            return
                PadLeftWithZeros(missionDetails.Sender, 4) +
                PadLeftWithZeros(missionDetails.Receiver, 4) +
                PadLeftWithZeros(missionDetails.Handshake, 2) +
                PadLeftWithZeros(missionDetails.Teletype, 4) +
                PadLeftWithZeros(missionDetails.startLine, 2) +
                PadLeftWithZeros(missionDetails.startFloor, 2) +
                PadLeftWithZeros(missionDetails.startDepthOfLine, 2) +
                PadLeftWithZeros(missionDetails.startColumn, 4) +
                PadLeftWithZeros(missionDetails.targetLine, 2) +
                PadLeftWithZeros(missionDetails.targetFloor, 2) +
                PadLeftWithZeros(missionDetails.targetDepthOfLine, 2) +
                PadLeftWithZeros(missionDetails.targetColumn, 4) +
                PadLeftWithZeros(missionDetails.taskType, 2) +
                PadLeftWithZeros(missionDetails.missionId, 14) +
                PadLeftWithZeros(missionDetails.Error, 6);
        }


        //public static MissionParametersDetails ParseMissionString(string missionString)
        //{
        //    int[] lengths = { 4, 4, 2, 4, 2, 2, 2, 4, 2, 2, 2, 4, 2, 14, 6 };
        //    string[] values = new string[lengths.Length];

        //    int pos = 0;
        //    for (int i = 0; i < lengths.Length; i++)
        //    {
        //        string raw = missionString.Substring(pos, lengths[i]);
        //        pos += lengths[i];

        //        // Keep strings as-is for string fields (first 4)
        //        if (i <= 3) // Sender, Receiver, Handshake, Teletype
        //        {
        //            values[i] = raw;
        //        }
        //        else
        //        {
        //            int parsed;
        //            // Parse to int and back to string to remove padding only
        //            if (int.TryParse(raw, out parsed))
        //                values[i] = parsed.ToString();
        //            else
        //                values[i] = "0"; // fallback if parsing fails
        //        }
        //    }

        //    return new MissionParametersDetails
        //    {
        //        Sender = values[0],
        //        Receiver = values[1],
        //        Handshake = values[2],
        //        Teletype = values[3],
        //        startLine = values[4],
        //        startFloor = values[5],
        //        startDepthOfLine = values[6],
        //        startColumn = values[7],
        //        targetLine = values[8],
        //        targetFloor = values[9],
        //        targetDepthOfLine = values[10],
        //        targetColumn = values[11],
        //        taskType = values[12],
        //        missionId = values[13],
        //        Error = values[14]
        //    };
        //}

        public static MissionParametersDetails ParseMissionString(string missionString)
        {
            // Total 56 characters
            int[] lengths = { 4, 4, 2, 4, 2, 2, 2, 4, 2, 2, 2, 4, 2, 14, 6 };
            string[] values = new string[lengths.Length];

            int pos = 0;

            for (int i = 0; i < lengths.Length; i++)
            {
                string raw = missionString.Substring(pos, lengths[i]);
                pos += lengths[i];

                if (i <= 3 || i >= 13) // keep as string for Sender, Receiver, Handshake, Teletype, MissionId, Error
                {
                    values[i] = raw;
                }
                else
                {
                    int parsed;
                    if (int.TryParse(raw, out parsed))
                        values[i] = parsed.ToString();
                    else
                        values[i] = "0";
                }
            }

            return new MissionParametersDetails
            {
                Sender = values[0],
                Receiver = values[1],
                Handshake = values[2],
                Teletype = values[3],
                startLine = values[4],
                startFloor = values[5],
                startDepthOfLine = values[6],
                startColumn = values[7],
                targetLine = values[8],
                targetFloor = values[9],
                targetDepthOfLine = values[10],
                targetColumn = values[11],
                taskType = values[12],
                missionId = values[13],
                Error = values[14]
            };
        }


        #endregion

        #region GetMissionStatusFromDB
        private string GetMissionStatusFromDB(string missionId)
        {
            try
            {
                ats_wms_outfeed_mission_runtime_detailsDataTableDT = ats_wms_outfeed_mission_runtime_detailsTableAdapterInstance.GetStatusByMissionId(Convert.ToInt32(missionId));
                if (ats_wms_outfeed_mission_runtime_detailsDataTableDT != null && ats_wms_outfeed_mission_runtime_detailsDataTableDT.Count > 0)
                {
                    return ats_wms_outfeed_mission_runtime_detailsDataTableDT[0].OUTFEED_MISSION_STATUS.ToString();
                }
                ats_wms_infeed_mission_runtime_detailsDataTableDT = ats_wms_infeed_mission_runtime_detailsTableAdapterInstance.GetStatusByMissionId(Convert.ToInt32(missionId));
                if (ats_wms_infeed_mission_runtime_detailsDataTableDT != null && ats_wms_infeed_mission_runtime_detailsDataTableDT.Count > 0)
                {
                    return ats_wms_infeed_mission_runtime_detailsDataTableDT[0].INFEED_MISSION_STATUS.ToString();
                }


                else
                {
                    Log.Debug("No mission found for missionId: " + missionId);
                    return "";
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error in GetMissionStatusFromDB :: " + ex.Message);
                return "";
            }
        }
        #endregion

        #region Ping funcationality

        public Boolean checkPlcPingRequest()
        {
            //Log.Debug("IprodPLCMachineXmlGenOperation :: Inside checkServerPingRequest");

            try
            {
                try
                {
                    pingSenderForThisConnection = new Ping();
                    replyForThisConnection = pingSenderForThisConnection.Send(IP_ADDRESS);
                }
                catch (Exception ex)
                {
                    Log.Error("checkPlcPingRequest :: for IP :: " + IP_ADDRESS + " Exception occured while sending ping request :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                    replyForThisConnection = null;
                }

                if (replyForThisConnection != null && replyForThisConnection.Status == IPStatus.Success)
                {
                    //Log.Debug("checkPlcPingRequest :: for IP :: " + IP_ADDRESS + " Ping success :: " + replyForThisConnection.Status.ToString());
                    return true;
                }
                else
                {
                    //Log.Debug("checkPlcPingRequest :: for IP :: " + IP_ADDRESS + " Ping failed. ");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Log.Error("checkPlcPingRequest :: for IP :: " + IP_ADDRESS + " Exception while checking ping request :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                return false;
            }
        }

        #endregion
        #region ErrorHandling (OCCUPI & INVALI)

        public Boolean checkErrorInPLCAK()
        {
            Log.Debug("IN checkErrorInPLCAK");

            for (;;)
            {
                Thread.Sleep(500);
                Log.Debug("checkErrorInPLCAK :: READING missionStringAK");
                string missionStringAK = (readTag("ATS.AREA1.PNEWM"));

                if (missionStringAK != "" && missionStringAK != "0" && missionStringAK != "00000000000000000000000000000000000000000000000000000000" && missionStringAK != "PLC1WMS1AKNEWM000000000000000000000000000000000000OCCUPI" && missionStringAK != "PLC1WMS1AKNEWM000000000000000000000000000000000000ABORTT"
                    && missionStringAK != "PLC1WMS1AKNEWM000000000000000000000000000000000000INVALI")
                {

                    Log.Debug("checkErrorInPLCAK :: missionStringAK :: " + missionStringAK);

                    MissionParametersDetails missionDetailsAK = ParseMissionString(missionStringAK);

                    Log.Debug("checkErrorInPLCAK :: missionIdAk :: " + Convert.ToInt32(missionDetailsAK.missionId));

                    string senderAK = missionDetailsAK.Sender;
                    Log.Debug("checkErrorInPLCAK :: senderAK :: " + senderAK);

                    string receiverAK = missionDetailsAK.Receiver;
                    Log.Debug("checkErrorInPLCAK :: receiverAK :: " + receiverAK);

                    string handshakeAK = missionDetailsAK.Handshake;
                    Log.Debug("checkErrorInPLCAK :: handshakeAK :: " + handshakeAK);

                    string teletypeAK = missionDetailsAK.Teletype;
                    Log.Debug("checkErrorInPLCAK :: teletypeAK :: " + teletypeAK);

                    string startLineAK = missionDetailsAK.startLine;
                    Log.Debug("checkErrorInPLCAK :: startLineAK :: " + startLineAK);

                    string startFloorAK = missionDetailsAK.startFloor;
                    Log.Debug("checkErrorInPLCAK :: startFloorAK :: " + startFloorAK);

                    string startDepthOfLineAK = missionDetailsAK.startDepthOfLine;
                    Log.Debug("checkErrorInPLCAK :: startDepthOfLineAK :: " + startDepthOfLineAK);

                    string startColumnAK = missionDetailsAK.startColumn;
                    Log.Debug("checkErrorInPLCAK :: startColumnAK :: " + startColumnAK);

                    string targetLineAK = missionDetailsAK.targetLine;
                    Log.Debug("checkErrorInPLCAK :: targetLineAK :: " + targetLineAK);

                    string targetFloorAK = missionDetailsAK.targetFloor;
                    Log.Debug("checkErrorInPLCAK :: targetFloorAK :: " + targetFloorAK);

                    string targetDepthOfLineAK = missionDetailsAK.targetDepthOfLine;
                    Log.Debug("checkErrorInPLCAK :: targetDepthOfLineAK :: " + targetDepthOfLineAK);

                    string targetColumnAK = missionDetailsAK.targetColumn;
                    Log.Debug("checkErrorInPLCAK :: targetColumnAK :: " + targetColumnAK);

                    string taskTypeAK = missionDetailsAK.taskType;
                    Log.Debug("checkErrorInPLCAK :: taskTypeAK :: " + Convert.ToInt32(taskTypeAK));

                    string missionIdAK = missionDetailsAK.missionId;
                    Log.Debug("checkErrorInPLCAK :: missionIdAK :: " + missionIdAK);

                    int missionID = Convert.ToInt32(missionDetailsAK.missionId);


                    string errorAK = missionDetailsAK.Error;
                    Log.Debug("checkErrorInPLCAK :: errorAK :: " + errorAK);




                    //string error = missionDetailsAK.Error;

                    if (errorAK == "OCCUPI")
                    {
                        Log.Debug("checkErrorInPLCAK :: Mission rejected due to OCCUPI - Cell is not healthy or already occupied.");

                        updateMissionDetailsForOccupancyError(missionIdAK, taskTypeAK);

                        Log.Debug("checkErrorInPLCAK :: Erasing missionString Tag :: ERROR :: OCCUPI");
                        writeTag("ATS.AREA1.PNEWM", "00000000000000000000000000000000000000000000000000000000");
                        if (readTag("ATS.AREA1.PNEWM").Equals("00000000000000000000000000000000000000000000000000000000"))
                        {
                            Log.Debug("checkErrorInPLCAK :: PNEWM IS ZERO");
                            break;
                        }

                    }
                    else if (errorAK == "INVALI")
                    {
                        Log.Error("checkErrorInPLCAK :: Mission string invalid - INVALI error received. Possible parameter issue.");

                        updateMissionDetailsForInvalidStringError(missionIdAK, taskTypeAK);

                        Log.Debug("checkErrorInPLCAK::Erasing missionString Tag :: ERROR :: INVALI");
                        writeTag("ATS.AREA1.PNEWM", "00000000000000000000000000000000000000000000000000000000");
                        if (readTag("ATS.AREA1.PNEWM").Equals("00000000000000000000000000000000000000000000000000000000"))
                        {
                            Log.Debug("checkErrorInPLCAK :: PNEWM IS ZERO");
                            break;
                        }
                    }
                    else if (errorAK == "ABORTT")
                    {
                        Log.Error("checkErrorInPLCAK :: Mission string ABORT - ABORT error received. Possible parameter issue.");

                        updateMissionDetailsForAbortError(missionIdAK, taskTypeAK);

                        Log.Debug("checkErrorInPLCAK::Erasing missionString Tag :: ERROR :: ABORT");
                        writeTag("ATS.AREA1.PNEWM", "00000000000000000000000000000000000000000000000000000000");
                        if (readTag("ATS.AREA1.PNEWM").Equals("00000000000000000000000000000000000000000000000000000000"))
                        {
                            Log.Debug("checkErrorInPLCAK :: PNEWM IS ZERO");
                            break;
                        }
                    }
                    else
                    {
                        Log.Debug("checkErrorInPLCAK :: No error in the ACK string");
                        return false;
                    }
                }
            }


            return true;
        }

        public void updateMissionDetailsForOccupancyError(string missionIdAK, string taskTypeAK)
        {
            Log.Debug("updateMissionDetailsForOccupancyError :: for missionIdAK :: " + missionIdAK + " :: Task Type :: " + taskTypeAK);
            int missionIdInt = Convert.ToInt32(missionIdAK);
            Log.Debug("missionIdInt :: " + missionIdInt);

            int TaskTypeInt = Convert.ToInt32(taskTypeAK);
            Log.Debug("TaskTypeInt :: " + TaskTypeInt);
            if (TaskTypeInt == 1 && missionIdInt != 0)
            {
                Log.Debug("updateMissionDetailsForOccupancyError :: Checking for infeed mission");
                ats_wms_infeed_mission_runtime_detailsDataTableDT = ats_wms_infeed_mission_runtime_detailsTableAdapterInstance.GetDataByINFEED_MISSION_ID(missionIdInt);
                if (ats_wms_infeed_mission_runtime_detailsDataTableDT != null && ats_wms_infeed_mission_runtime_detailsDataTableDT.Count > 0)
                {
                    Log.Debug("updateMissionDetailsForOccupancyError :: Updating infeed mission status ABORT");
                    //Update infeed mission status
                    ats_wms_infeed_mission_runtime_detailsTableAdapterInstance.UpdateINFEED_MISSION_STATUSAndINFEED_MISSION_START_DATETIMEWhereINFEED_MISSION_ID("ABORT", DateTime.Now.ToString(), missionIdInt);


                    Log.Debug("updateMissionDetailsForOccupancyError :: update position details in master position");
                    //update position details in master position WHEN WE ABORT HE MISSION 
                    ats_wms_master_position_detailsTableAdapterInstance.UpdatePOSITION_IS_ACTIVEwherePOSITION_ID(0, ats_wms_infeed_mission_runtime_detailsDataTableDT[0].POSITION_ID);
                    // ats_wms_master_position_detailsTableAdapterInstance.UpdatePOSITION_IS_ALLOCATEDWherePOSITION_ID(0, ats_wms_infeed_mission_runtime_detailsDataTableDT[0].POSITION_ID);


                    Log.Debug("updateMissionDetailsForOccupancyError :: update master pallet information details");
                    //update master pallet information details
                    ats_wms_master_pallet_informationTableAdapterInstance.UpdateIS_INFEED_MISSION_GENERATEDWherePALLET_INFORMATION_ID(0, ats_wms_infeed_mission_runtime_detailsDataTableDT[0].PALLET_INFORMATION_ID);

                }
                else
                {
                    Log.Debug("Infeed mission not found");
                }

            }

            if (TaskTypeInt == 2 && missionIdInt != 0)
            {
                Log.Debug("updateMissionDetailsForOccupancyError :: Checking for outfeed mission");
                ats_wms_outfeed_mission_runtime_detailsDataTableDT = ats_wms_outfeed_mission_runtime_detailsTableAdapterInstance.GetDataByOUTFEED_MISSION_ID(missionIdInt);
                if (ats_wms_outfeed_mission_runtime_detailsDataTableDT != null && ats_wms_outfeed_mission_runtime_detailsDataTableDT.Count > 0)
                {
                    Log.Debug("updateMissionDetailsForOccupancyError :: Updating outfeed mission status ABORT");
                    //Update outfeed mission status
                    ats_wms_outfeed_mission_runtime_detailsTableAdapterInstance.UpdateOUTFEED_MISSION_STATUSAndOUTFEED_MISSION_START_DATETIMEWhereOUTFEED_MISSION_ID("ABORT", DateTime.Now.ToString(), missionIdInt);

                    Log.Debug("updateMissionDetailsForOccupancyError :: update position details in master position");
                    //update position details in master position
                    ats_wms_master_position_detailsTableAdapterInstance.UpdatePOSITION_IS_ACTIVEwherePOSITION_ID(0, ats_wms_outfeed_mission_runtime_detailsDataTableDT[0].POSITION_ID);
                    ats_wms_master_position_detailsTableAdapterInstance.UpdateIS_MANUAL_DISPATCHWherePOSITION_ID(0, ats_wms_outfeed_mission_runtime_detailsDataTableDT[0].POSITION_ID);

                    Log.Debug("updateMissionDetailsForOccupancyError :: update master pallet information details");
                    //update master pallet information details
                    ats_wms_master_pallet_informationTableAdapterInstance.UpdateIS_OUTFEED_MISSION_GENERATEDWherePALLET_INFORMATION_ID(0, ats_wms_outfeed_mission_runtime_detailsDataTableDT[0].PALLET_INFORMATION_ID);
                }
                else
                {
                    Log.Debug("Outfeed mission not found");
                }

            }
            if (TaskTypeInt == 3 && missionIdInt != 0)
            {
                Log.Debug("updateMissionDetailsForOccupancyError :: Checking for transfer mission ABORT");

                try
                {
                    ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT = ats_wms_transfer_pallet_mission_runtime_detailsTableAdapterInstance.GetDataByTRANSFER_PALLET_MISSION_RUNTIME_DETAILS_ID(missionIdInt);


                    if (ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT != null && ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT.Count > 0)
                    {
                        try
                        {
                            Log.Debug("updateMissionDetailsForOccupancyError :: Updating transfer mission status");
                            //Update transfer mission status
                            ats_wms_transfer_pallet_mission_runtime_detailsTableAdapterInstance.UpdateTRANSFER_MISSION_START_DATETIMEAndTRANSFER_MISSION_STATUSWhereTRANSFER_PALLET_MISSION_RUNTIME_DETAILS_ID("ABORT", DateTime.Now.ToString(), missionIdInt);
                        }
                        catch (Exception ex)
                        {
                            Log.Error("updateMissionDetailsForOccupancyError :: while updating the mission status :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                        }


                        try
                        {
                            Log.Debug("updateMissionDetailsForOccupancyError :: update position details in master position");
                            //update position details in master position
                            ats_wms_master_position_detailsTableAdapterInstance.UpdatePOSITION_IS_ACTIVEwherePOSITION_ID(0, ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT[0].PREVIOUS_POSITION_ID);
                            ats_wms_master_position_detailsTableAdapterInstance.UpdatePOSITION_IS_ACTIVEwherePOSITION_ID(0, ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT[0].TRANSFER_POSITION_ID);
                            //ats_wms_master_position_detailsTableAdapterInstance.UpdatePOSITION_IS_ALLOCATEDWherePOSITION_ID(0, ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT[0].TRANSFER_POSITION_ID);
                        }
                        catch (Exception ex)
                        {
                            Log.Error("updateMissionDetailsForOccupancyError :: while updating the position details :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                        }

                        try
                        {
                            Log.Debug("updateMissionDetailsForOccupancyError :: update master pallet information details");
                            //update master pallet information details
                            ats_wms_master_pallet_informationTableAdapterInstance.UpdateIS_TRANSFER_MANAGEMENT_MISSION_GENERATEDWherePALLET_INFORMATION_ID(0, ats_wms_transfer_pallet_mission_runtime_detailsDataTableDT[0].PALLET_INFORMTION_ID);

                        }
                        catch (Exception ex)
                        {
                            Log.Error("updateMissionDetailsForOccupancyError :: while updating the pallet information details :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                        }

                    }
                    else
                    {
                        Log.Debug("Transfer mission not found");
                    }
                }
                catch (Exception ex)
                {
                    Log.Error("updateMissionDetailsForOccupancyError :: while fetching mission details :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                }

            }
            else
            {
                Log.Debug("Mission type not found;");
            }

            
        }


        public void updateMissionDetailsForInvalidStringError(string missionIdAK, string taskTypeAK)
        {
            Log.Debug("updateMissionDetailsForInvalidStringError :: for missionIdAK :: " + missionIdAK + " :: Task Type :: " + taskTypeAK);
            int missionIdInt = Convert.ToInt32(missionIdAK);
            Log.Debug("missionIdInt :: " + missionIdInt);

            int TaskTypeInt = Convert.ToInt32(taskTypeAK);
            Log.Debug("TaskTypeInt :: " + TaskTypeInt);
            if (TaskTypeInt == 1 && missionIdInt != 0)
            {
                Log.Debug("updateMissionDetailsForInvalidStringError :: Checking for infeed mission");
                ats_wms_infeed_mission_runtime_detailsDataTableDT = ats_wms_infeed_mission_runtime_detailsTableAdapterInstance.GetDataByINFEED_MISSION_ID(missionIdInt);
                if (ats_wms_infeed_mission_runtime_detailsDataTableDT != null && ats_wms_infeed_mission_runtime_detailsDataTableDT.Count > 0)
                {
                    Log.Debug("updateMissionDetailsForInvalidStringError :: Updating infeed mission status READY");
                    //Update infeed mission status
                    ats_wms_infeed_mission_runtime_detailsTableAdapterInstance.UpdateINFEED_MISSION_STATUSAndINFEED_MISSION_START_DATETIMEWhereINFEED_MISSION_ID("READY", DateTime.Now.ToString(), missionIdInt);

                }
                else
                {
                    Log.Debug("Infeed mission not found");
                }
            }
            else if (TaskTypeInt == 2 && missionIdInt != 0)
            {
                Log.Debug("updateMissionDetailsForInvalidStringError :: Checking for outfeed mission");
                ats_wms_outfeed_mission_runtime_detailsDataTableDT = ats_wms_outfeed_mission_runtime_detailsTableAdapterInstance.GetDataByOUTFEED_MISSION_ID(missionIdInt);
                if (ats_wms_outfeed_mission_runtime_detailsDataTableDT != null && ats_wms_outfeed_mission_runtime_detailsDataTableDT.Count > 0)
                {
                    Log.Debug("updateMissionDetailsForInvalidStringError :: Updating outfeed mission status READY");
                    //Update outfeed mission status
                    ats_wms_outfeed_mission_runtime_detailsTableAdapterInstance.UpdateOUTFEED_MISSION_STATUSAndOUTFEED_MISSION_START_DATETIMEWhereOUTFEED_MISSION_ID(DateTime.Now.ToString(), "READY", missionIdInt);

                }
                else
                {
                    Log.Debug("Outfeed mission not found");
                }
            }

            else
            {
                Log.Debug("Mission type not found;");
            }
        }

        public void updateMissionDetailsForAbortError(string missionIdAK, string taskTypeAK)
        {
            Log.Debug("updateMissionDetailsForAbortError :: for missionIdAK :: " + missionIdAK + " :: Task Type :: " + taskTypeAK);
            int missionIdInt = Convert.ToInt32(missionIdAK);
            Log.Debug("missionIdInt :: " + missionIdInt);

            int TaskTypeInt = Convert.ToInt32(taskTypeAK);
            Log.Debug("TaskTypeInt :: " + TaskTypeInt);
            if (TaskTypeInt == 1 && missionIdInt != 0)
            {
                Log.Debug("updateMissionDetailsForAbortError :: Checking for infeed mission");
                ats_wms_infeed_mission_runtime_detailsDataTableDT = ats_wms_infeed_mission_runtime_detailsTableAdapterInstance.GetDataByINFEED_MISSION_ID(missionIdInt);
                if (ats_wms_infeed_mission_runtime_detailsDataTableDT != null && ats_wms_infeed_mission_runtime_detailsDataTableDT.Count > 0)
                {
                    Log.Debug("updateMissionDetailsForAbortError :: Updating infeed mission status ABORT");
                    //Update infeed mission status
                    ats_wms_infeed_mission_runtime_detailsTableAdapterInstance.UpdateINFEED_MISSION_STATUSAndINFEED_MISSION_START_DATETIMEWhereINFEED_MISSION_ID("ABORT", DateTime.Now.ToString(), missionIdInt);


                    Log.Debug("updateMissionDetailsForAbortError :: update position details in master position");
                    //update position details in master position
                    //ats_wms_master_position_detailsTableAdapterInstance.UpdateIS_DATA_MISMATCHWherePOSITION_ID(1, ats_wms_infeed_mission_runtime_detailsDataTableDT[0].POSITION_ID);
                    ats_wms_master_position_detailsTableAdapterInstance.UpdatePOSITION_IS_ALLOCATEDAndPOSITION_IS_EMPTYWherePOSITION_ID(0, 1, ats_wms_infeed_mission_runtime_detailsDataTableDT[0].POSITION_ID);


                    Log.Debug("updateMissionDetailsForAbortError :: update master pallet information details");
                    //update master pallet information details
                    ats_wms_master_pallet_informationTableAdapterInstance.UpdateIS_INFEED_MISSION_GENERATEDWherePALLET_INFORMATION_ID(0, ats_wms_infeed_mission_runtime_detailsDataTableDT[0].PALLET_INFORMATION_ID);

                }
                else
                {
                    Log.Debug("Infeed mission not found");
                }

            }

            if (TaskTypeInt == 2 && missionIdInt != 0)
            {
                Log.Debug("updateMissionDetailsForAbortError :: Checking for outfeed mission");
                ats_wms_outfeed_mission_runtime_detailsDataTableDT = ats_wms_outfeed_mission_runtime_detailsTableAdapterInstance.GetDataByOUTFEED_MISSION_ID(missionIdInt);
                if (ats_wms_outfeed_mission_runtime_detailsDataTableDT != null && ats_wms_outfeed_mission_runtime_detailsDataTableDT.Count > 0)
                {
                    Log.Debug("updateMissionDetailsForAbortError :: Updating outfeed mission status ABORT");
                    //Update outfeed mission status
                    ats_wms_outfeed_mission_runtime_detailsTableAdapterInstance.UpdateOUTFEED_MISSION_STATUSAndOUTFEED_MISSION_START_DATETIMEWhereOUTFEED_MISSION_ID(DateTime.Now.ToString(), "ABORT", missionIdInt);

                    Log.Debug("updateMissionDetailsForAbortError :: update position details in master position");
                    //update position details in master position
                    // ats_wms_master_position_detailsTableAdapterInstance.UpdateIS_DATA_MISMATCHWherePOSITION_ID(1, ats_wms_outfeed_mission_runtime_detailsDataTableDT[0].POSITION_ID);
                    ats_wms_master_position_detailsTableAdapterInstance.UpdateIS_MANUAL_DISPATCHWherePOSITION_ID(0, ats_wms_outfeed_mission_runtime_detailsDataTableDT[0].POSITION_ID);
                    ats_wms_master_position_detailsTableAdapterInstance.UpdatePOSITION_IS_ALLOCATEDAndPOSITION_IS_EMPTYWherePOSITION_ID(1, 0, ats_wms_outfeed_mission_runtime_detailsDataTableDT[0].POSITION_ID);
                    Log.Debug("updateMissionDetailsForAbortError :: update master pallet information details");
                    //update master pallet information details
                    ats_wms_master_pallet_informationTableAdapterInstance.UpdateIS_OUTFEED_MISSION_GENERATEDWherePALLET_INFORMATION_ID(0, ats_wms_outfeed_mission_runtime_detailsDataTableDT[0].PALLET_INFORMATION_ID);
                }
                else
                {
                    Log.Debug("Outfeed mission not found");
                }

            }


            else
            {
                Log.Debug("Mission type not found;");
            }
        }
        #endregion

        #region Read and Write PLC tag


        [HandleProcessCorruptedStateExceptions]
        public string readTag(string tagName)
        {

            try
            {
                //Log.Debug("IprodPLCCommunicationOperation :: Inside readTag.");

                // Set PLC tag
                OPCItemIDs.SetValue(tagName, 1);
                Log.Debug("readTag :: Plc tag is configured for plc group.");

                // remove all group
                ConnectedOpc.OPCGroups.RemoveAll();
                Log.Debug("readTag :: Remove all group.");

                // Kepware configuration                
                OpcGroupNames = ConnectedOpc.OPCGroups.Add("AtsWmsA1GiveMissionDetailsGroup");
                OpcGroupNames.DeadBand = 0;
                OpcGroupNames.UpdateRate = 100;
                OpcGroupNames.IsSubscribed = true;
                OpcGroupNames.IsActive = true;
                OpcGroupNames.OPCItems.AddItems(1, ref OPCItemIDs, ref ClientHandles, out ItemServerHandles, out ItemServerErrors, RequestedDataTypes, AccessPaths);
                Log.Debug("readTag :: Kepware properties configuration is complete.");

                // Read tag
                OpcGroupNames.SyncRead((short)OPCAutomation.OPCDataSource.OPCDevice, 1, ref
                   ItemServerHandles, out ItemServerValues, out ItemServerErrors, out aDIR, out bDIR);

                //Log.Debug("readTag ::  tag name :: " + tagName + " tag value :: " + Convert.ToString(ItemServerValues.GetValue(1)));

                if (Convert.ToString(ItemServerValues.GetValue(1)).Equals("True"))
                {
                    Log.Debug("readTag :: Found and Return True");
                    Log.Debug("readTag ::  tag name :: " + tagName + " tag value :: " + Convert.ToString(ItemServerValues.GetValue(1)));
                    // ConnectedOpc.OPCGroups.Remove("AtsWmsA1GiveMissionDetailsGroup");
                    return "True";
                }
                else if (Convert.ToString(ItemServerValues.GetValue(1)).Equals("False"))
                {
                    Log.Debug("readTag :: Found and Return False");
                    Log.Debug("readTag ::  tag name :: " + tagName + " tag value :: " + Convert.ToString(ItemServerValues.GetValue(1)));
                    // ConnectedOpc.OPCGroups.Remove("AtsWmsA1GiveMissionDetailsGroup");
                    return "False";
                }
                else
                {
                    Log.Debug("readTag ::  tag name :: " + tagName + " tag value :: " + Convert.ToString(ItemServerValues.GetValue(1)));
                    //ConnectedOpc.OPCGroups.Remove("AtsWmsA1GiveMissionDetailsGroup");
                    return Convert.ToString(ItemServerValues.GetValue(1));
                }

            }
            catch (Exception ex)
            {
                Log.Error("readTag :: Exception while reading plc tag :: " + tagName + " :: " + ex.Message);
                OnConnectPLC();
            }

            Log.Debug("readTag :: Return False.. retun null.");

            return "False";
        }

        [HandleProcessCorruptedStateExceptions]
        public void writeTag(string tagName, string tagValue)
        {

            try
            {
                Log.Debug("IprodGiveMissionToStacker :: Inside writeTag.");

                // Set PLC tag
                OPCItemIDs.SetValue(tagName, 1);
                //Log.Debug("writeTag :: Plc tag is configured for plc group.");

                // remove all group
                ConnectedOpc.OPCGroups.RemoveAll();
                //Log.Debug("writeTag :: Remove all group.");

                // Kepware configuration                  
                OpcGroupNames = ConnectedOpc.OPCGroups.Add("AtsWmsA1GiveMissionDetailsGroup");
                OpcGroupNames.DeadBand = 0;
                OpcGroupNames.UpdateRate = 100;
                OpcGroupNames.IsSubscribed = true;
                OpcGroupNames.IsActive = true;
                OpcGroupNames.OPCItems.AddItems(1, ref OPCItemIDs, ref ClientHandles, out ItemServerHandles, out ItemServerErrors, RequestedDataTypes, AccessPaths);
                //Log.Debug("writeTag :: Kepware properties configuration is complete.");

                // read plc tags
                OpcGroupNames.SyncRead((short)OPCAutomation.OPCDataSource.OPCDevice, 1, ref
                   ItemServerHandles, out ItemServerValues, out ItemServerErrors, out aDIR, out bDIR);

                // Add tag value
                ItemServerValues.SetValue(tagValue, 1);

                // Write tag
                OpcGroupNames.SyncWrite(1, ref ItemServerHandles, ref ItemServerValues, out ItemServerErrors);
                //ConnectedOpc.OPCGroups.Remove("AtsWmsA1GiveMissionDetailsGroup");
                //return true;

            }
            catch (Exception ex)
            {
                Log.Error("writeTag :: Exception while writing mission data in the plc tag :: " + tagName + " :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                OnConnectPLC();
                Thread.Sleep(1000);
                Log.Debug("Writting again :: tag name :: " + tagName);
                writeTag(tagName, tagValue);
            }

            //return false;

        }

        #endregion

        #region Connect and Disconnect PLC

        private void OnConnectPLC()
        {

            Log.Debug("OnConnectPLC :: inside OnConnectPLC");

            try
            {
                // Connection url
                if (!((ConnectedOpc.ServerState.ToString()).Equals("1")))
                {
                    ConnectedOpc.Connect(plcServerConnectionString, "");
                    Log.Debug("OnConnectPLC :: PLC connection successful and OPC server state is :: " + ConnectedOpc.ServerState.ToString());
                }
                else
                {
                    Log.Debug("OnConnectPLC :: Already connected with the plc.");
                }

            }
            catch (Exception ex)
            {
                Log.Error("OnConnectPLC :: Exception while connecting to plc :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
            }
        }

        private void OnDisconnectPLC()
        {
            Log.Debug("inside OnDisconnectPLC");

            try
            {
                ConnectedOpc.Disconnect();
                Log.Debug("OnDisconnectPLC :: Connection with the plc is disconnected.");
            }
            catch (Exception ex)
            {
                Log.Error("OnDisconnectPLC :: Exception while disconnecting to plc :: " + ex.Message);
            }

        }


        #endregion
    }
}
