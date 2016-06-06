﻿using SERVOSA.SAIR.DATAACCESS.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVOSA.SAIR.DATAACCESS.Models.Alerts;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SERVOSA.SAIR.DATAACCESS.Realizations
{
    public class DriverAlertRepository : IDriverVehicleAlertRepository
    {
        private readonly Database _servosaDB;
        public DriverAlertRepository()
        {
            DatabaseProviderFactory databaseFactory = new DatabaseProviderFactory();
            _servosaDB = databaseFactory.CreateDefault();
        }

        public IList<DriverAlertDataModel> GetAlertsNotSeneded()
        {
            object[] parameters = new object[] { };
            IRowMapper<DriverAlertDataModel> vehicleAlertRowMapper = MapBuilder<DriverAlertDataModel>.MapAllProperties().Build();
            var vehicleAlertCollection = _servosaDB.ExecuteSprocAccessor("SAIR_VEALS_TodosNoEnviados", vehicleAlertRowMapper, parameters);
            return vehicleAlertCollection.ToList();
        }

        public int RegisterAlert(DriverAlertDataModel model)
        {
            object[] parameters = new object[] { model.VEAL_TableName, model.VEAL_DaysToAlert, model.VEAL_DateToAlert, model.VEAL_AlertName, model.VEAL_AlertSended, model.VEHI_ID };
            var resultInsert = _servosaDB.ExecuteNonQuery("SAIR_VEALI", parameters);
            return resultInsert;
        }

        public int UpdateAlertSended(int alertId, string tokenSMS, DateTime sendDate, string recipients)
        {
            object[] parameters = new object[] { alertId, tokenSMS, sendDate, recipients };
            var updateResult = _servosaDB.ExecuteNonQuery("SAIR_VEALU", parameters);
            return updateResult;
        }
    }
}