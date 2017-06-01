# Query OleDB monitor
A Management Pack created by Uretzky Zvi for monitoring application by SQL queries with System Center Operations Manager.

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
1. Download QueryOleDbMonitorSetup.msi
2. Run As Administrator the MSI file.
3. Import the management packs into SCOM. All the MPs are in C:\Program Files (x86)\QueryOleDbMonitoring\ManagmentPasks 
4. Open Authoring find "OleDB Query Monitoring", click Add Monitoring Wizard
5. Follow the wizard instruction and Enjoy!
