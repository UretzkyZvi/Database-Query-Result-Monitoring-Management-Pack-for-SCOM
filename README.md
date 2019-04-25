# Database Query Result Monitoring Management Pack for SCOM
A Management Pack created by Uretzky Zvi for easily create monitors based SQL queries using System Center Operations Manager.

IMPORTANT NOTE: The latest version of the management pack is now available for free download at
[Free Management Packs - Savision](https://www.savision.com/free-management-packs/)

If you use this and you like it, invite me to a coffee :-)

 Bitcoin Address: 1HPXi5M38F9zCtp1nciaGc15JdR48DrgVv
 
 Ethereum Address: 0x6a34dab1c1e655bb1fab6279204c3eb4ea840e48

## License

[License](https://github.com/uretskyzvi/Monitor-Applications-Using-SQL-Queries/blob/master/LICENSE)

## Features
* Easy Authoring template to create and delete queries.
* New! Support for SQL Authentication. 
* Dedicated views in SCOM console.
* Performance data collection.
* Monitor using consecutive samples condition and schedule filter.
* Grouping multiple queries into a group.

# Quick Start - Usage
Please always test new management packs in a test environment before importing to production!

## Requirements
* SCOM 2012 R2 (earlier versions are untested)
* Microsoft SQL Management Packs.
* SCOM Admin rights (only Administrators can import management packs)
## Quick Start - Install (Deprecated! For new version click [here](https://www.savision.com/free-management-packs/)) 
1. Download [QueryOleDbMonitorSetup.msi](https://github.com/UretzkyZvi/Monitor-Applications-Using-SQL-Queries/releases/download/v2.2.0.1/QueryOleDbMonitorSetup.msi)
2. Run As Administrator the MSI file.
3. Import the management packs into SCOM. All the MPs are in C:\Program Files (x86)\QueryOleDbMonitoring\ManagmentPasks 
![MPs in folder](/Images/2017-06-09%2011_22_32-ManagmentPasks.png?raw=true)
4. Open Authoring find "OleDB Query Monitoring", click Add Monitoring Wizard
![Authoring tempaltes](/Images/2017-06-09%2011_47_50-OleDB%20Query%20Monitoring%20-%20analyticOps%20-%20Operations%20Manager.png?raw=true)
![wizard step 1](/Images/2017-06-09%2011_24_00-Add%20Monitoring%20Wizard.png?raw=true)
5. Follow the wizard instruction
![wizard step 2](/Images/OleDB%20Monitoring/ConnectionAndQuery_1.png?raw=true)
![wizard step 3](/Images/OleDB%20Monitoring/ConnectionAndQuery_SelectDatabase.png?raw=true)
![wizard step 4](/Images/OleDB%20Monitoring/ConnectionAndQuery_Full.png?raw=true)
Or with SQL Authentication
![wizard step 8](/Images/OleDB%20Monitoring/ConnectionAndQuery_FullAuthentication.png?raw=true)
![wizard step 5](/Images/OleDB%20Monitoring/MonitoringSettings.png?raw=true)
![wizard step 6](/Images/OleDB%20Monitoring/MonitoringSettings_Full.png?raw=true)
![wizard step 7](/Images/OleDB%20Monitoring/SchedulerSettings.png?raw=true)

The Alert ex.
![wizard step 10](/Images/2017-06-09%2011_32_40-Active%20Alerts%20-%20analyticOps%20-%20Operations%20Manager.png?raw=true)
Performace ex.
![wizard step 11](/Images/2017-06-09%2011_59_41-Performance%20-%20analyticOps%20-%20Operations%20Manager.png?raw=true)
State ex.
![wizard step 12](/Images/2017-06-09%2011_58_13-State%20-%20analyticOps%20-%20Operations%20Manager.png?raw=true)

6.  Enjoy!!!! :-)

