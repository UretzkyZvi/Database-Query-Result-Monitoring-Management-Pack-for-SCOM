# OleDB query monitor
A Management Pack created by Uretzky Zvi for easily create monitors based SQL queries using System Center Operations Manager.

If you use this and you like it, invite me to a coffee :-)

 Bitcoin Address: 1HPXi5M38F9zCtp1nciaGc15JdR48DrgVv
 
 Ethereum Address: 0x6a34dab1c1e655bb1fab6279204c3eb4ea840e48

## License

[License](https://github.com/uretskyzvi/Monitor-Applications-Using-SQL-Queries/blob/master/LICENSE)

## Features
* Easy Authoring template to create and delete queries.
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
## Quick Start - Install
1. Download [QueryOleDbMonitorSetup.msi](https://github.com/UretzkyZvi/Monitor-Applications-Using-SQL-Queries/releases/download/v1.0.0.0/QueryOleDbMonitorSetup.msi)
2. Run As Administrator the MSI file.
3. Import the management packs into SCOM. All the MPs are in C:\Program Files (x86)\QueryOleDbMonitoring\ManagmentPasks 
![MPs in folder](/Images/2017-06-09%2011_22_32-ManagmentPasks.png?raw=true)
4. Open Authoring find "OleDB Query Monitoring", click Add Monitoring Wizard
![Authoring tempaltes](/Images/2017-06-09%2011_47_50-OleDB%20Query%20Monitoring%20-%20analyticOps%20-%20Operations%20Manager.png?raw=true)
![wizard step 1](/Images/2017-06-09%2011_24_00-Add%20Monitoring%20Wizard.png?raw=true)
5. Follow the wizard instruction
![wizard step 2](/Images/OleDB%20Monitoring/ConnectionAndQuery_1.png?raw=true)
![wizard step 3](/Images/2017-06-09%2011_25_03-Management%20Pack%20Templates%20-%20analyticOps%20-%20Operations%20Manager.png?raw=true)
![wizard step 4](/Images/2017-06-09%2011_28_05-Add%20Monitoring%20Wizard.png?raw=true)
![wizard step 5](/Images/2017-06-09%2011_29_01-Add%20Monitoring%20Wizard.png?raw=true)
![wizard step 6](/Images/2017-06-09%2011_29_19-GroupChooserDialog.png?raw=true)
![wizard step 7](/Images/2017-06-09%2011_29_52-Add%20Monitoring%20Wizard.png?raw=true)
![wizard step 8](/Images/2017-06-09%2011_30_04-Add%20Monitoring%20Wizard.png?raw=true)
![wizard step 9](/Images/2017-06-09%2011_31_08-OleDB%20Query%20Monitoring%20-%20analyticOps%20-%20Operations%20Manager.png?raw=true)
The Alert ex.
![wizard step 10](/Images/2017-06-09%2011_32_40-Active%20Alerts%20-%20analyticOps%20-%20Operations%20Manager.png?raw=true)
Performace ex.
![wizard step 11](/Images/2017-06-09%2011_59_41-Performance%20-%20analyticOps%20-%20Operations%20Manager.png?raw=true)
State ex.
![wizard step 12](/Images/2017-06-09%2011_58_13-State%20-%20analyticOps%20-%20Operations%20Manager.png?raw=true)

6.  Enjoy!!!! :-)

