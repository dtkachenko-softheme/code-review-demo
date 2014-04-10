private void UpdateDeviceInformation(
            DevicePropertiesModel devicePropertiesModel,
            PostDevicesAlertsRequest postDevicesAlerts,
            NotificationSettingModel deviceNotificationSettings,
            DeviceLogSettingsModel deviceLogSettings,
            bool isMasterAgent)
        {
            Log.Debug("NotificationHandler.UpdateDeviceInformation() was called");    // Very useful logging :) Я ругаюсь, но никто не пытается хотя бы постепенно улучшать логирование.
 
            bool isDeviceOfflineAlertPosted = false;
            DeviceStates state = DeviceStates.Ready;
            string errorText = string.Empty;
            var propertiesToUpdate = new Dictionary<int, object>();
 
            XElement currentTonerLevel = GetCurrentTonerLevel(devicePropertiesModel.Toners, postDevicesAlerts.notification_event.current_toner_level);  // What if postDevicesAlerts.notification_event will be null
            propertiesToUpdate.Add(PropertyNames.DeviceToners, currentTonerLevel);
            if (postDevicesAlerts.notification_event.detected_errors != null && postDevicesAlerts.notification_event.detected_errors.Any())  // It almost impossible to read this if statement
            {
                Log.Debug("NotificationHandler.UpdateDeviceInformation() Found errors ...");
 
                isDeviceOfflineAlertPosted = postDevicesAlerts.notification_event.detected_errors.Any(
                    error =>
                    error.alert_information != null
                    && error.alert_information.status_identifier.StartsWith(SpecialAlerts.Offline)); // status_identifier is string -> can be null
 
                List<ALERT_INFORMATION_ENTRY> foundedErrors = GetErrors(postDevicesAlerts);
 
                if (foundedErrors.Any())
                {
                    ALERT_INFORMATION_ENTRY mostImportantError = foundedErrors.OrderByDescending(c => c.alert_information.priority).First(); //                                                                             What is c? Why not f or k?
 
                    errorText = _notificationHandlerHelper.GetAlertText(mostImportantError.alert_information.status_identifier, devicePropertiesModel.AbsoluteModelName, isMasterAgent);
                    Log.DebugFormat("NotificationHandler.UpdateDeviceInformation() Error text: {0}", errorText);
 
                    state = DeviceStates.Error;
                }
                else
                {
                    Log.Debug("NotificationHandler.UpdateDeviceInformation() Trying to identify error or warning text ...");
 
                    var detectedErrors = postDevicesAlerts.notification_event.detected_errors; // Finnaly detected_errors was put to varible, but var is used. What is the type. Should be ALERT_INFORMATION_ENTRY[]