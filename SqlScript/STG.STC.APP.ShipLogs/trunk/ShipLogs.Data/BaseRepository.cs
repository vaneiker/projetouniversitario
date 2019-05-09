﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShipLogs.Data.EF_MODEL;

namespace ShipLogs.Data
{
    public class BaseRepository
    {
        private ShioLogsManagerDataContext DataContext;
        protected ShipLogsEntities1 ShipLogsManagementContex;

        public BaseRepository()
        {
            DataContext = new ShioLogsManagerDataContext();
            ShipLogsManagementContex = DataContext.shioLogsManagerDataContext;
        }
    }
}