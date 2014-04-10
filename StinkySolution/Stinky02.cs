private const string LoginInfoInsertQuery = "INSERT INTO login_history (type, login) VALUES ('{0}', '{1}')"; //
        private const string ConnectionStringName = "PlaygroundDatabaseConnection";
// fields not follow code convention.
 
        private readonly DbController _dbController; // Why it field?
      
 
        public LoginInfoDataAccess(IDataAbsractionLayer dataAbsractionLayerLayer, IXmlHelper xmlHelper)
            : base(dataAbsractionLayerLayer, xmlHelper)
        {
            _dbController = new MySqlDbController(ConnectionStringProvider.ConnectionString(ConnectionStringName)); // DbController is IDisposible
        }
 
        public bool SaveLoginInfo(string login, LoginType loginType)
        {
            // No logging. What we are saving
            try
            {
                string sqlQuery = string.Format(LoginInfoInsertQuery, loginType, login);  // String format for DB parameters
                _dbController.BeginTransaction();                                        
                _dbController.ExecuteNonQuery(sqlQuery);
                _dbController.Commit();
                Log.Debug("LogInfoDataAccess.SaveLoginInfo exited");
                return true;
            }
            catch (Exception ex)
            {
                _dbController.Rollback();
                Log.ErrorFormat("LogInfoDataAccess.SaveLoginInfo() exited with operation result false, exception=<{0}>", ex);
                return false;
            }
        }